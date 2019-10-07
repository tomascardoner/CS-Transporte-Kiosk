using System;
using System.Windows.Forms;

namespace CSTransporteKiosko
{
    public partial class Paso1 : UserControl
    {
        public event EventHandler TipoBusquedaCambiada;
        public  bool BusquedaPorDocumento { get => radioDocumento.Checked; }

        public Paso1()
        {
            InitializeComponent();
        }

        public void SetAppearance(KioskoConfiguracion configuracion)
        {
            panelPaso1.BackColor = CardonerSistemas.Colors.SetColor(configuracion.ValorScreenBackColor, BackColor);

            radioDocumento.BackColor = CardonerSistemas.Colors.SetColor(configuracion.ValorButtonTipoBusquedaBackColor, radioDocumento.BackColor);
            radioDocumento.ForeColor = CardonerSistemas.Colors.SetColor(configuracion.ValorButtonTipoBusquedaForeColor, radioDocumento.ForeColor);
            radioDocumento.Font = configuracion.ValorButtonTipoBusquedaFont;

            radioReserva.BackColor = radioDocumento.BackColor;
            radioReserva.ForeColor = radioDocumento.ForeColor;
            radioReserva.Font = radioDocumento.Font;
        }

        public void PrepararParaMostrar()
        {
            radioDocumento.Checked = false;
            radioReserva.Checked = false;
        }

        public bool Verificar(ref FormMessageBox messageBox)
        {
            if (radioDocumento.Checked || radioReserva.Checked)
            {
                return true;
            }
            else
            {
                messageBox.Show("Debe seleccionar alguna de las opciones de búsqueda.");
                return false;
            }
        }

        private void OpcionSeleccionada(object sender, System.EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (TipoBusquedaCambiada != null && radioButton.Checked)
            {
                TipoBusquedaCambiada(this, e);
            }
        }
    }
}
