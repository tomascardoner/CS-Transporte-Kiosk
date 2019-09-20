using System;
using System.Windows.Forms;

namespace CSTransporteKiosko
{
    static class Program
    {
        /// <summary>
        /// Application for CS-Transporte Kiosko
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormWelcome());

            // Create forms
            FormWelcome welcome = new FormWelcome();
            FormSteps steps = new FormSteps();

            int pasoNumero = 0;

            do
            {
                if (pasoNumero == 0)
                {
                    welcome.Show();
                    steps.Hide();
                }
                else
                {
                    steps.Show();
                    welcome.Hide();
                }
            } while (pasoNumero >= 0);

            // Clean objects
            welcome.Dispose();
            steps.Dispose();
        }
    }
}
