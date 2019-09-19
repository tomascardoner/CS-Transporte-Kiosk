using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using C1.Win.C1Tile;
using CardonerSistemas.Database.ADO;
using CardonerSistemas.PointOfSale;

namespace CSTransporteKiosko
{
    public partial class FormMain : Form
    {
        #region Declaraciones

        // Variables internas
        private byte pasoActual = 0;
        private Boolean buscarPorDocumento;
        private int InactivityTimeoutSeconds;
        private DateTime inactivityTimeout = new DateTime(0);
        private DateTime logoFirstClickTime = new DateTime(0);
        private DateTime logoSecondClickTime = new DateTime(0);

        // Bases de datos y entidades
        private SQLServer dbLocal = new SQLServer();
        private SQLServer dbEmpresa = new SQLServer();
        private Kiosko kiosko = new Kiosko();
        private BusquedaReservas busquedaReservas = new BusquedaReservas();
        private VehiculoConfiguracion _VehiculoConfiguracion = new VehiculoConfiguracion();
        private Viaje _Viaje = new Viaje();
        private TicketPlantilla ticket = new TicketPlantilla();

        // Reservas
        private short LugarDuracionPreviaMinimaMinutos;
        private short LugarDuracionPreviaMaximaMinutos;
        private List<BusquedaReservas.Persona> listPersonasEncontradas = new List<BusquedaReservas.Persona>();
        private List<BusquedaReservas.Persona> listPersonasSeleccionadas = new List<BusquedaReservas.Persona>();

        // Asientos
        private const string SeatNamePrefix = "buttonSeat";
        private const string SeatNameRowPrefix = "R";
        private const string SeatNameColumnPrefix = "C";
        private TableLayoutPanel _panelSeatLayout;
        private class SeatRowAndCol
        {
            public int Row;
            public int Column;
        }
        private Dictionary<string, SeatRowAndCol> _seatsMap = new Dictionary<string, SeatRowAndCol>();
        private int _SeatsSelected = 0;

        // Ticket
        private Printer printer = new Printer();

        #endregion

        #region Form stuff

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (!InicializarKiosko())
            {
                Application.Exit();
                return;
            }
            ConfigAndSetAppearance();
            MostrarPasos();
        }

