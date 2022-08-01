using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace YouTubeDownload
{
    internal static class Program
    {
        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(int hWnd);

        [DllImport("User32.dll")]
        private static extern bool SetProcessDPIAware();     

        [STAThread]
        static void Main()
        {
            try
            {
                Interface.IFNOT48();

                if (!OSVersionInfo.Name.Equals("Windows 7") && !OSVersionInfo.Name.Equals("Windows 8") && !OSVersionInfo.Name.Equals("Windows 8.1") && !OSVersionInfo.Name.Equals("Windows 10") && !OSVersionInfo.Name.Equals("Windows 11"))
                {
                    MessageBox.Show("Su versión de Windows no es compatible con la versión que requiere el programa, usted tiene: " + OSVersionInfo.Name + "\nSe requiere una versión a partir de Windows 10!", "Problemas con la versión de Windows", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Interface.PanicKill();
                    return;
                }
             
                if (Environment.OSVersion.Version.Major >= 6)
                    SetProcessDPIAware();

                int process = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length;
                if (process > 1)
                {
                    SetForegroundWindow(process);
                    MessageBox.Show("Ya hay un proceso del Programa abierto!", "El programa ya está abierto!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch (Exception er)
            {
                MessageBox.Show("Error en el programa principal! \nDetalle: " + er.ToString(), "ERROR FATAL!", MessageBoxButtons.OK, MessageBoxIcon.Error); Interface.PanicKill();
                return;
            }
        }
    }
}
