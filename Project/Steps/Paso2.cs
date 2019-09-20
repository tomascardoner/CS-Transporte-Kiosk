using System.Windows.Forms;

namespace CSTransporteKiosko
{
    public partial class Paso2 : UserControl
    {
        public Paso2()
        {
            InitializeComponent();
        }

        public void SetAppearance(KioskoConfiguracion configuracion)
        {
            // Apariencia
            panelPaso2.BackColor = CardonerSistemas.Colors.SetColor(configuracion.ValorScreenBackColor, panelPaso2.BackColor);
            labelValor.ForeColor = CardonerSistemas.Colors.SetColor(configuracion.ValorInformacionPrincipalForeColor, labelValor.ForeColor);
            labelValor.Font = configuracion.ValorInformacionPrincipalFont;

            //textboxValor.BackColor = CardonerSistemas.Colors.SetColor(configuracion.ValorScreenBackColor, textboxValor.BackColor);
            //textboxValor.ForeColor =
            textboxValor.Font = configuracion.ValorInformacionPrincipalFont;

            keyboardMain.Font = configuracion.ValorKeyboardFont;
        }
    }
}
