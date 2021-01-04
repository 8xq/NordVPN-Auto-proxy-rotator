using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leaf.xNet;
namespace NordVPN_auto_switcher
{
    public partial class Form1 : MetroSuite.MetroForm
    {
        Servers.RandomCountry SL = new Servers.RandomCountry();
        bool running = false;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // The method to change proxy via batch command (hidden console)
        private void ChangeIP(string server , int delay)
        {
            while (running == true)
            {
                string command = "";
                switch (server.ToLower())
                {
                    case "p2p":
                        command = "nordvpn -c --group-name \"p2p\"";
                        label4.Text = "Connecting via peer 2 peer proxy";
                        break;
                    case "random (country)":
                        string server_use = SL.GrabRandomCountry();
                        label4.Text = "Grabbing server from " + server_use;
                        command = "nordvpn -c --group-name " + server_use;
                        break;
                    default:
                        MessageBox.Show("Error - please make sure a server is selected !", "Error - invalid option");
                        break;
                }

                Process CMD_exec = new Process();
                CMD_exec.StartInfo.FileName = "cmd";
                CMD_exec.StartInfo.Arguments = "/c cd \"C:\\Program Files\\NordVPN\" & " + command + " \\";
                CMD_exec.StartInfo.CreateNoWindow = true;
                CMD_exec.StartInfo.UseShellExecute = false;
                CMD_exec.Start();
                CMD_exec.WaitForExit();
                label4.Text = "Changing IP -/- setting new IP";
                Thread.Sleep(delay * 1000);
            }
        }
        // Start button 
        private void metroButton1_Click(object sender, EventArgs e)
        {
            string server = metroComboBox1.Text;
            string delay = metroTextbox1.Text;
            bool CheckDelay = string.IsNullOrEmpty(delay);
            bool CheckServer = string.IsNullOrEmpty(server);
            if(CheckServer == false && CheckDelay == false)
            {
                running = true;
                Thread changer = new Thread(() => ChangeIP(server , Convert.ToInt32(delay)));
                changer.Start();
            }
            else
            {
                MessageBox.Show("Error - please check all fields are filled in !", "Error - missing infomration");
            }
        }

        // Stop button 
        private void metroButton2_Click(object sender, EventArgs e)
        {
            running = false;
            label4.Text = "Stopping";
            Process CMD_exec = new Process();
            CMD_exec.StartInfo.FileName = "cmd";
            CMD_exec.StartInfo.Arguments = "/c cd \"C:\\Program Files\\NordVPN\" & nordvpn --disconnect \\";
            CMD_exec.StartInfo.CreateNoWindow = true;
            CMD_exec.StartInfo.UseShellExecute = false;
            CMD_exec.Start();
            CMD_exec.WaitForExit();
            label4.Text = "idle";
        }
    }
}
