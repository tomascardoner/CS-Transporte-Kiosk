using System.Windows.Forms;

namespace CSTransporteKiosk
{
    public partial class FormMessageBox : Form
    {
        public FormMessageBox()
        {
            InitializeComponent();

            setAppearance("");
        }

        public FormMessageBox(string messageText)
        {
            InitializeComponent();

            setAppearance(messageText);

            labelMessage.Text = messageText;
        }

        void setAppearance(string messageText)
        {
            this.BackColor = Properties.Settings.Default.MessageBoxBackColor;

            labelMessage.ForeColor = Properties.Settings.Default.MessageBoxForeColor;
            labelMessage.Font = Properties.Settings.Default.FontStyle;

            buttonSi.BackColor = Properties.Settings.Default.MessageBoxButtonBackColor;
            buttonSi.ForeColor = Properties.Settings.Default.MessageBoxButtonForeColor;
            buttonSi.Font = Properties.Settings.Default.FontStyle;
            buttonSi.Visible = messageText.EndsWith("?");

            buttonAceptar.BackColor = Properties.Settings.Default.MessageBoxButtonBackColor;
            buttonAceptar.ForeColor = Properties.Settings.Default.MessageBoxButtonForeColor;
            buttonAceptar.Font = Properties.Settings.Default.FontStyle;
            buttonAceptar.Visible = !messageText.EndsWith("?");

            buttonNo.BackColor = Properties.Settings.Default.MessageBoxButtonBackColor;
            buttonNo.ForeColor = Properties.Settings.Default.MessageBoxButtonForeColor;
            buttonNo.Font = Properties.Settings.Default.FontStyle;
            buttonNo.Visible = messageText.EndsWith("?");
        }

        private void buttonAceptar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void ButtonSi_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void ButtonNo_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
