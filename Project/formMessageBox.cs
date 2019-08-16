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
            this.BackColor = SetColor(configuracion.ValorMessageBoxBackColorAsColor, this.BackColor);

            labelMessage.ForeColor = SetColor(configuracion.ValorMessageBoxForeColorAsColor, labelMessage.ForeColor);
            labelMessage.Font = configuracion.ValorMessageBoxFontStyle;

            buttonSi.BackColor = SetColor(configuracion.ValorMessageBoxButtonBackColorAsColor, buttonSi.BackColor);
            buttonSi.ForeColor = SetColor(configuracion.ValorMessageBoxButtonForeColorAsColor, buttonSi.ForeColor);
            buttonSi.Font = configuracion.ValorMessageBoxButtonFontStyle;
            buttonSi.Visible = messageText.EndsWith("?");

            buttonAceptar.BackColor = SetColor(configuracion.ValorMessageBoxButtonBackColorAsColor, buttonAceptar.BackColor);
            buttonAceptar.ForeColor = SetColor(configuracion.ValorMessageBoxButtonForeColorAsColor, buttonAceptar.ForeColor);
            buttonAceptar.Font = configuracion.ValorMessageBoxButtonFontStyle;
            buttonAceptar.Visible = !messageText.EndsWith("?");

            buttonNo.BackColor = SetColor(configuracion.ValorMessageBoxButtonBackColorAsColor, buttonNo.BackColor);
            buttonNo.ForeColor = SetColor(configuracion.ValorMessageBoxButtonForeColorAsColor, buttonNo.ForeColor);
            buttonNo.Font = configuracion.ValorMessageBoxButtonFontStyle;
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
