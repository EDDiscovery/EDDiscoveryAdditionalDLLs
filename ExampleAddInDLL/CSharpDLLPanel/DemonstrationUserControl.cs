﻿/*
 * Copyright © 2022 - 2022 EDDiscovery development team
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this
 * file except in compliance with the License. You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software distributed under
 * the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF
 * ANY KIND, either express or implied. See the License for the specific language
 * governing permissions and limitations under the License.
 */

using QuickJSON;
using System;
using System.Drawing;
using System.Windows.Forms;
using static EDDDLLInterfaces.EDDDLLIF;

namespace DemoUserControl
{
    public partial class DemonstrationUserControl : UserControl, IEDDPanelExtension
    {
        private EDDPanelCallbacks PanelCallBack;
        private EDDDLLInterfaces.EDDDLLIF.EDDCallBacks DLLCallBack;

        public DemonstrationUserControl()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Inherit;      // prevent double resizing
        }

        public bool SupportTransparency => true;

        public bool DefaultTransparent => false;

        Color FromJson(JToken color) { return Color.FromArgb(color["A"].Int(), color["R"].Int(), color["G"].Int(), color["B"].Int()); }

        public void Initialise(EDDPanelCallbacks callbacks, int displayid, string themeasjson, string configuration)
        {
            DLLCallBack = CSharpDLLPanel2.CSharpDLLPanelEDDClass.DLLCallBack;       // grab the DLL call back
            this.PanelCallBack = callbacks;

            ThemeChanged(themeasjson);

            dataGridView1.Rows.Add(new string[] { "Event grid", "1-1", "1-2" ,"1-3"});
            richTextBox1.AppendText("New Panel init\r\n");
            DLLCallBack.WriteToLogHighlight("Demo DLL Initialised");
        }
        public void SetTransparency(bool ison, Color curcol)
        {
            richTextBox1.AppendText($"Set Transparency {ison}\r\n");
            this.BackColor = panel1.BackColor = curcol;
            PanelCallBack.DGVTransparent(dataGridView1, ison, curcol);
        }

        public void LoadLayout()
        {
            richTextBox1.AppendText("load layout\r\n");
            PanelCallBack.SetControlText("Ext Panel!");
            PanelCallBack.LoadGridLayout(dataGridView1);
        }

        public void InitialDisplay()
        {
            richTextBox1.AppendText("init display\r\n");
        }

        public bool AllowClose()
        {
            return true;
        }

        public void Closing()
        {
            richTextBox1.AppendText($"close panel {PanelCallBack.IsClosed()}\r\n");
            PanelCallBack.SaveString("Textbox1", textBox1.Text);
            PanelCallBack.SaveGridLayout(dataGridView1);
        }

        void IEDDPanelExtension.CursorChanged(JournalEntry je)          // called when the history cursor changes.. tells you where the user is looking at
        {
            richTextBox1.AppendText($"Cursor changed to {je.name}\r\n");
        }

        public string HelpKeyOrAddress()
        {
            return @"http:\\news.bbc.co.uk";
        }

        public void ControlTextVisibleChange(bool on)
        {
            richTextBox1.AppendText($"Control text visibility to {on}\r\n");
        }

        public void HistoryChange(int count, string commander, bool beta, bool legacy)
        {
            richTextBox1.AppendText($"History change {count} {commander} {beta} {legacy}\r\n");
            dataGridView1.Rows.Clear();

            for( int i = 5; i > 0; i-- )    // demo - load last 5 HEs
            {
                if ( DLLCallBack.RequestHistory(count-i,false,out JournalEntry je) )
                { 
                    dataGridView1.Rows.Add(new string[] { je.utctime, je.name, je.info, je.detailedinfo });
                }
                else
                    break;
            }

            var target = DLLCallBack.GetTarget();
            if (target != null)
                richTextBox1.AppendText($"Target is {target}\r\n");
            else
                richTextBox1.AppendText($"No Target\r\n");

            DLLCallBack.WriteToLog("Demo DLL User Control History Changed");
        }

        public void NewUnfilteredJournal(JournalEntry je)
        {
            richTextBox1.AppendText($"New unfiltered JE {je.json} \r\n");
        }

        public void NewFilteredJournal(JournalEntry je)
        {
            richTextBox1.AppendText($"New filtered JE {je.json}\r\n");
            dataGridView1.Rows.Add(new string[] { je.utctime, je.name, je.info, je.detailedinfo });
        }

        public void NewUIEvent(string jsonui)
        {
            var j = jsonui.JSONParse();
            string ev = j["EventTypeID"].Str();
            richTextBox1.AppendText($"New UI Event {ev}\r\n");
            dataGridView1.Rows.Add(new string[] { "UI", ev, jsonui, "" });
        }

