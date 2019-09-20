using System.Windows.Forms;

namespace CSTransporteKiosko
{
    public partial class Paso1 : UserControl
    {
        public Paso1()
        {
            InitializeComponent();
        }

        public void SetAppearance(KioskoConfiguracion configuracion)
        {
            // Apariencia
            panelPaso1.BackColor = CardonerSistemas.Colors.SetColor(configuracion.ValorScreenBackColor, BackColor);

            radioDocumento.BackColor = CardonerSistemas.Colors.SetColor(configuracion.ValorInformacionPrincipalForeColor, radioDocumento.BackColor);
            radioDocumento.ForeColor = CardonerSistemas.Colors.SetColor(configuracion.ValorInformacionPrincipalForeColor, radioDocumento.ForeColor);
            radioDocumento.Font = configuracion.ValorInformacionPrincipalFont;

            radioReserva.BackColor = CardonerSistemas.Colors.SetColor(configuracion.ValorInformacionPrincipalForeColor, radioReserva.BackColor);
            radioReserva.ForeColor = CardonerSistemas.Colors.SetColor(configuracion.ValorInformacionPrincipalForeColor, radioReserva.ForeColor);
            radioReserva.Font = configuracion.ValorInformacionPrincipalFont;
        }
    }
}
