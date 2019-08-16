using System.Drawing;
using System.Windows.Forms;

namespace CSTransporteKiosko
{
    public partial class FormMessageBox : Form
    {
        public FormMessageBox()
        {
            InitializeComponent();
        }

        public FormMessageBox(string messageText, KioskoConfiguracion configuracion)
        {
            InitializeComponent();

            setAppearance(messageText, configuracion);

            labelMessage.Text = messageText;
        }

        void setAppearance(string messageText, KioskoConfiguracion configuracion)
        {
            this.BackColor = SetColor(configuracion.ValorMessageBoxBackColor, this.BackColor);

            labelMessage.ForeColor = SetColor(configuracion.ValorMessageBoxForeColor, labelMessage.ForeColor);
            labelMessage.Font = configuracion.ValorMessageBoxFont;

            buttonSi.BackColor = SetColor(configuracion.ValorMessageBoxButtonBackColor, buttonSi.BackColor);
            buttonSi.ForeColor = SetColor(configuracion.ValorMessageBoxButtonForeColor, buttonSi.ForeColor);
            buttonSi.Font = configuracion.ValorMessageBoxButtonFont;
            buttonSi.Visible = messageText.EndsWith("?");

            buttonAceptar.BackColor = SetColor(configuracion.ValorMessageBoxButtonBackColor, buttonAceptar.BackColor);
            buttonAceptar.ForeColor = SetColor(configuracion.ValorMessageBoxButtonForeColor, buttonAceptar.ForeColor);
            buttonAceptar.Font = configuracion.ValorMessageBoxButtonFont;
            buttonAceptar.Visible = !messageText.EndsWith("?");

            buttonNo.BackColor = SetColor(configuracion.ValorMessageBoxButtonBackColor, buttonNo.BackColor);
            buttonNo.ForeColor = SetColor(configuracion.ValorMessageBoxButtonForeColor, buttonNo.ForeColor);
            buttonNo.Font = configuracion.ValorMessageBoxButtonFont;
            buttonNo.Visible = messageText.EndsWith("?");
        }

        private Color SetColor(Color? colorNuevo, Color colorPredeterminado)
        {
            if (colorNuevo.HasValue)
            {
                return colorNuevo.Value;
            }
            else
            {
                return colorPredeterminado;
            }
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
