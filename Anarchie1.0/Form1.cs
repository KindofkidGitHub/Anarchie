using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Anarchie1._0
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        public Form1()
        {
            // Panel for Sections
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = HomeBtn.Height;
            pnlNav.Top = HomeBtn.Top;
            pnlNav.Left = HomeBtn.Left;
            HomeBtn.BackColor = Color.FromArgb(213, 232, 243);

            // Startup Screen
            lblTitle.Text = "Home";
            this.pnlFormLoader.Controls.Clear();
            frmHome frmHome_Vrb = new frmHome() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmHome_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmHome_Vrb);
            frmHome_Vrb.Show();
        }

        private void PnlNav_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(@"C:\Anarchie"))
                {
                    return;
                }

                DirectoryInfo di = Directory.CreateDirectory(@"C:\Anarchie");
            }
            catch
            {
                Application.Exit();
            }
            finally { }
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            // Light Up and Postion of the Button
            pnlNav.Height = HomeBtn.Height;
            pnlNav.Top = HomeBtn.Top;
            pnlNav.Left = HomeBtn.Left;
            HomeBtn.BackColor = Color.FromArgb(213, 232, 243);

            // Dashboard of the Button
            lblTitle.Text = "Home";
            this.pnlFormLoader.Controls.Clear();
            frmHome frmHome_Vrb = new frmHome() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmHome_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmHome_Vrb);
            frmHome_Vrb.Show();

        }

        private void AppsBtn_Click(object sender, EventArgs e)
        {
            pnlNav.Height = AppsBtn.Height;
            pnlNav.Top = AppsBtn.Top;
            AppsBtn.BackColor = Color.FromArgb(213, 232, 243);

            lblTitle.Text = "Apps";
            this.pnlFormLoader.Controls.Clear();
            frmApps frmApps_Vrb = new frmApps() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmApps_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmApps_Vrb);
            frmApps_Vrb.Show();
        }

        private void GamesBtn_Click(object sender, EventArgs e)
        {
            pnlNav.Height = GamesBtn.Height;
            pnlNav.Top = GamesBtn.Top;
            GamesBtn.BackColor = Color.FromArgb(213, 232, 243);

            lblTitle.Text = "Games";
            this.pnlFormLoader.Controls.Clear();
            frmGames frmGames_Vrb = new frmGames() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmGames_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmGames_Vrb);
            frmGames_Vrb.Show();
        }

        private void ToolsBtn_Click(object sender, EventArgs e)
        {
            pnlNav.Height = ToolsBtn.Height;
            pnlNav.Top = ToolsBtn.Top;
            ToolsBtn.BackColor = Color.FromArgb(213, 232, 243);

            lblTitle.Text = "Tools";
            this.pnlFormLoader.Controls.Clear();
            frmTools frmTools_Vrb = new frmTools() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmTools_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmTools_Vrb);
            frmTools_Vrb.Show();
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            pnlNav.Height = SettingsBtn.Height;
            pnlNav.Top = SettingsBtn.Top;
            SettingsBtn.BackColor = Color.FromArgb(213, 232, 243);

            lblTitle.Text = "Settings";
            this.pnlFormLoader.Controls.Clear();
            frmSetttings frmSetttings_Vrb = new frmSetttings() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnlFormLoader.Controls.Add(frmSetttings_Vrb);
            frmSetttings_Vrb.Show();
        }

        private void HomeBtn_Leave(object sender, EventArgs e)
        {
            HomeBtn.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void AppsBtn_Leave(object sender, EventArgs e)
        {
            AppsBtn.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void GamesBtn_Leave(object sender, EventArgs e)
        {
            GamesBtn.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void ToolsBtn_Leave(object sender, EventArgs e)
        {
            ToolsBtn.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void SettingsBtn_Leave(object sender, EventArgs e)
        {
            SettingsBtn.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void fireDnl_Leave(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
