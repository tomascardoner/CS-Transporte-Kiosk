using System;
using System.Windows.Forms;

namespace CSTransporteKiosk
{
    static class Program
    {
        /// <summary>
        /// Application for CS-Transporte Kiosk
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