        private void ConfigAndSetAppearance()
        {
            // Form appearance and version info
            this.Icon = Properties.Resources.ICON_APP;
            labelPasosVersion.Text = Application.ProductVersion;

            // Media
            pictureboxPasosLogoCompaniaSoftware.Image = kiosko.KioskoConfiguracion.ValorCompaniaSoftwareLogotipo;
            pictureboxLogoEmpresa.Image = kiosko.KioskoConfiguracion.ValorEmpresaLogotipo;
            wmInicio_Player.uiMode = "none";
            wmInicio_Player.URL = kiosko.KioskoConfiguracion.ValorVideo;

            // Apariencia
            this.BackColor = SetColor(kiosko.KioskoConfiguracion.ValorScreenBackColor, this.BackColor);

            // Textos
            labelPaso2_Valor.Font = kiosko.KioskoConfiguracion.ValorInformacionLeyendaFont;
            labelPaso2_Valor.ForeColor = SetColor(kiosko.KioskoConfiguracion.ValorInformacionLeyendaForeColor, labelPaso2_Valor.ForeColor);

            labelPaso3_Viaje_Origen_Leyenda.Font = kiosko.KioskoConfiguracion.ValorInformacionLeyendaFont;
            labelPaso3_Viaje_Origen_Leyenda.ForeColor = SetColor(kiosko.KioskoConfiguracion.ValorInformacionLeyendaForeColor, labelPaso3_Viaje_Origen_Leyenda.ForeColor);
            labelPaso3_Viaje_Destino_Leyenda.Font = kiosko.KioskoConfiguracion.ValorInformacionLeyendaFont;
            labelPaso3_Viaje_Destino_Leyenda.ForeColor = SetColor(kiosko.KioskoConfiguracion.ValorInformacionLeyendaForeColor, labelPaso3_Viaje_Destino_Leyenda.ForeColor);
            labelPaso3_Viaje_Vehiculo_Leyenda.Font = kiosko.KioskoConfiguracion.ValorInformacionLeyendaFont;
            labelPaso3_Viaje_Vehiculo_Leyenda.ForeColor = SetColor(kiosko.KioskoConfiguracion.ValorInformacionLeyendaForeColor, labelPaso3_Viaje_Vehiculo_Leyenda.ForeColor);

            labelPaso3_Viaje_Origen_Lugar.Font = kiosko.KioskoConfiguracion.ValorInformacionPrincipalFont;
            labelPaso3_Viaje_Origen_Lugar.ForeColor = SetColor(kiosko.KioskoConfiguracion.ValorInformacionPrincipalForeColor, labelPaso3_Viaje_Origen_Lugar.ForeColor);
            labelPaso3_Viaje_Destino_Lugar.Font = kiosko.KioskoConfiguracion.ValorInformacionPrincipalFont;
            labelPaso3_Viaje_Destino_Lugar.ForeColor = SetColor(kiosko.KioskoConfiguracion.ValorInformacionPrincipalForeColor, labelPaso3_Viaje_Destino_Lugar.ForeColor);
            labelPaso3_Viaje_Vehiculo.Font = kiosko.KioskoConfiguracion.ValorInformacionPrincipalFont;
            labelPaso3_Viaje_Vehiculo.ForeColor = SetColor(kiosko.KioskoConfiguracion.ValorInformacionPrincipalForeColor, labelPaso3_Viaje_Vehiculo.ForeColor);

            labelPaso3_Viaje_Origen_FechaHora.Font = kiosko.KioskoConfiguracion.ValorInformacionSecundariaFont;
            labelPaso3_Viaje_Origen_FechaHora.ForeColor = SetColor(kiosko.KioskoConfiguracion.ValorInformacionSecundariaForeColor, labelPaso3_Viaje_Origen_FechaHora.ForeColor);
            labelPaso3_Viaje_Destino_FechaHora.Font = kiosko.KioskoConfiguracion.ValorInformacionSecundariaFont;
            labelPaso3_Viaje_Destino_FechaHora.ForeColor = SetColor(kiosko.KioskoConfiguracion.ValorInformacionSecundariaForeColor, labelPaso3_Viaje_Destino_FechaHora.ForeColor);

            // Botón anterior
            buttonPasoAnterior.Font = kiosko.KioskoConfiguracion.ValorButtonPreviousFont;
            buttonPasoAnterior.BackColor = SetColor(kiosko.KioskoConfiguracion.ValorButtonPreviousBackColor, buttonPasoAnterior.BackColor);
            buttonPasoAnterior.ForeColor = SetColor(kiosko.KioskoConfiguracion.ValorButtonPreviousForeColor, buttonPasoAnterior.ForeColor);

            // Botón siguiente
            buttonPasoSiguiente.Font = kiosko.KioskoConfiguracion.ValorButtonNextFont;
            buttonPasoSiguiente.BackColor = SetColor(kiosko.KioskoConfiguracion.ValorButtonNextBackColor, buttonPasoSiguiente.BackColor);
            buttonPasoSiguiente.ForeColor = SetColor(kiosko.KioskoConfiguracion.ValorButtonNextForeColor, buttonPasoSiguiente.ForeColor);

            // Propiedades del teclado numérico en pantalla
            keyboardMain.Font = kiosko.KioskoConfiguracion.ValorKeyboardNumericNumberFont;

            InactivityTimeoutSeconds = kiosko.KioskoConfiguracion.ValorInactivityTimeoutSeconds;
            LugarDuracionPreviaMinimaMinutos = kiosko.KioskoConfiguracion.ValorLugarDuracionPreviaMinimaMinutos;
            LugarDuracionPreviaMaximaMinutos = kiosko.KioskoConfiguracion.ValorLugarDuracionPreviaMaximaMinutos;
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

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            dbLocal.Close();
            dbLocal = null;

            dbEmpresa.Close();
            dbEmpresa = null;

            busquedaReservas = null;

            ticket = null;

            listPersonasEncontradas = null;
            listPersonasSeleccionadas = null;

            if (kiosko != null && kiosko.KioskoConfiguracion != null)
            {
                printer.ReleaseAndClose(kiosko.KioskoConfiguracion.ValorPOSPrinterReleaseTimeoutSeconds);
            }
            else
            {
                printer.ReleaseAndClose(10);
            }
            printer = null;
        }

        #endregion

        #region Kiosko init