        public void NewTarget(Tuple<string, double, double, double> target)
        {
            if (target != null)
                richTextBox1.AppendText($"New target {target.Item1} {target.Item2} {target.Item3} {target.Item4}\r\n");
            else
                richTextBox1.AppendText($"Target removed\r\n");
        }

        public void ScreenShotCaptured(string file, Size s)
        {
            richTextBox1.AppendText($"Screenshot {file} {s}\r\n");
        }

        public void ThemeChanged(string themeasjson)
        {
            // theme variables can be found in ExtendedControls - theme

            JObject theme = themeasjson.JSONParse().Object();
            Color butbordercolor = FromJson(theme["ButtonBorderColor"]);
            Color butforecolor = FromJson(theme["ButtonTextColor"]);
            Color butbackcolor = FromJson(theme["ButtonBackColor"]);
            buttonShipLoadout.ForeColor = butforecolor;
            buttonShipLoadout.FlatAppearance.BorderColor = butbordercolor;
            buttonShipLoadout.BackColor = butbackcolor;

            Color textbordercolor = FromJson(theme["TextBlockBorderColor"]);
            Color textforecolor = FromJson(theme["TextBlockColor"]);
            Color textbackcolor = FromJson(theme["TextBackColor"]);

            textBox1.Text = PanelCallBack.GetString("Textbox1", "Default");
            textBox1.BackColor = textbackcolor;
            textBox1.ForeColor = textforecolor;
            textBox1.BorderStyle = BorderStyle.FixedSingle;

            richTextBox1.BackColor = textbackcolor;
            richTextBox1.ForeColor = textforecolor;
            richTextBox1.BorderStyle = BorderStyle.FixedSingle;

            Font fnt = new Font(theme["Font"].Str(), theme["FontSize"].Float());
            richTextBox1.Font = fnt;

            Color formbackcolor = FromJson(theme["Form"]);

            PanelCallBack.DGVTransparent(dataGridView1, false, formbackcolor); // presuming its not transparent.. would need to make this more clever by saving Settransparent state
        }

        private void buttonShipLoadout_Click(object sender, EventArgs e)
        {
            string loadout = DLLCallBack.GetShipLoadout("");        // current ship
            richTextBox1.AppendText($"Loadout {loadout}\r\n");
            richTextBox1.ScrollToCaret();
        }

        private void buttonAllShips_Click(object sender, EventArgs e)
        {
            string loadout = DLLCallBack.GetShipLoadout("all");      
            richTextBox1.AppendText($"Loadout {loadout}\r\n");
            richTextBox1.ScrollToCaret();

        }

        private void buttonAspShip_Click(object sender, EventArgs e)
        {
            string loadout = DLLCallBack.GetShipLoadout("Asp");
            richTextBox1.AppendText($"Loadout {loadout}\r\n");
            richTextBox1.ScrollToCaret();
        }

        private void buttonCurrentSys_Click(object sender, EventArgs e)
        {
            DLLCallBack.RequestScanData(null,this, "",true);
        }

        private void buttonSys1_Click(object sender, EventArgs e)
        {
            DLLCallBack.RequestScanData(null,this,"Shumbeia ZK-Z c28-3", false);
        }

        public void DataResult(string data)
        {
            richTextBox1.AppendText($"System {data}\r\n");
            richTextBox1.ScrollToCaret();
        }

        private void buttonSuits_Click(object sender, EventArgs e)
        {
            string loadout = DLLCallBack.GetSuitsWeaponsLoadouts();
            richTextBox1.AppendText($"Suits {loadout}\r\n");
            richTextBox1.ScrollToCaret();
        }

        private void buttonOutfitting_Click(object sender, EventArgs e)
        {
            string loadout = DLLCallBack.GetOutfitting();
            richTextBox1.AppendText($"Outfitting {loadout}\r\n");
            richTextBox1.ScrollToCaret();
        }

        private void buttonShipyards_Click(object sender, EventArgs e)
        {
            string loadout = DLLCallBack.GetShipyards();
            richTextBox1.AppendText($"Shipyards {loadout}\r\n");
            richTextBox1.ScrollToCaret();
        }

        private void buttonVisited_Click(object sender, EventArgs e)
        {
            string loadout = DLLCallBack.GetVisitedList(7204);
            richTextBox1.AppendText($"Visited {loadout.Substring(0,Math.Min(30000,loadout.Length))}..\r\n");
            richTextBox1.ScrollToCaret();
        }

        private void buttonCarrier_Click(object sender, EventArgs e)
        {
            string loadout = DLLCallBack.GetCarrierData();
            richTextBox1.AppendText($"Carrier {loadout}\r\n");
            richTextBox1.ScrollToCaret();
        }

    }
}

