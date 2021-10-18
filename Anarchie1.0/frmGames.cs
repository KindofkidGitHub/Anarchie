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

namespace Anarchie1._0
{
    public partial class frmGames : Form
    {
        public frmGames()
        {
            InitializeComponent();
        }

        private void minecraftDnl_Click(object sender, EventArgs e)
        {
            // Changes the Backcolor of the Download Button and Defines the Minecraft Download Link as an Uri
            minecraftDnl.BackColor = Color.FromArgb(20, 26, 48);
            Uri minecraftDownload = new Uri("https://launcher.mojang.com/download/Minecraft.exe");

            /* Checks if Minecraft exists and if it does it will Launch it. Else it will Download it and let a static void Handle the rest,
               once Finished */
            if (File.Exists(@"C:\Anarchie\Minecraft.exe"))
            {
                System.Diagnostics.Process.Start(@"C:\Anarchie\Minecraft.exe");
            }
            else
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(minecraftWebClient_DownloadFileCompleted);
                webClient.DownloadFileAsync(minecraftDownload, @"C:\Anarchie\Minecraft.exe");
            }
        }

        private static void minecraftWebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // Starts Minecraft once Finished Downloading
            System.Diagnostics.Process.Start(@"C:\Anarchie\Minecraft.exe");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Changes the Backcolor of the Download Button and Defines the Roblox Download Link as an Uri
            rblxDnl.BackColor = Color.FromArgb(20, 26, 48);
            Uri robloxDownload = new Uri("https://www.roblox.com/download/client");

            /* Checks if Roblox exists and if it does it will Launch it. Else it will Download it and let a static void Handle the rest,
               once Finished */
            if (File.Exists(@"C:\Anarchie\RobloxPlayerLauncher.exe"))
            {
                System.Diagnostics.Process.Start(@"C:\Anarchie\RobloxPlayerLauncher.exe");
            }
            else
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(robloxWebClient_DownloadFileCompleted);
                webClient.DownloadFileAsync(robloxDownload, @"C:\Anarchie\RobloxPlayerLauncher.exe");
            }
        }

        private static void robloxWebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // Starts Roblox if it's finished Donwloading.
            System.Diagnostics.Process.Start(@"C:\Anarchie\RobloxPlayerLauncher.exe");
        }

        private void minecraftDnl_BackColorChanged(object sender, EventArgs e)
        {
            // Changes the Backcolor of the Button back to it's Original Color
            minecraftDnl.BackColor = Color.FromArgb(15, 15, 15);
        }

        private void rblxDnl_BackColorChanged(object sender, EventArgs e)
        {
            // Changes the Backcolor of the Button back to it's Original Color
            rblxDnl.BackColor = Color.FromArgb(15, 15, 15);
        }
    }
}
