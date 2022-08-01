using Microsoft.Win32;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace YouTubeDownload
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void cAppend(string message)
        {
            this.Invoke((Action)delegate
            {
                console.AppendText("\n" + message);
                console.ScrollToCaret();
            });
        }

        private void About_Load(object sender, EventArgs e)
        {          
            string Appversion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            cAppend(" Versión de la app: v" + Appversion);
            cAppend(" Versión de Windows: " + OSVersionInfo.Name);

            const string subkey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";
            using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey))
            {
                int releaseKey = Convert.ToInt32(ndpKey.GetValue("Release"));
                if (ndpKey != null && ndpKey.GetValue("Release") != null)
                {
                    cAppend(".NET Framework: v" + Interface.CheckFor48DotVersion(releaseKey));
                }
            }

            cAppend("\n\n App programada por Franco Mato 2022, utilizando librerías \n  * MediaToolkit MajorRefactoring (MOD) \n  * FFMPEG v5.1 \n  * VideoLibrary v3.1.9 \n  * AutoUpdater.NET v1.7.4 \n  * NiL.JS v2.5.1560");
        }
    }
}
