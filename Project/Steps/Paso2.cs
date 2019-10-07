using System;
using System.Windows.Forms;

namespace CSTransporteKiosko
{
    public partial class Paso2 : UserControl
    {
        bool buscarPorDocumento;

        public event EventHandler SearchButtonPressed;
        public string ValorIngresado { get => textboxValor.Text.Trim(); }

        public Paso2()
        {
            InitializeComponent();
        }

        public void SetAppearance(KioskoConfiguracion configuracion)
        {
            panelPaso2.BackColor = CardonerSistemas.Colors.SetColor(configuracion.ValorScreenBackColor, panelPaso2.BackColor);
            labelValor.ForeColor = CardonerSistemas.Colors.SetColor(configuracion.ValorInformacionPrincipalForeColor, labelValor.ForeColor);
            labelValor.Font = configuracion.ValorInformacionPrincipalFont;

            //textboxValor.BackColor = CardonerSistemas.Colors.SetColor(configuracion.ValorScreenBackColor, textboxValor.BackColor);
            //textboxValor.ForeColor =
            textboxValor.Font = configuracion.ValorInformacionPrincipalFont;

            buttonBuscar.Image = configuracion.ValorButtonBuscarImagen;
            buttonBuscar.Font = configuracion.ValorMessageBoxButtonFont;
            buttonBuscar.BackColor = CardonerSistemas.Colors.SetColor(configuracion.ValorMessageBoxButtonBackColor, buttonBuscar.BackColor);
            buttonBuscar.ForeColor = CardonerSistemas.Colors.SetColor(configuracion.ValorMessageBoxButtonForeColor, buttonBuscar.ForeColor);

            keyboardMain.Font = configuracion.ValorKeyboardFont;
        }

        public void PrepararParaMostrar(bool busquedaPorDocumento)
        {
            buscarPorDocumento = busquedaPorDocumento;
            if (buscarPorDocumento)
            {
                labelValor.Text = "Ingrese el Nº de Documento:";
                panelPaso2.SetColumnSpan(keyboardMain, 1);
                panelPaso2.SetColumn(keyboardMain, 2);
                keyboardMain.KeyboardLayout = CardonerSistemas.OnScreenKeyboard.KeyboardLayoutEnums.NumericCalculator;
            }
            else
            {
                labelValor.Text = "Ingrese el Nº de Reserva:";
                panelPaso2.SetColumn(keyboardMain, 1);
                panelPaso2.SetColumnSpan(keyboardMain, 2);
                keyboardMain.KeyboardLayout = CardonerSistemas.OnScreenKeyboard.KeyboardLayoutEnums.AlphanumericOnly;
            }
            textboxValor.Text = "";
        }

        public bool Verificar(ref FormMessageBox messageBox)
        {
            if (buscarPorDocumento)
            {
                if (textboxValor.Text.Trim().Length < 6)
                {
                    messageBox.Show("El Nº de Documento debe contener al menos 6 (seis) dígitos.");
                    return false;
                }
            }
            else
            {
                if (textboxValor.Text.Trim().Length < 8)
                {
                    messageBox.Show("Debe ingresar los 8 (ocho) caracteres del Nº de Reserva.");
                    return false;
                }
            }
            return true;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            SearchButtonPressed(this, e);
        }
    }
}
