using System.Windows.Forms;

namespace CSTransporteKiosko
{
    public partial class Paso1 : UserControl
    {
        public  bool BusquedaPorDocumento { get => radioDocumento.Checked; }

        public Paso1()
        {
            InitializeComponent();
        }

        public void SetAppearance(KioskoConfiguracion configuracion)
        {
            panelPaso1.BackColor = CardonerSistemas.Colors.SetColor(configuracion.ValorScreenBackColor, BackColor);

            radioDocumento.BackColor = CardonerSistemas.Colors.SetColor(configuracion.ValorInformacionPrincipalForeColor, radioDocumento.BackColor);
            radioDocumento.ForeColor = CardonerSistemas.Colors.SetColor(configuracion.ValorInformacionPrincipalForeColor, radioDocumento.ForeColor);
            radioDocumento.Font = configuracion.ValorInformacionPrincipalFont;

            radioReserva.BackColor = radioDocumento.BackColor;
            radioReserva.ForeColor = radioDocumento.ForeColor;
            radioReserva.Font = configuracion.ValorInformacionPrincipalFont;
        }

        public void PrepararParaMostrar()
        {
            radioDocumento.Checked = false;
            radioReserva.Checked = false;
        }

        public bool Verificar(ref FormMessageBox messageBox)
        {
            if (radioDocumento.Checked | radioReserva.Checked)
            {
                return true;
            }
            else
            {
                messageBox.Show("Debe seleccionar alguna de las opciones de búsqueda.");
                return false;
            }
        }
    }
}
