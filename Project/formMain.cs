using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CSTransporteKiosk
{
    public partial class formMain : Form
    {
        #region Declaraciones

        byte pasoActual = 0;
        Boolean buscarPorDocumento;

        DateTime logoFirstClickTime = new DateTime(0);
        DateTime logoSecondClickTime = new DateTime(0);
        #endregion

        #region Form stuff

          public formMain()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            DatabaseBusqueda.PrepararConexionABaseDeDatos();
            SetAppearance();
            MostrarPasos();
        }

        private void SetAppearance()
        {
            pictureboxLogoEmpresa.ImageLocation = Properties.Settings.Default.EmpresaLogotipo;
            wmInicio_Player.uiMode = "none";
            wmInicio_Player.URL = Properties.Settings.Default.EmpresaVideo;

            // Version del assembly
            labelPasosVersion.Text = CardonerSistemas.My.Application.Info.Version.ToString();
            pictureboxPasosLogoCompaniaSoftware.ImageLocation = Properties.Settings.Default.CompaniaSoftwareLogotipo;

            // Propiedades del teclado numérico en pantalla
            onscreenkeyboardDNI.Font = Properties.Settings.Default.KeyboardNumericNumberFont;
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (DatabaseBusqueda.Database != null)
                {
                    if (DatabaseBusqueda.Database.connection.State != System.Data.ConnectionState.Open)
                    {
                        DatabaseBusqueda.Database.connection.Close();
                    }
                }
            }
            catch (Exception) {}
            DatabaseBusqueda.Database = null;
        }

        #endregion

        #region Controls stuff

        private void KeyCombinationManager(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.X) || (e.Alt && e.KeyCode == Keys.X))  // Control + X or Alt + X
            {
                Application.Exit();
            }
        }

        private void wmPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 8)
            {
                wmInicio_Player.Ctlcontrols.stop();
                wmInicio_Player.Ctlcontrols.play();
            }
        }

        private void Click_ToStart()
        {
            if (pasoActual == 0)
            {
                if (wmInicio_Player.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    wmInicio_Player.Ctlcontrols.stop();
                }
            }
        }

        private void Click_ToStart(object sender, MouseEventArgs e)
        {
            Click_ToStart();
            AvanzarPaso();
        }

        private void Click_ToStart(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {
            Click_ToStart();
            AvanzarPaso();
        }

        private void ButtonPasoSiguiente_Click(object sender, EventArgs e)
        {
            AvanzarPaso();
        }

        private void ButtonPasoAnterior_Click(object sender, EventArgs e)
        {
            RetrocederPaso();
        }

        private void SoftwareCompanyClick(object sender, EventArgs e)
        {
            if (logoFirstClickTime.Ticks == 0)
            {
                logoFirstClickTime = DateTime.Now;
            }
            else
            {
                if (logoSecondClickTime.Ticks == 0)
                {

                }
            }
        }

        #endregion

        #region Verificación de Pasos

        private bool VerificarAvancePaso()
        {
            switch (pasoActual)
            {
                case 1: // Selección del tipo de búsqueda
                    return VerificarPaso1();

                case 2: // Introducción de los datos a buscar
                    return VerificarPaso2();

                default:
                    break;
            }
            return true;
        }

        private bool VerificarPaso1()
        {
            if (radioPaso1_Documento.Checked == false & radioPaso1_Reserva.Checked == false)
            {
                MessageBox.Show("Debe seleccionar alguna de las opciones de búsqueda.");
                return false;
            }
            return true;
        }

        private bool VerificarPaso2()
        {
            // Verificar datos ingresados
            if (buscarPorDocumento)
            {
                if (textboxPaso2_Valor.Text.Trim().Length < 6)
                {
                    MessageBox.Show("EL Nº de Documento debe contener al menos 6 (seis) dígitos.");
                    return false;
                }
            }
            else
            {
                if (textboxPaso2_Valor.Text.Trim().Length < 8)
                {
                    MessageBox.Show("Debe ingresar los 8 (ocho) caracteres del Nº de Reserva.");
                    return false;
                }
            }

            // Buscar datos en la base de datos
            DateTime fechaHora = new DateTime();
            string ruta = null;
            var personaList = new List<DatabaseBusqueda.Persona>();

            if (DatabaseBusqueda.BuscarViajesPorDocumento(textboxPaso2_Valor.Text.Trim(), ref fechaHora, ref ruta, personaList))
            {
                labelPaso3_ViajeFechaHora.Text = String.Format("{0} {1}", fechaHora.ToShortDateString(), fechaHora.ToShortTimeString());
                labelPaso3_ViajeRuta.Text = ruta;
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Avance de Pasos

        private void AvanzarPaso()
        {
            if (VerificarAvancePaso())
            {
                pasoActual++;
                MostrarPasos();
            }
        }

        private void RetrocederPaso()
        {
            pasoActual--;
            MostrarPasos();
        }

        private void MostrarPasos()
        {
            switch (pasoActual)
            {
                case 1:
                    MostrarPaso1();
                    break;
                case 2:
                    MostrarPaso2();
                    break;
                default:
                    break;
            }
            panelInicio.Visible = (pasoActual == 0);
            panelPasos.Visible = (pasoActual > 0);
            panelPaso1.Visible = (pasoActual == 1);
            panelPaso2.Visible = (pasoActual == 2);
            panelPaso3.Visible = (pasoActual == 3);
            buttonPasoAnterior.Visible = (pasoActual > 0);
            buttonPasoSiguiente.Visible = (pasoActual > 0);
        }

        private void MostrarPaso1()
        {
            radioPaso1_Documento.Checked = false;
            radioPaso1_Reserva.Checked = false;
        }

        private void MostrarPaso2()
        {
            buscarPorDocumento = (radioPaso1_Documento.Checked);
            if (buscarPorDocumento)
            {
                labelPaso2_Valor.Text = "Ingrese el Nº de Documento:";
            }
            else
            {
                labelPaso2_Valor.Text = "Ingrese el Nº de Reserva:";
            }
            textboxPaso2_Valor.Text = "";
        }

        #endregion
    }
}