        private bool InicializarKiosko()
        {
            // Conecto a la base de datos de la aplicación
            if (!PrepararConexionABaseDeDatosLocal())
            {
                return false;
            }

            // Cargo los datos del Kiosko a partir de la Mac Address de la PC
            string macAddress = kiosko.ObtenerMacAddressLocal();
            if (!kiosko.CargarPorMacAddress(dbLocal.Connection, macAddress))
            {
                return false;
            }
            if (!kiosko.IsFound)
            {
                // La Mac Address del Kiosko no está en la base de datos, guardo en el log
                AgregarEventLog(EventLog.TipoLoginFallido, 0, EventLog.MensajeLoginFallido, String.Format("MAC Address: {0}", macAddress));
                MessageBox.Show("La MAC Address del Kiosko no está registrada en la base de datos.", kiosko.KioskoConfiguracion);
                return false;
            }

            // Cargo los datos de la Empresa para la que está configurada el Kiosko
            // y conecto a la base de datos respectiva
            if (!kiosko.EmpresaCargar(dbLocal.Connection))
            {
                return false;
            }
            if (!PrepararConexionABaseDeDatosEmpresa(kiosko.Empresa.DatabaseName))
            {
                return false;
            }

            // Cargo la configuración del Kiosko (Logos, Colores, Tipografías, Tiempos, Ticket, etc)
            if (!kiosko.KioskoConfiguracionCargar(dbLocal.Connection))
            {
                return false;
            }
            if (!kiosko.KioskoConfiguracion.KioskoConfiguracionValoresCargar(dbLocal.Connection))
            {
                return false;
            }

            // Cargo el fotmato del Ticket a imprimir para entregar al cliente
            if (!(kiosko.IdTicketPlantilla.HasValue && ticket.CargarPorID(dbLocal.Connection, kiosko.IdTicketPlantilla.Value) && ticket.IsFound))
            {
                return false;
            }
            if (!ticket.TicketPlantillaComandosCargar(dbLocal.Connection))
            {
                return false;
            }

            if (!PreparaImpresora())
            {
                if (!System.Diagnostics.Debugger.IsAttached)
                {
                    return false;
                }
            }

            // Se completó todo correctamente
            AgregarEventLog(EventLog.TipoLoginExitoso, kiosko.IdKiosko, EventLog.MensajeLoginExitoso, String.Empty);
            return true;
        }

        private void AgregarEventLog(string tipo, byte IdKiosko, string mensaje, string notas)
        {
            EventLog eventLog = new EventLog();
            eventLog.Tipo = tipo;
            eventLog.IdKiosko = IdKiosko;
            eventLog.Mensaje = mensaje;
            eventLog.Notas = notas;
            eventLog.Agregar(dbLocal.Connection);
        }

        #endregion

        #region Database

        private bool PrepararConexionABaseDeDatosLocal()
        {
            dbLocal.ApplicationName = CardonerSistemas.My.Application.Info.Title;
            dbLocal.Datasource = Properties.Settings.Default.DatabaseDatasource;
            dbLocal.InitialCatalog = Properties.Settings.Default.DatabaseDatabase;
            dbLocal.UserID = Properties.Settings.Default.DatabaseUserID;
            if (Properties.Settings.Default.DatabasePassword.Trim().Length == 0)
            {
                dbLocal.Password = "";
            }
            else
            {
                CardonerSistemas.Encrypt.TripleDES decrypter = new CardonerSistemas.Encrypt.TripleDES(CardonerSistemas.Constants.PublicEncryptionPassword);
                string decryptedPassword = "";
                if (decrypter.Decrypt(Properties.Settings.Default.DatabasePassword, ref decryptedPassword))
                {
                    dbLocal.Password = decryptedPassword;
                }
            }
            dbLocal.WorkstationID = "";
            dbLocal.CreateConnectionString();

            return dbLocal.Connect();
        }

