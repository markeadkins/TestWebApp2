using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace TestWebApp2
{
    public partial class SetupSession : System.Web.UI.Page
    {
        List<string> list1 { get; set; }
        int runNum = 1;
        
        protected void Page_Load(object sender, EventArgs e)
        {

            list1 = MakeDropDownListOfTempProbes();
            while(Application["runNum"] == null)
            {

                foreach (string item in list1)
                {
                    radio1.Items.Add(new ListItem(item));
                }
                runNum++;
                Application["runNum"] = runNum;
                break;
            }

        }

        protected void BoilProbeAssign(object sender, EventArgs e)
        {
            Application["BoilProbe"] = radio1.SelectedValue;
            list1.Remove(radio1.SelectedValue);
            foreach (string item in list1)
            {
                radio2.Items.Add(new ListItem(item));
            }

        }

        protected void MashProbeAssign(object sender, EventArgs e)
        {
            Application["MashProbe"] = radio2.SelectedValue;
            list1.Remove(radio1.SelectedValue);
            list1.Remove(radio2.SelectedValue);
            foreach (string item in list1)
            {
                radio3.Items.Add(new ListItem(item));
            }

        }

        protected void HLT_RIMsProbeAssign(object sender, EventArgs e)
        {
            Application["HLT_RIMsProbe"] = radio3.SelectedValue;
        }



        protected void ProbeAssign(object sender, EventArgs e)
        {
            Response.Redirect("BrewSession.aspx");
        }


        public List<string> MakeDropDownListOfTempProbes()
        {
            Array arr = GetTempProbeNames();

            List<string> list1 = new List<string>();

            foreach (string arrItem in arr)
            {
                list1.Add(arrItem);
            }

            return list1;

        }

        public static Array GetTempProbeNames()
        {
            string folderLocation = "/sys/bus/w1/devices/w1_bus_master1";
            string[] dir = Directory.GetDirectories(folderLocation, "28-0*");
            int indexNum = 0;
            foreach (string str in dir)
            {
                int i = str.IndexOf("28-0");
                string newStr = str.Substring(i, 15);
                dir[indexNum] = newStr;
                indexNum++;
            }

            return dir;
        }
    }
}