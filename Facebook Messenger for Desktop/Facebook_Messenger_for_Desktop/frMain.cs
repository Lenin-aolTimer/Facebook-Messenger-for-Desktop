namespace Facebook_Messenger_for_Desktop
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;

    public class frMain : Form
    {
        private IContainer components = null;
        private Process currentProcess = Process.GetCurrentProcess();
        private Process[] processes = Process.GetProcesses();
        private WebBrowser webBrowser1;

        public frMain()
        {
            if (this.isRunning())
            {
                MessageBox.Show("La aplicaci\x00f3n ya se encuentra en ejecuci\x00f3n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                base.Close();
                Application.Exit();
            }
            else
            {
                this.InitializeComponent();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frMain));
            this.webBrowser1 = new WebBrowser();
            base.SuspendLayout();
            this.webBrowser1.Dock = DockStyle.Fill;
            this.webBrowser1.Location = new Point(0, 0);
            this.webBrowser1.MinimumSize = new Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new Size(0x3bf, 0x386);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new Uri("https://www.messenger.com", UriKind.Absolute);
            base.AutoScaleDimensions = new SizeF(8f, 16f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x3bf, 0x386);
            base.Controls.Add(this.webBrowser1);
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "frMain";
            this.Text = "Facebook Messenger";
            base.ResumeLayout(false);
        }

        private bool isRunning()
        {
            foreach (Process process in this.processes)
            {
                if ((process.Id != this.currentProcess.Id) && (process.ProcessName == this.currentProcess.ProcessName))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

