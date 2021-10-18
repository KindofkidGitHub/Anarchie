using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;


namespace Anarchie1._0
{
    public partial class frmTools : Form
    {
        public frmTools()
        {
            InitializeComponent();
        }

        private void fireDnl_Click(object sender, EventArgs e)
        {
            // Changes the Backcolor of the Button and Defines the Download Link for Explorer++ as an Uri
            fireDnl.BackColor = Color.FromArgb(20, 26, 48);
            Uri explorerDownload = new Uri("https://picteon.dev/files/Explorer++.exe");

            if (File.Exists(@"C:\Anarchie\notexplorer.exe"))
            {
                System.Diagnostics.Process.Start(@"C:\Anarchie\notexplorer.exe");
            } else
            {      
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(explorerWebClient_DownloadFileCompleted);
                webClient.DownloadFileAsync(explorerDownload, @"C:\Anarchie\notexplorer.exe");
            }
        }

        private static void explorerWebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // Starts Explorer++ once finished Downloading.
            System.Diagnostics.Process.Start(@"C:\Anarchie\notexplorer.exe");
        }

        private void fireDnl_BackColorChanged(object sender, EventArgs e)
        {
            // Changes the Backcolor of the Download Button to it's Original Color
            fireDnl.BackColor = Color.FromArgb(15, 15, 15);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Changes the Backcolor of the Button and then defines the Process Hacker Download Link as an Uri
            button1.BackColor = Color.FromArgb(20, 26, 48);
            Uri processHackerDownload = new Uri("https://picteon.dev/files/proshac.zip");

            // Checks if proshac.exe exists and Launches it if it does. Else it will Download it.
            if (File.Exists(@"C:\Anarchie\proshac\proshac.exe"))
            {
                System.Diagnostics.Process.Start(@"C:\Anarchie\proshac\proshac.exe");
            } else
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(processHackerWebClient_DownloadFileCompleted);
                webClient.DownloadFileAsync(processHackerDownload, @"C:\Anarchie\proshac.zip");
            }
        }

        private static void processHackerWebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //Extracts Process Hacker to C:\Anarchie if it's Finished Downloading and then launches proshac.exe once it exists in a Folder.
            ZipFile.ExtractToDirectory(@"C:\Anarchie\proshac.zip", @"C:\Anarchie\");
            if (File.Exists(@"C:\Anarchie\proshac\proshac.exe"))
            {
                File.Delete(@"C:\Anarchie\proshac.zip");
                System.Diagnostics.Process.Start(@"C:\Anarchie\proshac\proshac.exe");
            }
        }

        private void peaDnl_Click(object sender, EventArgs e)
        {
            // Changes the Backcolor of the Button and Defines the PeaZip Download Link as an Uri
            peaDnl.BackColor = Color.FromArgb(20, 26, 48);
            Uri peaZipDownload = new Uri("https://picteon.dev/files/PeaZip.zip");

            if (File.Exists(@"C:\Anarchie\PeaZip\peazipy.exe"))
            {
                // If PeaZip exists as peazipy.exe it launches it-
                System.Diagnostics.Process.Start(@"C:\Anarchie\PeaZip\peazipy.exe");
            } else if (File.Exists(@"C:\Anarchie\PeaZip\peazip.exe"))
            {
                // If PeaZip exists but isn't renamed as peazipy.exe then it will rename it to peazipy.exe and launch it.
                File.Move(@"C:\Anarchie\PeaZip\peazip.exe", @"C:\Anarchie\PeaZip\peazipy.exe");
                System.Diagnostics.Process.Start(@"C:\Anarchie\PeaZip\peazipy.exe");
            } else
            {
                // If PeaZip isn't Downloaded at all it will Download it and then have peaZipWebClient_DownloadFileCompleted handle the stuff once Completed.
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(peaZipWebClient_DownloadFileCompleted);
                webClient.DownloadFileAsync(peaZipDownload, @"C:\Anarchie\PeaZip.zip");
            }
        }

        private static void peaZipWebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // Extracts PeaZip to C:\Anarchie, renames peazip.exe to peazipy.exe and then launches it.
            ZipFile.ExtractToDirectory(@"C:\Anarchie\PeaZip.zip", @"C:\Anarchie\");
            if (File.Exists(@"C:\Anarchie\PeaZip\peazip.exe"))
            {
                File.Delete(@"C:\Anarchie\PeaZip.zip");
                File.Move(@"C:\Anarchie\PeaZip\peazip.exe", @"C:\Anarchie\PeaZip\peazipy.exe");
                System.Diagnostics.Process.Start(@"C:\Anarchie\PeaZip\peazipy.exe");
            }
        }

        private void peaDnl_BackColorChanged(object sender, EventArgs e)
        {
            // Changes the Button Backcolor when Pressed.
            peaDnl.BackColor = Color.FromArgb(15, 15, 15);
        }

        private void button1_BackColorChanged(object sender, EventArgs e)
        {
            // Changes the Button Backcolor once Pressed.
            button1.BackColor = Color.FromArgb(15, 15, 15);
        }
    }
}
