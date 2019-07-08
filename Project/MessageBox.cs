
namespace CSTransporteKiosk
{
    static class MessageBox
    {
        public static void Show(string messageText)
        {
            formMessageBox messageBox = new formMessageBox(messageText);
            messageBox.ShowDialog();
            messageBox = null;
        }
    }
}
