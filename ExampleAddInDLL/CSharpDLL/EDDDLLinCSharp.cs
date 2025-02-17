﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dependency;
using QuickJSON;

namespace CSharpDLL
{
    public class EDDClass
    {
        public EDDClass()
        {
            System.Diagnostics.Debug.WriteLine("CSharpDLL Made DLL instance");
            //var x = new Class1();
        }

        EDDDLLInterfaces.EDDDLLIF.EDDCallBacks callbacks;

        public string EDDInitialise(string vstr, string dllfolder, EDDDLLInterfaces.EDDDLLIF.EDDCallBacks cb)
        {
            System.Diagnostics.Debug.WriteLine("CSharpDLL Init func " + vstr + " " + dllfolder);
            System.IO.File.AppendAllText(@"c:\code\csharpdll.txt", Environment.NewLine + "Init " + vstr + " in " + dllfolder + Environment.NewLine);
            callbacks = cb;
            return "1.0.0.0";
        }

        public void EDDTerminate()
        {
            System.Diagnostics.Debug.WriteLine("CSharpDLL Unload");
        }

        public void EDDRefresh(string cmdname, EDDDLLInterfaces.EDDDLLIF.JournalEntry lastje)
        {
            System.Diagnostics.Debug.WriteLine("CSharpDLL Refresh");
        }
        public void EDDMainFormShown()
        {
            System.Diagnostics.Debug.WriteLine("CSharpDLL Main form shown");
        }

        public void EDDNewJournalEntry(EDDDLLInterfaces.EDDDLLIF.JournalEntry je)
        {
            System.Diagnostics.Debug.WriteLine($"CSharpDLL New Journal Entry {je.ver} at {je.utctime}");
            System.Diagnostics.Debug.WriteLine($"V1:{je.name} {je.systemname} {je.x} {je.y} {je.z}");
            System.Diagnostics.Debug.WriteLine($"   info: {je.info} ");
            System.Diagnostics.Debug.WriteLine($"   Mat: {string.Join(",", je.materials)} ");
            System.Diagnostics.Debug.WriteLine($"   Comms: {string.Join(",", je.commodities)} ");
            // etc
            System.Diagnostics.Debug.WriteLine($"V6:GV `{je.gameversion}` GB `{je.gamebuild}`");
            System.Diagnostics.Debug.WriteLine($"V7:FSDN `{je.fsdjumpnextsystemname}` ADDR {je.fsdjumpnextsystemaddress} SA {je.systemaddress} Mid {je.marketid}");
            System.Diagnostics.Debug.WriteLine($"   FBID {je.fullbodyid} Loan {je.loan} assets {je.assets} CB {je.currentboost} VS {je.visits} MP {je.multiplayer} ISUPER {je.insupercruise}");

            System.IO.File.AppendAllText(@"c:\code\csharpdll.txt", "NJE " + je.json + Environment.NewLine);
        }

        public void EDDNewUnfilteredJournalEntry(EDDDLLInterfaces.EDDDLLIF.JournalEntry je)
        {
            System.Diagnostics.Debug.WriteLine("CSharpDLL New Unfiltered Journal Entry " + je.utctime);
            System.IO.File.AppendAllText(@"c:\code\csharpdll.txt", "NJE " + je.json + Environment.NewLine);
        }

        public string EDDActionCommand(string cmdname, string[] paras)
        {
            System.Diagnostics.Debug.WriteLine("CSharpDLL EDD Action Command");
            return "";
        }

        public void EDDActionJournalEntry(EDDDLLInterfaces.EDDDLLIF.JournalEntry je)
        {
            System.Diagnostics.Debug.WriteLine("CSharpDLL EDD Action journal entry");
        }

        public void EDDNewUIEvent(string json)
        {
            System.Diagnostics.Debug.WriteLine("CSharpDLL EDD UI Event" + json);
            System.IO.File.AppendAllText(@"c:\code\csharpdll.txt", "UI " + json + Environment.NewLine);
        }

        public string EDDConfig(string istr, bool editit)
        {
            JObject js = JObject.Parse(istr);
            string para = js != null ? js["Para1"].Str("Default") : "Default";

            if ( editit)
            {
                para  = Prompt.ShowDialog("Data:","Message box for config", para);
            }

            JObject jout = new JObject();
            jout["Para1"] = para;
            string outconfig = jout.ToString();
           
            System.Diagnostics.Debug.WriteLine("CSharpDLL EDD Config Event:" + outconfig);
            return outconfig;
        }


        public static class Prompt
        {
            public static string ShowDialog(string labeltext, string caption, string data)
            {
                Form prompt = new Form()
                {
                    Width = 500,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 50, Top = 20, Text = labeltext };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400, Text = data };
                Button confirmation = new Button() { Text = "OK", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }

    }
}
