using MediaToolkit.Core.Utilities;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace YouTubeDownload
{
    public class Interface
    {

        static readonly string[] SizeSuffixes =
                  { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        public static string SizeSuffix(Int64 value, int decimalPlaces = 1)
        {
            if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if (value < 0) { return "-" + SizeSuffix(-value, decimalPlaces); }
            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }

            // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
            int mag = (int)Math.Log(value, 1024);

            // 1L << (mag * 10) == 2 ^ (10 * mag) 
            // [i.e. the number of bytes in the unit corresponding to mag]
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

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

        public static void IFNOT48()
        {
            try
            {
                const string subkey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";
                using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey))
                {
                    int releaseKey = Convert.ToInt32(ndpKey.GetValue("Release"));
                    if (ndpKey != null && ndpKey.GetValue("Release") != null)
                    {
                        if (CheckFor48DotVersion(releaseKey) != "4.8")
                        {
                            MessageBox.Show(".NET Framework: La versión no coincide con v4.8! \nInfo: " + CheckFor48DotVersion(releaseKey), "YoutubeDownload no podrá ejecutarse! Hasta que instale .NET Framework v4.8!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Process.Start("https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net48-web-installer");
                            Application.Exit();
                            return;
                        }
                    }
                    else
                    {
                        if (CheckFor48DotVersion(releaseKey) != "4.8")
                        {
                            MessageBox.Show(".NET Framework: Falta .NET Framework, o la versión instalada es inferior a v4.8! \nInfo: " + CheckFor48DotVersion(releaseKey), "YoutubeDownload no podrá ejecutarse! Hasta que instale .NET Framework v4.8!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Process.Start("https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net48-web-installer");
                            Application.Exit();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(".NET Framework ERROR" + ex.Message, "Problemas con .NET Framework", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.Start("https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net48-web-installer");
                Application.Exit();
                return;
            }
        }

        public static string CheckFor48DotVersion(int releaseKey)
        {
            if (releaseKey >= 528372)
            {
                return "4.8";
            }
            if (releaseKey >= 461808)
            {
                return "4.7.2";
            }
            if (releaseKey >= 461308)
            {
                return "4.7.1";
            }
            if (releaseKey >= 460798)
            {
                return "4.7";
            }
            if (releaseKey >= 394802)
            {
                return "4.6.2";
            }
            if (releaseKey >= 394254)
            {
                return "4.6.1";
            }
            if (releaseKey >= 393295)
            {
                return "4.6";
            }
            if (releaseKey >= 393273)
            {
                return "4.6 RC";
            }
            if ((releaseKey >= 379893))
            {
                return "4.5.2";
            }
            if ((releaseKey >= 378675))
            {
                return "4.5.1";
            }
            if ((releaseKey >= 378389))
            {
                return "4.5 or later";
            }
            Process.Start("https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net48-web-installer");
            return "No se detectó .NET 4.8 o una versión posterior. Por lo tanto, el programa no se iniciará. Por favor, si desea solucionar esto, instale .NET v4.8!";
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
    }
}
