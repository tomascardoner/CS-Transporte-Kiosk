using System.Windows.Forms;

namespace CSTransporteKiosk
{
    public partial class formMessageBox : Form
    {
        public formMessageBox()
        {
            InitializeComponent();

            setAppearance();
        }

        public formMessageBox(string messageText)
        {
            InitializeComponent();

            setAppearance();

            labelMessage.Text = messageText;
        }

        void setAppearance()
        {
            this.BackColor = My.Settings.MessageBoxBackColor;

            labelMessage.ForeColor = My.Settings.MessageBoxForeColor;
            labelMessage.Font = My.Settings.FontStyle;

            buttonAceptar.BackColor = My.Settings.MessageBoxButtonBackColor;
            buttonAceptar.ForeColor = My.Settings.MessageBoxButtonForeColor;
            buttonAceptar.Font = My.Settings.FontStyle;
        }

        private void buttonAceptar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
