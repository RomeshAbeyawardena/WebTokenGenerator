using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebTokenGenerator.Core;

namespace WinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size = new Size(Width, 240);
            jwTHeaderTextbox.Text = "{" +
                "\r\n\t\"alg\": \"HS256\"," +
                "\r\n\t\"typ\":\"JWT\"" +
                "\r\n}";
            jwtPayloadTextbox.Text = "{\r\n}";
            
            startServerButton.Enabled = true;
        }

        private void advanceSettingsButton_Click(object sender, EventArgs e)
        {
            if (advancedSettingsPanel.Visible)
            {
                advanceSettingsButton.Text = "Advanced settings ▼";
                Size = new Size(Width, 240);
            }
            else
            {
                advanceSettingsButton.Text = "Advanced settings ▲";
                advancedSettingsPanel.Height = 500;
                Size = new Size(Width, 520);
            }

            notifyIcon1.ShowBalloonTip(1000, "Hello", "Hello world", ToolTipIcon.Info);
            advancedSettingsPanel.Visible = !advancedSettingsPanel.Visible;
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
          Close();
        }

        HttpService httpService;
        Task task;
        private void startServerButton_Click(object sender, EventArgs e)
        {
            if (httpService == null || !httpService.IsRunning)
            {
                httpService = new HttpService(
                    serverUrlTextBox.Text, HandleClientRequest);
                serverUrlTextBox.Enabled = false;
                task = httpService.Start();
                startServerButton.Text = "Stop Server";
                httpServiceBackgroundWorker.RunWorkerAsync();
            }
            else
            {
                httpService.Stop();
                startServerButton.Text = "Start Server";
                serverUrlTextBox.Enabled = true;
            }
        }

        private Task HandleClientRequest(HttpListenerRequest request, 
            StreamWriter streamWriter)
        {
            throw new NotImplementedException();
        }

        private void HttpServiceBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!task.IsCompleted)
            {
                if (httpService.IsRunning)
                {
                    statusStrip1.Items[0].Text = $"Server running. Listening on {serverUrlTextBox.Text}";
                }
                else
                {
                    statusStrip1.Items[0].Text = "Server not running";
                }
            }
        }
    }
}
