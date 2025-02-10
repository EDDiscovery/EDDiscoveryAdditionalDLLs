using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDLLPanel2
{
    public class CSharpDLLPanelEDDClass
    {
        public static EDDDLLInterfaces.EDDDLLIF.EDDCallBacks DLLCallBack;

        public CSharpDLLPanelEDDClass()
        {
            System.Diagnostics.Debug.WriteLine("CSharpDLLPanel2 Made DLL instance");
        }

        public string EDDInitialise(string vstr, string dllfolder, EDDDLLInterfaces.EDDDLLIF.EDDCallBacks cb)
        {
            DLLCallBack = cb;
            System.Diagnostics.Debug.WriteLine("CSharpDLLPanel2 Init func " + vstr + " " + dllfolder);
            if ( cb.ver>=3 && cb.AddPanel != null)
            {
                // make sure panel unique id and winref name is based on a producer-panel naming system to make it unique
                string uniquename = "CSharpDLLPanel-Demo2";
                cb.AddPanel(uniquename, typeof(DemoUserControl.DemonstrationUserControl2), "DLLUC-2", uniquename, "UC DLL 2 Demo user panel", CSharpDLLPanel.Properties.Resources.CaptainsLog);
            }
            return "1.0.0.0";
        }

        public void EDDTerminate()
        {
            System.Diagnostics.Debug.WriteLine("CSharpDLLPanel2 Unload");
        }
        public void EDDDataResult(object requesttag, object usertag, string data)
        {
            DemoUserControl.DemonstrationUserControl2 uc = usertag as DemoUserControl.DemonstrationUserControl2;
        }
    }
}
