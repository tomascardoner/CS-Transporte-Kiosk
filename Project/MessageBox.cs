
namespace CSTransporteKiosko
{
    static class MessageBox
    {
        public static void Show(string messageText, KioskoConfiguracion configuracion)
        {
            FormMessageBox messageBox = new FormMessageBox(messageText, configuracion);
            messageBox.ShowDialog();
            messageBox = null;
        }

        public static bool ShowDialog(string messageText, KioskoConfiguracion configuracion)
        {
            FormMessageBox messageBox = new FormMessageBox(messageText, configuracion);
            messageBox.ShowDialog();
            bool dialogResult = (messageBox.DialogResult == System.Windows.Forms.DialogResult.Yes);
            messageBox = null;
            return dialogResult;
        }
    }
}
