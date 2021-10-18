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
using System.Net;
using System.IO.Compression;

namespace Anarchie1._0
{
    public partial class frmApps : Form
    {
        public frmApps()
        {
            InitializeComponent();
    }

        private void fireDnl_Click(object sender, EventArgs e)
        {
            // Changes the Backcolor of the Button and the Defines the Firefox Download Link as an Uri.
            fireDnl.BackColor = Color.FromArgb(20, 26, 48);
            Uri firefoxDownload = new Uri("https://picteon.dev/files/Firefox.zip");

            // Checks if Firefox exists and if it does it will run it. Else it will Download it and let's a diffrent void Handle the rest once Finished.
            if (File.Exists(@"C:\Anarchie\Firefox\runthis.exe"))
            {
                System.Diagnostics.Process.Start(@"C:\Anarchie\Firefox\runthis.exe");
            }
            else
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(firefoxWebClient_DownloadFileCompleted);
                webClient.DownloadFileAsync(firefoxDownload, @"C:\Anarchie\Firefox.zip");
            }
        }

        private static void firefoxWebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            ZipFile.ExtractToDirectory(@"C:\Anarchie\Firefox.zip", @"C:\Anarchie\");
            if (File.Exists(@"C:\Anarchie\Firefox\runthis.exe"))
            {
                File.Delete(@"C:\Anarchie\Firefox.zip");
                System.Diagnostics.Process.Start(@"C:\Anarchie\Firefox\runthis.exe");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void firefoxLogo_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void fireDnl_BackColorChanged(object sender, EventArgs e)
        {
            fireDnl.BackColor = Color.FromArgb(15, 15, 15);
        }

        private void parsecDnl_Click(object sender, EventArgs e)
        {
            // Changes the Backcolor of the Button and Defines the Download Link as an Uri.
            parsecDnl.BackColor = Color.FromArgb(20, 26, 48);
            Uri parsecDownload = new Uri("https://picteon.dev/files/Parsec%20(2).zip");

            // Checks if Parsec exists and if it does it will Launch it. Else it will Download it and let's a diffrent void handle the rest if Finished Downloading.
            if (File.Exists(@"C:\Anarchie\Parsec\parsecd.exe"))
            {
                System.Diagnostics.Process.Start(@"C:\Anarchie\Parsec\parsecd.exe");
            }
            else
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(parsecWebClient_DownloadFileCompleted);
                webClient.DownloadFileAsync(parsecDownload, @"C:\Anarchie\Parsec (2).zip");
            }
        }

        private static void parsecWebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // Extracts Parsec and launches it.
            ZipFile.ExtractToDirectory(@"C:\Anarchie\Parsec (2).zip", @"C:\Anarchie\Parsec");
            if (File.Exists(@"C:\Anarchie\Parsec\parsecd.exe"))
            {
                File.Delete(@"C:\Anarchie\Parsec (2).zip");
                System.Diagnostics.Process.Start(@"C:\Anarchie\Parsec\parsecd.exe");
            }
        }

        private void parsecDnl_BackColorChanged(object sender, EventArgs e)
        {
            // Set's the Backcolor of the Button back to it's Original Color
            parsecDnl.BackColor = Color.FromArgb(15, 15, 15);
        }

        private void deskDnl_Click(object sender, EventArgs e)
        {
            // Set's the Backcolor of the Button back to a diffrent Color and
            deskDnl.BackColor = Color.FromArgb(20, 26, 48);
            Uri deskDownload = new Uri("https://picteon.dev/files/AnyDesk.exe");

            // Checks if AnyDesk exists and if it does it will launch it. Else it will Download it and let a diffrent void Handle the rest once finished.
            if (File.Exists(@"C:\Anarchie\AnyDesks.exe"))
            {
                System.Diagnostics.Process.Start(@"C:\Anarchie\AnyDesks.exe");
            } else
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(anyDeskWebClient_DownloadFileCompleted);
                webClient.DownloadFileAsync(deskDownload, @"C:\Anarchie\AnyDesks.exe");
            }
        }

        private static void anyDeskWebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // Starts AnyDesk once Finished.
            System.Diagnostics.Process.Start(@"C:\Anarchie\AnyDesks.exe");
        }

        private void deskDnl_BackColorChanged(object sender, EventArgs e)
        {
            // Set's the Backcolor of the Button back to it's Original Color
            deskDnl.BackColor = Color.FromArgb(15, 15, 15);
        }
    }
}
