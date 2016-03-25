using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Renci.SshNet;
using Renci.SshNet.Common;
using Renci.SshNet.Sftp;
using Renci.SshNet.Channels;
using Renci.SshNet.Messages;
using Renci.SshNet.Messages.Connection;
using Renci.SshNet.Messages.Transport;
using System.Globalization;

namespace TestWebApp2
{
    public partial class BrewSession : System.Web.UI.Page
    {

        public static bool runningOnPi { get; set; }
        public string boilProbeID { get; set; }
        public string mashProbeID { get; set; }
        public string hlt_rimsProbeId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            runningOnPi = false;
            
            if (Application["BoilProbe"] == null)
            {
                Response.Redirect("SetupSession.aspx");
            }
            
            boilProbeID = Application["BoilProbe"].ToString();
            mashProbeID = Application["MashProbe"].ToString();
            hlt_rimsProbeId = Application["HLT_RIMsProbe"].ToString();
        }

        protected void initializeSetTemps(object sender, EventArgs e)
        {
            TempSet1.Text = "212";
            TempSet3.Text = "152";
        }

        protected void sendTemp1(object sender, EventArgs e)
        {
            double temp = double.Parse(TempSet1.Text);
            setCurrentTemp1_1(temp);
        }

        protected void setCurrentTemp1(object sender, EventArgs e)
        {
            CurrentSetTemp1.Text = "212";
        }

        protected void setCurrentTemp1_1(double temp = 90)
        {
            string strTemp = temp.ToString();
            CurrentSetTemp1.Text = strTemp;

        }

        protected void sendTemp3(object sender, EventArgs e)
        {
            double temp = double.Parse(TempSet3.Text);
            setCurrentTemp3_1(temp);
        }

        protected void setCurrentTemp3(object sender, EventArgs e)
        {
            CurrentSetTemp3.Text = "152";
        }

        protected void setCurrentTemp3_1(double temp = 90)
        {
            string strTemp = temp.ToString();
            CurrentSetTemp3.Text = strTemp;
        }
        
        protected void UpdateTemp_Tick(object sender, EventArgs e)
        {
            string strTemp1 = ReturnTemp(boilProbeID);
            TempLabel1.Text = strTemp1;
            double doubTemp1 = double.Parse(strTemp1);

            string strTemp2 = ReturnTemp(mashProbeID);
            TempLabel2.Text = strTemp2;

            string strTemp3 = ReturnTemp(hlt_rimsProbeId);
            TempLabel3.Text = strTemp3;
            double doubTemp3 = double.Parse(strTemp3);

            double setTemp1 = double.Parse(CurrentSetTemp1.Text);
            double setTemp3 = double.Parse(CurrentSetTemp3.Text);

            if (doubTemp1 < setTemp1 /*&& HeatingIndicator1.Text == "Off"*/)
            {
                //HeatingIndicator1.Text = "Heating";
                //toggleHeatSSR(1, "On");
            }

            else if (doubTemp1 >= setTemp1 /*&& HeatingIndicator1.Text == "Heating"*/)
            {
                //HeatingIndicator1.Text = "Off";
                //toggleHeatSSR(1, "Off");
            }


            if (doubTemp3 < setTemp3 && HeatingIndicator3.Text == "Off")
            {
                //HeatingIndicator3.Text = "Heating";
                //toggleHeatSSR(2, "On");
            }
            else if (doubTemp3 >= setTemp3 && HeatingIndicator3.Text == "Heating")
            {
                //HeatingIndicator3.Text = "Off";
                //toggleHeatSSR(2, "Off");
            }

        }

        public static string ReturnTemp(string probeName)
        {
            string tempDir = "/sys/bus/w1/devices/";
            string filePath = "";
            if (runningOnPi == false)
            {
                filePath = @"c:/temp/" + probeName + "/w1_slave";
                FTPCall(tempDir, probeName);
            }
            else
            {
                filePath = tempDir;
            }

            StreamReader sr = new StreamReader(filePath);

            if (runningOnPi == false )
            {
                string localDir = (@"c:/temp/" + probeName + "/w1_slave");
                //FTPCall(tempDir, probeName);
            }
            
            string line = sr.ReadToEnd();
            int numStart = line.IndexOf("t=");
            string lineSubStr = line.Substring((numStart + 2), 5);
            double tempC = (double.Parse(lineSubStr)) / 1000;
            double tempF = ((tempC * 9) / 5) + 32;
            string strTempF = tempF.ToString();
            return strTempF;
        }

        public static void FTPCall(string tempDir, string probeName)
        {
            const string host = "10.0.1.55";
            const string username = "pi";
            const string password = "8vwd1401";
            string fileName = probeName + "/w1_slave";
            string localPath = @"c:/temp/";

            using (SftpClient sftp = new SftpClient(host, username, password))
            {
                sftp.Connect();
                sftp.ChangeDirectory(tempDir);

                if (!(File.Exists(localPath + fileName)))
                {
                    new FileInfo(localPath + fileName).Directory.Create();
                }
                
                using (var file = File.OpenWrite(localPath + fileName))
                {  
                    sftp.DownloadFile(fileName, file);
                }

                sftp.Disconnect();

            }

        }
    }
}