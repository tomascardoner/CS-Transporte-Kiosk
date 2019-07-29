
namespace CSTransporteKiosk
{
    static class MessageBox
    {
        public static void Show(string messageText)
        {
            FormMessageBox messageBox = new FormMessageBox(messageText);
            messageBox.ShowDialog();
            messageBox = null;
        }

        public static bool ShowDialog(string messageText)
        {
            FormMessageBox messageBox = new FormMessageBox(messageText);
            messageBox.ShowDialog();
            bool dialogResult = (messageBox.DialogResult == System.Windows.Forms.DialogResult.Yes);
            messageBox = null;
            return dialogResult;
        }
    }
}