        private bool PrepararConexionABaseDeDatosEmpresa(string databaseName)
        {
            dbEmpresa.ApplicationName = CardonerSistemas.My.Application.Info.Title;
            dbEmpresa.Datasource = Properties.Settings.Default.DatabaseDatasource;
            dbEmpresa.InitialCatalog = databaseName;
            dbEmpresa.UserID = Properties.Settings.Default.DatabaseUserID;
            if (Properties.Settings.Default.DatabasePassword.Trim().Length == 0)
            {
                dbEmpresa.Password = "";
            }
            else
            {
                CardonerSistemas.Encrypt.TripleDES decrypter = new CardonerSistemas.Encrypt.TripleDES(CardonerSistemas.Constants.PublicEncryptionPassword);
                string decryptedPassword = "";
                if (decrypter.Decrypt(Properties.Settings.Default.DatabasePassword, ref decryptedPassword))
                {
                    dbEmpresa.Password = decryptedPassword;
                }
            }
            dbEmpresa.WorkstationID = "";
            dbEmpresa.CreateConnectionString();

            return dbEmpresa.Connect();
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

#pragma warning disable IDE0060 // Remove unused parameter
        private void WindowsMediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            if (e.newState == 8)
            {
                wmInicio_Player.Ctlcontrols.stop();
                wmInicio_Player.Ctlcontrols.play();
            }
        }

