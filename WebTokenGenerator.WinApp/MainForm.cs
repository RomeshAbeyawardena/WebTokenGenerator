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
using WebTokenGenerator.Shared.Abstractions;
using WebTokenGenerator.Shared.Domain;

namespace WebTokenGenerator.WinApp
{
    public partial class MainForm : Form, IMainForm
    {
        private readonly IHttpService httpService;
        public MainForm(IHttpService httpService)
        {
            this.httpService = httpService;

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

        
        Task task;
        private void startServerButton_Click(object sender, EventArgs e)
        {
            if (!httpService.IsRunning)
            {
                serverUrlTextBox.Enabled = false;
                task = httpService.Start(serverUrlTextBox.Text, HandleClientRequest);
                startServerButton.Text = "Stop Server";
                httpServiceBackgroundWorker.RunWorkerAsync();
            }
            else
            {
                httpService.Stop();
                statusStrip1.Items[0].Text = "Server not running";
                startServerButton.Text = "Start Server";
                serverUrlTextBox.Enabled = true;
            }
        }

        private async Task<ProcessResult> HandleClientRequest(HttpListenerRequest request, 
            StreamWriter streamWriter)
        {
            try
            {
                var queryString = request.QueryString;

                var issuer = queryString["issuer"];
                var clientId = queryString["clientId"];
                
                if (string.IsNullOrWhiteSpace(issuer))
                {
                    throw new NullReferenceException("Issuer not specified");
                }

                if (string.IsNullOrWhiteSpace(clientId))
                {
                    throw new NullReferenceException("Client Id not specified");
                }

                return ProcessResult.Success();
            }
            catch(NullReferenceException exception)
            {
                return ProcessResult.Fail(exception);
            }
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
