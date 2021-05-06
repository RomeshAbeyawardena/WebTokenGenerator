namespace WinApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label1;
            System.Windows.Forms.PictureBox pictureBox1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.serverUrlTextBox = new System.Windows.Forms.TextBox();
            this.quitButton = new WinApp.Components.GradientButton();
            this.startServerButton = new WinApp.Components.GradientButton();
            this.advancedSettingsPanel = new System.Windows.Forms.Panel();
            this.jwtPayloadTextbox = new System.Windows.Forms.TextBox();
            this.jwTHeaderTextbox = new System.Windows.Forms.TextBox();
            this.advanceSettingsButton = new WinApp.Components.GradientButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.httpServiceBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            label1 = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            this.advancedSettingsPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(4, 104);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(69, 17);
            label1.TabIndex = 1;
            label1.Text = "Server Url:";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            pictureBox1.BackColor = System.Drawing.Color.Black;
            pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pictureBox1.Location = new System.Drawing.Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(597, 84);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.Color.White;
            label2.Location = new System.Drawing.Point(162, 20);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(54, 17);
            label2.TabIndex = 2;
            label2.Text = "Header:";
            // 
            // label3
            // 
            label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label3.AutoSize = true;
            label3.ForeColor = System.Drawing.Color.White;
            label3.Location = new System.Drawing.Point(162, 157);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(57, 17);
            label3.TabIndex = 3;
            label3.Text = "Payload:";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "In the background!";
            this.notifyIcon1.BalloonTipTitle = "Running in the background";
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // serverUrlTextBox
            // 
            this.serverUrlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverUrlTextBox.BackColor = System.Drawing.Color.Gray;
            this.serverUrlTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serverUrlTextBox.ForeColor = System.Drawing.Color.White;
            this.serverUrlTextBox.Location = new System.Drawing.Point(75, 102);
            this.serverUrlTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.serverUrlTextBox.Name = "serverUrlTextBox";
            this.serverUrlTextBox.Size = new System.Drawing.Size(504, 25);
            this.serverUrlTextBox.TabIndex = 0;
            this.serverUrlTextBox.Text = "http://localhost:8000/";
            // 
            // quitButton
            // 
            this.quitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.quitButton.Angle = 90F;
            this.quitButton.BackgroundColour1 = System.Drawing.Color.Silver;
            this.quitButton.BackgroundColour2 = System.Drawing.Color.Gray;
            this.quitButton.BorderColour = System.Drawing.Color.DimGray;
            this.quitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.quitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitButton.ForeColor = System.Drawing.Color.White;
            this.quitButton.Location = new System.Drawing.Point(408, 136);
            this.quitButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(171, 32);
            this.quitButton.TabIndex = 5;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // startServerButton
            // 
            this.startServerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startServerButton.Angle = 90F;
            this.startServerButton.BackgroundColour1 = System.Drawing.Color.Silver;
            this.startServerButton.BackgroundColour2 = System.Drawing.Color.Gray;
            this.startServerButton.BorderColour = System.Drawing.Color.DimGray;
            this.startServerButton.Enabled = false;
            this.startServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startServerButton.ForeColor = System.Drawing.Color.White;
            this.startServerButton.Location = new System.Drawing.Point(231, 136);
            this.startServerButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.startServerButton.Name = "startServerButton";
            this.startServerButton.Size = new System.Drawing.Size(171, 32);
            this.startServerButton.TabIndex = 6;
            this.startServerButton.Text = "Start server";
            this.startServerButton.UseVisualStyleBackColor = true;
            this.startServerButton.Click += new System.EventHandler(this.startServerButton_Click);
            // 
            // advancedSettingsPanel
            // 
            this.advancedSettingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedSettingsPanel.Controls.Add(label3);
            this.advancedSettingsPanel.Controls.Add(label2);
            this.advancedSettingsPanel.Controls.Add(this.jwtPayloadTextbox);
            this.advancedSettingsPanel.Controls.Add(this.jwTHeaderTextbox);
            this.advancedSettingsPanel.Location = new System.Drawing.Point(12, 174);
            this.advancedSettingsPanel.Name = "advancedSettingsPanel";
            this.advancedSettingsPanel.Size = new System.Drawing.Size(567, 298);
            this.advancedSettingsPanel.TabIndex = 7;
            this.advancedSettingsPanel.Visible = false;
            // 
            // jwtPayloadTextbox
            // 
            this.jwtPayloadTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jwtPayloadTextbox.BackColor = System.Drawing.Color.Gray;
            this.jwtPayloadTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jwtPayloadTextbox.ForeColor = System.Drawing.Color.White;
            this.jwtPayloadTextbox.Location = new System.Drawing.Point(219, 154);
            this.jwtPayloadTextbox.Multiline = true;
            this.jwtPayloadTextbox.Name = "jwtPayloadTextbox";
            this.jwtPayloadTextbox.Size = new System.Drawing.Size(334, 117);
            this.jwtPayloadTextbox.TabIndex = 1;
            // 
            // jwTHeaderTextbox
            // 
            this.jwTHeaderTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jwTHeaderTextbox.BackColor = System.Drawing.Color.Gray;
            this.jwTHeaderTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jwTHeaderTextbox.ForeColor = System.Drawing.Color.White;
            this.jwTHeaderTextbox.Location = new System.Drawing.Point(219, 17);
            this.jwTHeaderTextbox.Multiline = true;
            this.jwTHeaderTextbox.Name = "jwTHeaderTextbox";
            this.jwTHeaderTextbox.Size = new System.Drawing.Size(334, 121);
            this.jwTHeaderTextbox.TabIndex = 0;
            // 
            // advanceSettingsButton
            // 
            this.advanceSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advanceSettingsButton.Angle = 90F;
            this.advanceSettingsButton.BackgroundColour1 = System.Drawing.Color.Silver;
            this.advanceSettingsButton.BackgroundColour2 = System.Drawing.Color.Gray;
            this.advanceSettingsButton.BorderColour = System.Drawing.Color.DimGray;
            this.advanceSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.advanceSettingsButton.ForeColor = System.Drawing.Color.White;
            this.advanceSettingsButton.Location = new System.Drawing.Point(12, 136);
            this.advanceSettingsButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.advanceSettingsButton.Name = "advanceSettingsButton";
            this.advanceSettingsButton.Size = new System.Drawing.Size(186, 32);
            this.advanceSettingsButton.TabIndex = 8;
            this.advanceSettingsButton.Text = "Advanced Settings ▼";
            this.advanceSettingsButton.UseVisualStyleBackColor = true;
            this.advanceSettingsButton.Click += new System.EventHandler(this.advanceSettingsButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.DimGray;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 474);
            this.statusStrip1.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(597, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(105, 17);
            this.toolStripStatusLabel1.Text = "Server not running";
            // 
            // httpServiceBackgroundWorker
            // 
            this.httpServiceBackgroundWorker.WorkerSupportsCancellation = true;
            this.httpServiceBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.HttpServiceBackgroundWorker_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(591, 497);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.advanceSettingsButton);
            this.Controls.Add(this.advancedSettingsPanel);
            this.Controls.Add(this.startServerButton);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(pictureBox1);
            this.Controls.Add(label1);
            this.Controls.Add(this.serverUrlTextBox);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Web Token Generator";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            this.advancedSettingsPanel.ResumeLayout(false);
            this.advancedSettingsPanel.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TextBox serverUrlTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Components.GradientButton quitButton;
        private Components.GradientButton startServerButton;
        private System.Windows.Forms.Panel advancedSettingsPanel;
        private Components.GradientButton advanceSettingsButton;
        private System.Windows.Forms.TextBox jwtPayloadTextbox;
        private System.Windows.Forms.TextBox jwTHeaderTextbox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.ComponentModel.BackgroundWorker httpServiceBackgroundWorker;
    }
}