        private void Click_ToStart()
        {
            inactivityTimeout = DateTime.Now;
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

#pragma warning disable IDE0060 // Remove unused parameter
        private void Click_ToStart(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            Click_ToStart();
            AvanzarPaso();
        }

        private void Paso1_Seleccion(object sender, MouseEventArgs e)
        {
            buttonPasoSiguiente.PerformClick();
        }

        private void ButtonPasoSiguiente_Click(object sender, EventArgs e)
        {
            inactivityTimeout = DateTime.Now;
            AvanzarPaso();
        }

        private void ButtonPasoAnterior_Click(object sender, EventArgs e)
        {
            inactivityTimeout = DateTime.Now;
            RetrocederPaso();
        }

        private void ClickEnPasajero(object sender, C1.Win.C1Tile.TileEventArgs e)
        {
            inactivityTimeout = DateTime.Now;
            e.Tile.Checked = !e.Tile.Checked;
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
                    logoSecondClickTime = DateTime.Now;
                }
            }
        }

        private void TimerMain_Tick(object sender, EventArgs e)
        {
            if (pasoActual > 0 && (DateTime.Now - inactivityTimeout).TotalSeconds >= InactivityTimeoutSeconds)
            {
                busquedaReservas.CerrarConexionABaseDeDatos(dbLocal);
                busquedaReservas.CerrarConexionABaseDeDatos(dbEmpresa);
                pasoActual = 0;
                MostrarPasos();
            }
        }

        private void KeyboardClick(object sender, EventArgs e)
        {
            inactivityTimeout = DateTime.Now;
        }

        #endregion

        #region Verificación de Pasos

        private bool VerificarAvancePaso()
        {
            switch (pasoActual)
            {
                case 1: // Selección del tipo de búsqueda
                    return VerificarPaso1();

                case 2: // Introducción de los datos a buscar y búsqueda
                    return VerificarPaso2();

                case 3: // Selección de Pasajeros
                    return VerificarPaso3();

                case 4: // Selección de asiento
                    return VerificarPaso4();

                case 5: // Realizar chekin e imprimir ticket
                    return RealizarCheckInEImprimirTicket();

                default:
                    break;
            }
            return true;
        }

        private bool VerificarPaso1()
        {
            //if (radioPaso1_Documento.Checked == false & radioPaso1_Reserva.Checked == false)
            //{
            //    MessageBox.Show("Debe seleccionar alguna de las opciones de búsqueda.", kiosko.KioskoConfiguracion);
            //    return false;
            //}
            return true;
        }

        private bool VerificarPaso2()
        {
            // Verificar datos ingresados
            if (buscarPorDocumento)
            {
                if (textboxPaso2_Valor.Text.Trim().Length < 6)
                {
                    MessageBox.Show("El Nº de Documento debe contener al menos 6 (seis) dígitos.", kiosko.KioskoConfiguracion);
                    return false;
                }
            }
            else
            {
                if (textboxPaso2_Valor.Text.Trim().Length < 8)
                {
                    MessageBox.Show("Debe ingresar los 8 (ocho) caracteres del Nº de Reserva.", kiosko.KioskoConfiguracion);
                    return false;
                }
            }

            return BuscarViajesYPersonas();
        }

        private bool VerificarPaso3()
        {
            if (tilecontrolPaso3_Pasajeros.CheckedTiles.Length == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una Persona.", kiosko.KioskoConfiguracion);
                return false;
            }
            else
            {
                foreach (Tile tileItem in tilecontrolPaso3_Pasajeros.CheckedTiles)
                {
                    listPersonasSeleccionadas.Add(listPersonasEncontradas.Find(persona => persona.IDPersona == Convert.ToInt32(tileItem.Tag)));
                }
                return true;
            }
        }

        private bool VerificarPaso4()
        {
            string mensajeConfirmacion;
            if (tilecontrolPaso3_Pasajeros.CheckedTiles.Length == 1)
            {
                mensajeConfirmacion = "¿Confirma la asistencia de 1 Persona?";
            }
            else
            {
                mensajeConfirmacion = String.Format("¿Confirma la asistencia de {0} Personas?", tilecontrolPaso3_Pasajeros.CheckedTiles.Length);
            }
            return MessageBox.ShowDialog(mensajeConfirmacion, kiosko.KioskoConfiguracion);
        }

        #endregion

        #region Avance de Pasos

        private void AvanzarPaso()
        {
            if (VerificarAvancePaso())
            {
                if (pasoActual == 4)
                {
                    pasoActual = 0;
                }
                else
                {
                    pasoActual++;
                }
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
            //panelPaso1.Visible = (pasoActual == 1);
            //panelPaso2.Visible = (pasoActual == 2);
            //panelPaso3.Visible = (pasoActual == 3);
            //panelPaso4.Visible = (pasoActual == 4);
            buttonPasoAnterior.Visible = (pasoActual > 0);
            buttonPasoSiguiente.Visible = (pasoActual > 0);
            if (pasoActual <= 3)
            {
                buttonPasoSiguiente.Text = "Siguiente";
            }
            else
            {
                buttonPasoSiguiente.Text = "Finalizar";
            }
        }

        private void MostrarPaso1()
        {
            //radioPaso1_Documento.Checked = false;
            //radioPaso1_Reserva.Checked = false;

            Paso1 paso1 = new Paso1();
            TableLayoutPanel panelPaso1 = (TableLayoutPanel)paso1.Controls[0];
            paso1 = null;

            panelUser.SuspendLayout();
            panelUser.Controls.Clear();
            panelUser.Controls.Add(panelPaso1);
            panelPaso1.Dock = DockStyle.Fill;
            panelUser.ResumeLayout();
        }

        private void MostrarPaso2()
        {
            buscarPorDocumento = true; // (radioPaso1_Documento.Checked);
            if (buscarPorDocumento)
            {
                labelPaso2_Valor.Text = "Ingrese el Nº de Documento:";
                panelPaso2.SetColumnSpan(keyboardMain, 1);
                panelPaso2.SetColumn(keyboardMain, 2);
                keyboardMain.KeyboardLayout = CardonerSistemas.OnScreenKeyboard.KeyboardLayoutEnums.NumericCalculator;
            }
            else
            {
                labelPaso2_Valor.Text = "Ingrese el Nº de Reserva:";
                panelPaso2.SetColumn(keyboardMain, 1);
                panelPaso2.SetColumnSpan(keyboardMain, 2);
                keyboardMain.KeyboardLayout = CardonerSistemas.OnScreenKeyboard.KeyboardLayoutEnums.AlphanumericOnly;
            }
            textboxPaso2_Valor.Text = "";
        }

        #endregion

        #region Búsqueda de pasajeros

        private bool BuscarViajesYPersonas()
        {
            // Buscar datos en la base de datos
            listPersonasEncontradas.Clear();

            if (busquedaReservas.BuscarViajesPorDocumento(dbEmpresa, kiosko.IdLugar, textboxPaso2_Valor.Text.Trim(), listPersonasEncontradas, kiosko.KioskoConfiguracion))
            {
                labelPaso3_Viaje_Origen_Lugar.Text = String.Format("{0} en {1}", listPersonasEncontradas[0].LugarOrigen, listPersonasEncontradas[0].LugarGrupoOrigen);
                if (listPersonasEncontradas[0].FechaHoraOrigen.Date == DateTime.Now.Date)
                {
                    labelPaso3_Viaje_Origen_FechaHora.Text = String.Format("El día de hoy ({0}) a las {1} hs.", listPersonasEncontradas[0].FechaHoraOrigen.ToShortDateString(), listPersonasEncontradas[0].FechaHoraOrigen.ToShortTimeString());
                }
                else
                {
                    labelPaso3_Viaje_Origen_FechaHora.Text = String.Format("El día {0} a las {1} hs.", listPersonasEncontradas[0].FechaHoraOrigen.ToShortDateString(), listPersonasEncontradas[0].FechaHoraOrigen.ToShortTimeString());
                }
                labelPaso3_Viaje_Destino_Lugar.Text = String.Format("{0} en {1}", listPersonasEncontradas[0].LugarDestino, listPersonasEncontradas[0].LugarGrupoDestino);
                if (listPersonasEncontradas[0].FechaHoraDestino.Date == DateTime.Now.Date)
                {
                    labelPaso3_Viaje_Destino_FechaHora.Text = String.Format("El día de hoy ({0}) a las {1} hs.", listPersonasEncontradas[0].FechaHoraDestino.ToShortDateString(), listPersonasEncontradas[0].FechaHoraDestino.ToShortTimeString());
                }
                else
                {
                    labelPaso3_Viaje_Destino_FechaHora.Text = String.Format("El día {0} a las {1} hs.", listPersonasEncontradas[0].FechaHoraDestino.ToShortDateString(), listPersonasEncontradas[0].FechaHoraDestino.ToShortTimeString());
                }
                labelPaso3_Viaje_Vehiculo.Text = listPersonasEncontradas[0].Vehiculo;

                tilecontrolPaso3_Pasajeros.Groups[0].Tiles.Clear();
                foreach (BusquedaReservas.Persona persona in listPersonasEncontradas)
                {
#pragma warning disable IDE0017 // Simplify object initialization
                    Tile tileNuevo = new Tile();
#pragma warning restore IDE0017 // Simplify object initialization
                    tileNuevo.Tag = persona.IDPersona;
                    tileNuevo.Text = persona.ApellidoNombre;
                    switch (tilecontrolPaso3_Pasajeros.Groups[0].Tiles.Count % 4)
                    {
                        case 0:
                            tileNuevo.BackColor = Color.LightCoral;
                            break;
                        case 1:
                            tileNuevo.BackColor = Color.Teal;
                            break;
                        case 2:
                            tileNuevo.BackColor = Color.SteelBlue;
                            break;
                        case 3:
                            tileNuevo.BackColor = Color.ForestGreen;
                            break;
                        default:
                            break;
                    }
                    tilecontrolPaso3_Pasajeros.Groups[0].Tiles.Add(tileNuevo);
                    tileNuevo = null;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Selección de Asientos

        private bool PrepararSeleccionAsientos()
        {
            // Cargo la configuración del Vehículo
            if (!_VehiculoConfiguracion.CargarPorID(dbLocal.Connection, 1))
            {
                return false;
            }
            if (!_VehiculoConfiguracion.VehiculoConfiguracionDetallesCargar(dbLocal.Connection))
            {
                return false;
            }

            // Cargo los datos del viaje
            if (!_Viaje.CargarPorID(dbEmpresa.Connection, 213092))
            {
                return false;
            }
            if (!_Viaje.ViajeDetallesCargar(dbEmpresa.Connection))
            {
                return false;
            }

            // Creo el mapa de asientos y marco los ocupados
            CreateLayout();
            ShowOccupation();
            return true;
        }

        #endregion

        #region Layout

        private void CreateLayout()
        {
            this.SuspendLayout();

            DestroyPreviousLayout();
            CreatePanel();
            CreateButtonsSequentially();

            this.ResumeLayout();
        }

        private void DestroyPreviousLayout()
        {
            if (_panelSeatLayout != null)
            {
                // Clean old keyboard keys
                foreach (Control button in _panelSeatLayout.Controls)
                {
                    _panelSeatLayout.Controls.Remove(button);
                    button.Dispose();
                }

                _panelSeatLayout.Dispose();
            }
        }

        private void CreatePanel()
        {
            // Create the TableLayoutPanel
            _panelSeatLayout = new TableLayoutPanel();
            _panelSeatLayout.Name = "panelLayout";
            _panelSeatLayout.Dock = DockStyle.Fill;
            _panelSeatLayout.Location = new System.Drawing.Point(0, 0);
            _panelSeatLayout.TabIndex = 0;
            panelPaso4.Controls.Add(_panelSeatLayout);
            _panelSeatLayout.Padding = new Padding(4);

            // Prepare rows
            _panelSeatLayout.RowCount = _VehiculoConfiguracion.UnidadAncho;
            Single height = Convert.ToSingle(100) / Convert.ToSingle(_panelSeatLayout.RowCount);
            for (int row = 0; row < _panelSeatLayout.RowCount; row++)
            {
                _panelSeatLayout.RowStyles.Add(new RowStyle(SizeType.Percent, height));
            }

            // Prepare columns
            _panelSeatLayout.ColumnCount = _VehiculoConfiguracion.UnidadLargo;
            Single width = Convert.ToSingle(100) / Convert.ToSingle(_panelSeatLayout.ColumnCount);
            for (int column = 0; column < _panelSeatLayout.ColumnCount; column++)
            {
                _panelSeatLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, width));
            }
        }

        private void CreateButtonsSequentially()
        {
            int row = 0;
            int column = 0;

            foreach (VehiculoConfiguracionDetalle detalle in _VehiculoConfiguracion.VehiculoConfiguracionDetalles)
            {
                if (detalle.Tipo != VehiculoConfiguracionDetalle.TipoEspacio)
                {
                    CreateButton(row, column, detalle);
                }

                // Increment position variables
                row++;
                if (row == _VehiculoConfiguracion.UnidadAncho)
                {
                    row = 0;
                    column++;
                }
            }
        }

        private void CreateButtonsIndexed()
        {
            // Rows
            for (int row = 0; row < _panelSeatLayout.RowCount; row++)
            {
                // Columns
                for (int column = 0; column < _panelSeatLayout.ColumnCount; column++)
                {
                    byte idDetalle = (byte)((column * 4) + row + 1);
                    VehiculoConfiguracionDetalle detalle = _VehiculoConfiguracion.VehiculoConfiguracionDetalles.Find(vcd => vcd.IdDetalle == idDetalle);
                    if (detalle != null)
                    {
                        CreateButton(row, column, detalle);
                    }
                }
            }
        }

        private void CreateButton(int row, int column, VehiculoConfiguracionDetalle detalle)
        {
            PictureBox button = new PictureBox();
            button.Name = string.Format("{0}{1}{2}{3}{4}", SeatNamePrefix, SeatNameRowPrefix, row, SeatNameColumnPrefix, column);
            button.Tag = detalle.Tipo;
            button.Image = detalle.TipoImagen(ref kiosko);
            button.SizeMode = PictureBoxSizeMode.Zoom;
            _panelSeatLayout.Controls.Add(button, column, row);
            button.Dock = DockStyle.Fill;
            button.MouseUp += Seat_Select;
            button = null;

            // Add to seats map dictionary
            if (detalle.Tipo == VehiculoConfiguracionDetalle.TipoAsiento && !String.IsNullOrEmpty(detalle.AsientoIdentificacion))
            {
                SeatRowAndCol rowAndCol = new SeatRowAndCol();
                rowAndCol.Row = row;
                rowAndCol.Column = column;
                _seatsMap.Add(detalle.AsientoIdentificacion, rowAndCol);
                rowAndCol = null;
            }
        }

        #endregion

        #region Occupation

        private void ShowOccupation()
        {
            foreach (ViajeDetalle detalle in _Viaje.ViajeDetalles)
            {
                if (!String.IsNullOrEmpty(detalle.AsientoIdentificacion))
                {
                    SeatRowAndCol rowAndCol;
                    if (_seatsMap.TryGetValue(detalle.AsientoIdentificacion, out rowAndCol))
                    {
                        PictureBox button = (PictureBox)_panelSeatLayout.GetControlFromPosition(rowAndCol.Column, rowAndCol.Row);
                        button.Tag = VehiculoConfiguracionDetalle.TipoAsientoOcupado;
                        button.Image = kiosko.KioskoConfiguracion.ValorVehiculoConfiguracionAsientoOcupado;
                        button = null;
                    }
                }
            }
        }

        private void Seat_Select(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            switch (pictureBox.Tag.ToString())
            {
                case VehiculoConfiguracionDetalle.TipoConductor:
                    MessageBox.Show("No se puede seleccionar el asiento del Conductor.", kiosko.KioskoConfiguracion);
                    break;
                case VehiculoConfiguracionDetalle.TipoAsientoOcupado:
                    MessageBox.Show("No se puede seleccionar este asiento ya que se encuentra ocupado.", kiosko.KioskoConfiguracion);
                    break;
                case VehiculoConfiguracionDetalle.TipoAsiento:
                    if (_SeatsSelected == listPersonasSeleccionadas.Count)
                    {
                        MessageBox.Show(String.Format("Ya se han seleccionado los {0} asientos.", listPersonasSeleccionadas.Count), kiosko.KioskoConfiguracion);
                    }
                    else
                    {
                        pictureBox.Tag = VehiculoConfiguracionDetalle.TipoAsientoSeleccionado;
                        pictureBox.Image = kiosko.KioskoConfiguracion.ValorVehiculoConfiguracionAsientoSeleccionado;
                        _SeatsSelected++;
                    }
                    break;
                case VehiculoConfiguracionDetalle.TipoAsientoSeleccionado:
                    pictureBox.Tag = VehiculoConfiguracionDetalle.TipoAsiento;
                    pictureBox.Image = kiosko.KioskoConfiguracion.ValorVehiculoConfiguracionAsientoLibre;
                    _SeatsSelected--;
                    break;
                default:
                    break;
            }
        }

        #endregion

        private bool RealizarCheckInEImprimirTicket()
        {
            foreach (BusquedaReservas.Persona persona in listPersonasSeleccionadas)
            {
                ViajeDetalle viajeDetalle = new ViajeDetalle();
                if (viajeDetalle.RealizarCheckIn(dbEmpresa.Connection, kiosko.IdEmpresa, persona.IDViajeDetalle))
                {
                    viajeDetalle = null;
                    if (printer.IsReady)
                    {
                        return ticket.SendCommandsToPrinter(persona, printer);
                    }
                    else
                    {
                        return false;
                    }
                }
                viajeDetalle = null;
            }
            return false;
        }

        #region Impresión de ticket

        private bool PreparaImpresora()
        {
            return printer.GetOpenClaimAndEnable(Properties.Settings.Default.POSPrinterName, kiosko.KioskoConfiguracion.ValorPOSPrinterClaimTimeoutSeconds);
        }

        private bool OLDImprimirTicket(BusquedaReservas.Persona persona)
        {
            printer.PrintBitmap("C:\\Users\\Tomas\\Dropbox\\Cardoner Sistemas\\CS-Transporte\\Resource\\Interface\\lobosbus.gif", 500, -2);
            printer.PrintLineCrLf("");
            printer.PrintLineCrLf("Salida de:");
            printer.PrintLineCrLf("<BOLD><DOUBLEHIGH>" + persona.LugarGrupoOrigen.ToUpper());
            printer.PrintLineCrLf(persona.LugarOrigen);
            printer.PrintLineCrLf("El día <BOLD><DOUBLEHIGH>{0}<SINGLE><NORMAL> a las <BOLD><DOUBLEHIGH>{1}<SINGLE><NORMAL> horas.", persona.FechaHoraOrigen.ToShortDateString(), persona.FechaHoraOrigen.ToShortTimeString());
            printer.PrintLineCrLf("");
            printer.PrintLineCrLf("Llegada a:");                
            printer.PrintLineCrLf("<BOLD><DOUBLEHIGH>" + persona.LugarGrupoDestino.ToUpper());
            printer.PrintLineCrLf(persona.LugarDestino);
            printer.PrintLineCrLf("El día <BOLD><DOUBLEHIGH>{0}<SINGLE><NORMAL> a las <BOLD><DOUBLEHIGH>{1}<SINGLE><NORMAL> horas.", persona.FechaHoraDestino.ToShortDateString(), persona.FechaHoraDestino.ToShortTimeString());
            printer.PrintLineCrLf("");
            printer.PrintLineCrLf("Combi nº: <BOLD><DOUBLEHIGH>" + persona.Vehiculo);
            printer.PrintLineCrLf("");
            printer.PrintLineCrLf("<CENTER><DOUBLE>" + persona.ApellidoNombre);
            printer.PrintLineCrLf("");
            printer.PrintLineCrLf("");
            printer.PrintLineCrLf("");
            printer.PrintLineCrLf("");
            printer.CutPaper(90);
            return true;
        }

        #endregion

    }
}