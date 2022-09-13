using System.Reflection;

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

            cAppend("\n\n App programada por @Franco28 2022, utilizando librerías \n  * MediaToolkit MajorRefactoring (MOD) \n  * FFMPEG v5.1 \n  * VideoLibrary v3.1.9 \n  * AutoUpdater.NET v1.7.4 \n  * NiL.JS v2.5.1560 \n  * TagLib v2.3.0");
        }
    }
}
