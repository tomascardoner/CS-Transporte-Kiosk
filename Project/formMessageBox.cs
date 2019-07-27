using System.Windows.Forms;

namespace CSTransporteKiosk
{
    public partial class FormMessageBox : Form
    {
        public FormMessageBox()
        {
            InitializeComponent();

            setAppearance();
        }

        public FormMessageBox(string messageText)
        {
            InitializeComponent();

            setAppearance();

            labelMessage.Text = messageText;
        }

        void setAppearance()
        {
            this.BackColor = Properties.Settings.Default.MessageBoxBackColor;

            labelMessage.ForeColor = Properties.Settings.Default.MessageBoxForeColor;
            labelMessage.Font = Properties.Settings.Default.FontStyle;

            buttonAceptar.BackColor = Properties.Settings.Default.MessageBoxButtonBackColor;
            buttonAceptar.ForeColor = Properties.Settings.Default.MessageBoxButtonForeColor;
            buttonAceptar.Font = Properties.Settings.Default.FontStyle;
        }

        private void buttonAceptar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
