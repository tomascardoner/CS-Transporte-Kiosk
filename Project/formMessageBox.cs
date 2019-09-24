using CardonerSistemas;
using System.Windows.Forms;

namespace CSTransporteKiosko
{
    public partial class FormMessageBox : Form
    {
        public FormMessageBox()
        {
            InitializeComponent();
        }

        public void SetAppearance(KioskoConfiguracion configuracion)
        {
            BackColor = Colors.SetColor(configuracion.ValorMessageBoxBackColor, this.BackColor);

            labelMessage.ForeColor = Colors.SetColor(configuracion.ValorMessageBoxForeColor, labelMessage.ForeColor);
            labelMessage.Font = configuracion.ValorMessageBoxFont;

            buttonSi.BackColor = Colors.SetColor(configuracion.ValorMessageBoxButtonBackColor, buttonSi.BackColor);
            buttonSi.ForeColor = Colors.SetColor(configuracion.ValorMessageBoxButtonForeColor, buttonSi.ForeColor);
            buttonSi.Font = configuracion.ValorMessageBoxButtonFont;

            buttonAceptar.BackColor = buttonSi.BackColor;
            buttonAceptar.ForeColor = buttonSi.ForeColor;
            buttonAceptar.Font = configuracion.ValorMessageBoxButtonFont;

            buttonNo.BackColor = buttonSi.BackColor;
            buttonNo.ForeColor = buttonSi.ForeColor;
            buttonNo.Font = configuracion.ValorMessageBoxButtonFont;
        }

        public DialogResult Show(string messageText)
        {
            labelMessage.Text = messageText;
            buttonSi.Visible = messageText.EndsWith("?");
            buttonAceptar.Visible = !messageText.EndsWith("?");
            buttonNo.Visible = messageText.EndsWith("?");
            return this.ShowDialog();
        }

        private void ButtonClick(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
