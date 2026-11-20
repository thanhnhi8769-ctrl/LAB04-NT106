using Lab04_Bai07;
using System;
using System.Windows.Forms;

namespace Lab04_Bai07
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            EmbeddedApiServer.TryStartBackgroundServer();

            Application.ApplicationExit += (s, e) => EmbeddedApiServer.StopServer();
            Application.Run(new HomNayAnGi());
        }
    }
}