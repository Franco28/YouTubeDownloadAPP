using MediaToolkit;
using MediaToolkit.Core.Utilities;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace YouTubeDownloadAppNET.Class
{
    public class MainClass
    {

        private static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        public static string SizeSuffix(long value, int decimalPlaces = 1)
        {
            if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if (value < 0) { return "-" + SizeSuffix(-value, decimalPlaces); }
            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }

            // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
            int mag = (int)Math.Log(value, 1024);

            // 1L << (mag * 10) == 2 ^ (10 * mag) 
            // [i.e. the number of bytes in the unit corresponding to mag]
            decimal adjustedSize = (decimal)value / (1L << mag * 10);

            // make adjustment when the value is large enough that
            // it would round up to 1000 or more
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SizeSuffixes[mag]);
        }

        public static void PanicKill()
        {
            Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName)
                       .ForEach(process =>
                       {
                           process.Kill();
                           process.WaitForExit();
                       });
        }

        public static bool CheckConnectivity(int timeout_per_host_millis = 1000, string[] hosts_to_ping = null)
        {
            bool network_available = NetworkInterface.GetIsNetworkAvailable();

            if (network_available)
            {
                string[] hosts = hosts_to_ping ?? new string[] { "www.google.com", "www.facebook.com" };
                Ping p = new Ping();

                foreach (string host in hosts)
                {
                    try
                    {
                        PingReply r = p.Send(host, timeout_per_host_millis);
                        if (r.Status == IPStatus.Success)
                            return true;
                    }
                    catch { }
                }
            }
            return false;
        }

        public static void ExtractLibFiles()
        {
            try
            {
                var en = new Engine();
                en.Dispose();
            }
            catch (Exception er)
            {
                MessageBox.Show("Error con la librería de audio! \n\nDetalle: " + er.StackTrace, "ERROR AUDIO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PanicKill();
            }
        }
    }
}
