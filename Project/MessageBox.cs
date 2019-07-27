
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
    }
}
