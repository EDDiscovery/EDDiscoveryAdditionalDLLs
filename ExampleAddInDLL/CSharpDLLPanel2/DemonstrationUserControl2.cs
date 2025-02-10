/*
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

using ExtendedControls;
using QuickJSON;
using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using static EDDDLLInterfaces.EDDDLLIF;

namespace DemoUserControl
{
    public partial class DemonstrationUserControl2 : UserControl, IEDDPanelExtension
    {
        private EDDPanelCallbacks PanelCallBack;
        private EDDDLLInterfaces.EDDDLLIF.EDDCallBacks DLLCallBack;

        public DemonstrationUserControl2()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Inherit;      // prevent double resizing
        }

        public bool SupportTransparency => true;

        public bool DefaultTransparent => false;

        // will cope with null
        Color FromJson(JToken color) { return System.Drawing.ColorTranslator.FromHtml(color.Str("Yellow")); }

        public void Initialise(EDDPanelCallbacks callbacks, int displayid, string themeasjson, string configuration)
        {
            DLLCallBack = CSharpDLLPanel2.CSharpDLLPanelEDDClass.DLLCallBack;       // grab the DLL call back
            this.PanelCallBack = callbacks;
            ThemeChanged(themeasjson);
            DLLCallBack.WriteToLogHighlight("Demo DLL UP2 Initialised");
        }
        public void SetTransparency(bool ison, Color curcol)
        {
            System.Diagnostics.Debug.WriteLine($"DLL Set Transparency {ison}");

            extTabControl1.ResetInvalidate();       // IMPORTANT to make the ext tab control resample the background
            this.BackColor = curcol;
            tabPage1.BackColor = curcol;
            tabPage2.BackColor = curcol;
            extCheckBox1.BackColor = curcol;        // note see GroupBoxOverride in themeing. If you had it in a groupbox, you'd use that group back colour when on=true
        }
        public void TransparencyModeChanged(bool on)
        {
            System.Diagnostics.Debug.WriteLine($"DLL Set Transparency Mode {on}");
        }

        public void ThemeChanged(string themeasjson)
        {
            System.Diagnostics.Debug.WriteLine($"DLL Theme changed");

            JObject theme = themeasjson.JSONParse().Object();

            Color form = FromJson(theme["form"]);

            Color ButtonTextColor = FromJson(theme["button_text"]);
            Color ButtonBackColor = FromJson(theme["button_back"]);
            Color ButtonBorderColor = FromJson(theme["button_border"]);

            Color TextBackColor = FromJson(theme["textbox_back"]);
            Color TextBlockColor = FromJson(theme["textbox_fore"]);
            Color TextBlockBorderColor = FromJson(theme["textbox_border"]);

            Color TabcontrolBorder = FromJson(theme["tabcontrol_borderlines"]);
            Color GridScrollButton = FromJson(theme["grid_scrollbutton"]);
            Color GridBorderLines = FromJson(theme["grid_borderlines"]);
            Color GridSliderBack = FromJson(theme["grid_sliderback"]);
            Color GridScrollArrow = FromJson(theme["grid_scrollarrow"]);

            Color TextBlockScrollButton = FromJson(theme["textbox_scrollbutton"]);
            Color TextBlockSliderBack = FromJson(theme["textbox_sliderback"]);

            Color CheckBox = FromJson(theme["checkbox"]);
            Color CheckBoxTick = FromJson(theme["checkbox_tick"]);
            string buttonstyle = theme["buttonstyle"].Str();

            const float mouseoverscaling = 1.3F;
            const float mouseselectedscaling = 1.5F;

            this.BackColor = form;

            FlatStyle fs = buttonstyle.Equals("System") ? FlatStyle.System : FlatStyle.Popup;

            extTabControl1.FlatStyle = fs;
            extTabControl1.TabStyle = new TabStyleAngled();
            extTabControl1.TabControlBorderColor = TabcontrolBorder;
            extTabControl1.TabControlBorderBrightColor = TabcontrolBorder;
            extTabControl1.TabNotSelectedBorderColor = TabcontrolBorder;
            extTabControl1.TabNotSelectedColor = ButtonBackColor;
            extTabControl1.TabSelectedColor = ButtonBackColor.Multiply(mouseselectedscaling);
            extTabControl1.TabMouseOverColor = ButtonBackColor.Multiply(mouseoverscaling);
            extTabControl1.TextSelectedColor = ButtonTextColor;
            extTabControl1.TextNotSelectedColor = ButtonTextColor.Multiply(0.8F);

            extTabControl1.SetStyle(fs, new TabStyleAngled());

            extScrollBar1.BackColor = form;
            extScrollBar1.SliderColor = GridSliderBack;

            Color c1 = GridScrollButton;
            extScrollBar1.BorderColor = GridBorderLines;
            extScrollBar1.BackColor = form;
            extScrollBar1.SliderColor = GridSliderBack;
            extScrollBar1.BorderColor = extScrollBar1.ThumbBorderColor =
                    extScrollBar1.ArrowBorderColor = GridBorderLines;
            extScrollBar1.ArrowButtonColor = extScrollBar1.ThumbButtonColor = c1;
            extScrollBar1.MouseOverButtonColor = c1.Multiply(mouseoverscaling);
            extScrollBar1.MousePressedButtonColor = c1.Multiply(mouseselectedscaling);
            extScrollBar1.ForeColor = GridScrollArrow;
            extScrollBar1.FlatStyle = fs;

            extButton1.ForeColor = ButtonTextColor;
            extButton1.ButtonColorScaling = extButton1.ButtonDisabledScaling = 0.5F;
            extButton1.FlatAppearance.BorderColor = (extButton1.Image != null) ? form : ButtonBorderColor;
            extButton1.FlatAppearance.BorderSize = 1;
            extButton1.FlatAppearance.MouseOverBackColor = ButtonBackColor.Multiply(mouseoverscaling);
            extButton1.FlatAppearance.MouseDownBackColor = ButtonBackColor.Multiply(mouseselectedscaling);
            extButton1.FlatStyle = fs;

            extComboBox1.ForeColor = ButtonTextColor;
            extComboBox1.BackColor = extComboBox1.DropDownBackgroundColor = ButtonBackColor;
            extComboBox1.BorderColor = ButtonBorderColor;
            extComboBox1.MouseOverBackgroundColor = ButtonBackColor.Multiply(mouseoverscaling);
            extComboBox1.ScrollBarButtonColor = TextBlockScrollButton;
            extComboBox1.ScrollBarColor = TextBlockSliderBack;
            extComboBox1.FlatStyle = fs;
            extComboBox1.Repaint();            // force a repaint as the individual settings do not by design.

            // see theme.cs for other options if its a button or has an image

            extCheckBox1.BackColor = form;
            extCheckBox1.ForeColor = CheckBox;
            extCheckBox1.CheckBoxColor = CheckBox;
            extCheckBox1.CheckBoxInnerColor = CheckBox.Multiply(1.5F);
            extCheckBox1.MouseOverColor = CheckBox.Multiply(1.4F);
            extCheckBox1.TickBoxReductionRatio = 0.75f;
            extCheckBox1.CheckColor = CheckBoxTick;
            extCheckBox1.FlatStyle = fs;

            tabPage1.BackColor = form;
            tabPage2.BackColor = form;
        }

        public void LoadLayout()
        {
            PanelCallBack.SetControlText("DLL Demo 2");
        }

        public void InitialDisplay()
        {
            for(int i = 0; i < 100; i++ )
            {
                dataGridView1.Rows.Add(new object[] { "One", "Two" });
            }

            extComboBox1.Items.AddRange(new string[] { "One", "Two", "Three", "Four" });
        }

        public bool AllowClose()
        {
            return true;
        }

        public void Closing()
        {
        }

        void IEDDPanelExtension.CursorChanged(JournalEntry je)          // called when the history cursor changes.. tells you where the user is looking at
        {
        }

        public string HelpKeyOrAddress()
        {
            return @"http:\\news.bbc.co.uk";
        }


        public void HistoryChange(int count, string commander, bool beta, bool legacy)
        {
            DLLCallBack.WriteToLog("Demo DLL User Control History Changed");
        }

        public void NewUnfilteredJournal(JournalEntry je)
        {
        }

        public void NewFilteredJournal(JournalEntry je)
        {
        }

        public void NewUIEvent(string jsonui)
        {
            var j = jsonui.JSONParse();
            string ev = j["EventTypeID"].Str();
        }

        public void NewTarget(Tuple<string, double, double, double> target)
        {
        }

        public void ScreenShotCaptured(string file, Size s)
        {
        }

        public void ControlTextVisibleChange(bool on)
        {
        }
    }
}

