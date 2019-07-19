using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CSTransporteKiosk
{
    public partial class formMain : Form
    {
        #region Declaraciones
        byte pasoActual = 0;
        Boolean buscarPorDocumento;

        CardonerSistemas.Database_ADO_SQLServer mDatabase;

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
            PrepararConexionABaseDeDatos();
            SetAppearance();
            MostrarPasos();
        }

        private void PrepararConexionABaseDeDatos()
        {
            mDatabase = new CardonerSistemas.Database_ADO_SQLServer();
            mDatabase.applicationName = CardonerSistemas.My.Application.Info.Title;
            mDatabase.datasource = ThisMachine.Default.DatabaseDatasource;
            mDatabase.initialCatalog = ThisMachine.Default.DatabaseDatabase;
            mDatabase.userID = ThisMachine.Default.DatabaseUserID;
            if (ThisMachine.Default.DatabasePassword.Trim().Length == 0)
            {
                mDatabase.password = "";
            }
            else
            {
                CardonerSistemas.Encrypt_TripleDES decrypter = new CardonerSistemas.Encrypt_TripleDES(CardonerSistemas.Constants.PublicEncryptionPassword);
                string decryptedPassword = "";
                if (decrypter.Decrypt(ThisMachine.Default.DatabasePassword, ref decryptedPassword))
                {
                    mDatabase.password = decryptedPassword;
                }
                decrypter = null;
            }
            mDatabase.workstationID = "";
            mDatabase.CreateConnectionString();
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
                if (mDatabase.connection.State != System.Data.ConnectionState.Open)
                {
                    mDatabase.connection.Close();
                    mDatabase = null;
                }
            }
            catch (Exception)
            {
                mDatabase = null;
            }
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
            if (BuscarViajesPorDocumento())
            {
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

        #region Database stuff

        private bool ConnectToDatabase()
        {
            if (mDatabase.connection == null || mDatabase.connection.State != System.Data.ConnectionState.Open)
            {
                return mDatabase.Connect();
            }
            else
            {
                return true;
            }
        }

        private bool BuscarViajesPorDocumento()
        {
            int IDViaje = 0;
            int IDViajeDetalle = 0;
            string ReservaCodigo = null;
            byte GrupoNumero = 0;

            if (ConnectToDatabase())
            {
                if (BuscarReservasPorDocumento(ref IDViaje, ref IDViajeDetalle, ref ReservaCodigo, ref GrupoNumero))
                {
                    if (BuscarPersonasPorReserva(IDViaje, IDViajeDetalle, ReservaCodigo, GrupoNumero))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool BuscarReservasPorDocumento(ref int IDViaje, ref int IDViajeDetalle, ref string ReservaCodigo, ref byte GrupoNumero)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader sqlDataReader;

            try
            {
                sqlCommand.Connection = mDatabase.connection;
                sqlCommand.CommandText = "usp_ReservasPorDocumento";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@IDLugar", ThisMachine.Default.LugarID);
                sqlCommand.Parameters.AddWithValue("@LugarDuracionPreviaMaxima", Properties.Settings.Default.LugarDuracionPreviaMaxima);
                sqlCommand.Parameters.AddWithValue("@LugarDuracionPreviaMinima", Properties.Settings.Default.LugarDuracionPreviaMinima);
                sqlCommand.Parameters.AddWithValue("@DocumentoNumero", textboxPaso2_Valor.Text.Trim());

                sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleRow);
                sqlCommand.Dispose();
                sqlCommand = null;

                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Read();
                    DateTime dtFechaHora = sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("FechaHora"));
                    labelPaso3_ViajeFechaHora.Text = String.Format("{0} {1}", dtFechaHora.ToShortDateString(), dtFechaHora.ToShortTimeString());
                    labelPaso3_ViajeRuta.Text = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Ruta"));

                    IDViaje = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("IDViaje"));
                    IDViajeDetalle = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("IDViajeDetalle"));
                    ReservaCodigo = sqlDataReader.GetString(sqlDataReader.GetOrdinal("ReservaCodigo"));
                    GrupoNumero = sqlDataReader.GetByte(sqlDataReader.GetOrdinal("GrupoNumero"));

                    sqlDataReader.Close();
                    sqlDataReader = null;

                    return true;
                }
                else
                {
                    MessageBox.Show("No se han encontrado reservas.");

                    sqlDataReader.Close();
                    sqlDataReader = null;

                    return false;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo obtener la información.");

                sqlCommand = null;

                sqlDataReader = null;

                return false;
            }
        }

        private bool BuscarPersonasPorReserva(int IDViaje, int IDViajeDetalle, string ReservaCodigo, byte GrupoNumero)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader sqlDataReader;

            try
            {
                sqlCommand.Connection = mDatabase.connection;
                sqlCommand.CommandText = "usp_PersonasPorReserva";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@IDViaje", IDViaje);
                sqlCommand.Parameters.AddWithValue("@IDViajeDetalle", IDViajeDetalle);
                sqlCommand.Parameters.AddWithValue("@ReservaCodigo", ReservaCodigo);
                sqlCommand.Parameters.AddWithValue("@GrupoNumero", GrupoNumero);

                sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult);
                sqlCommand.Dispose();
                sqlCommand = null;

                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Read();
                    DateTime dtFechaHora = sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("FechaHora"));
                    labelPaso3_ViajeFechaHora.Text = String.Format("{0} {1}", dtFechaHora.ToShortDateString(), dtFechaHora.ToShortTimeString());
                    labelPaso3_ViajeRuta.Text = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Ruta"));

                    sqlDataReader.Close();
                    sqlDataReader = null;

                    return true;
                }
                else
                {
                    MessageBox.Show("No se han encontrado reservas.");

                    sqlDataReader.Close();
                    sqlDataReader = null;

                    return false;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo obtener la información.");

                sqlCommand = null;

                sqlDataReader = null;

                return false;
            }
        }

        #endregion
    }
}
