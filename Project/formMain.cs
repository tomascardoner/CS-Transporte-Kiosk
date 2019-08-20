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

        private byte pasoActual = 0;
        private Boolean buscarPorDocumento;
        private int InactivityTimeoutSeconds;

        private SQLServer database = new SQLServer();
        private Kiosko kiosko = new Kiosko();
        private BusquedaReservas busquedaReservas = new BusquedaReservas();
        private TicketPlantilla ticket = new TicketPlantilla();

        private short LugarDuracionPreviaMinimaMinutos;
        private short LugarDuracionPreviaMaximaMinutos;

        private List<BusquedaReservas.Persona> listPersonasEncontradas = new List<BusquedaReservas.Persona>();
        private List<BusquedaReservas.Persona> listPersonasSeleccionadas = new List<BusquedaReservas.Persona>();

        private Printer printer = new Printer();

        private DateTime inactivityTimeout = new DateTime(0);
        private DateTime logoFirstClickTime = new DateTime(0);
        private DateTime logoSecondClickTime = new DateTime(0);

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
            // onscreenkeyboardNumeric.Font = kiosko.KioskoConfiguracion.ValorFont;

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
            database.Close();
            database = null;

            busquedaReservas = null;

            ticket = null;

            listPersonasEncontradas = null;
            listPersonasSeleccionadas = null;

            printer.ReleaseAndClose(10);
            printer = null;
        }

        #endregion

        #region Kiosko init

        private bool InicializarKiosko()
        {
            if (PrepararConexionABaseDeDatos())
            {
                string macAddress = kiosko.ObtenerMacAddressLocal();
                if (kiosko.CargarPorMacAddress(database.Connection, macAddress))
                {
                    if (kiosko.IsFound)
                    {
                        if (kiosko.KioskoConfiguracionCargar(database.Connection))
                        {
                            if (kiosko.KioskoConfiguracion.KioskoConfiguracionValoresCargar(database.Connection))
                            {
                                if (kiosko.IdTicketPlantilla.HasValue && ticket.CargarPorID(database.Connection, kiosko.IdTicketPlantilla.Value))
                                {
                                    if (ticket.IsFound)
                                    {
                                        if (ticket.TicketPlantillaComandosCargar(database.Connection))
                                        {
                                            AgregarEventLog(EventLog.TipoLoginExitoso, kiosko.IdKiosko, EventLog.MensajeLoginExitoso, String.Empty);
                                            return PreparaImpresora();
                                        }
                                    }
                                }
                            }
                        }
                        return false;
                    }
                    else
                    {
                        // La MAC Address del Kiosko no está en la base de datos, guardo en el log
                        AgregarEventLog(EventLog.TipoLoginFallido, 0, EventLog.MensajeLoginFallido, String.Format("MAC Address: {0}", macAddress));
                        MessageBox.Show("La MAC Address del Kiosko no está registrada en la base de datos.", kiosko.KioskoConfiguracion);
                        return false;
                    }
                }
            }
            return false;
        }

        private void AgregarEventLog(string tipo, byte IdKiosko, string mensaje, string notas)
        {
            EventLog eventLog = new EventLog();
            eventLog.Tipo = tipo;
            eventLog.IdKiosko = IdKiosko;
            eventLog.Mensaje = mensaje;
            eventLog.Notas = notas;
            eventLog.Agregar(database.Connection);
        }

        #endregion

        #region Database

        private bool PrepararConexionABaseDeDatos()
        {
            database.ApplicationName = CardonerSistemas.My.Application.Info.Title;
            database.Datasource = Properties.Settings.Default.DatabaseDatasource;
            database.InitialCatalog = Properties.Settings.Default.DatabaseDatabase;
            database.UserID = Properties.Settings.Default.DatabaseUserID;
            if (Properties.Settings.Default.DatabasePassword.Trim().Length == 0)
            {
                database.Password = "";
            }
            else
            {
                CardonerSistemas.Encrypt.TripleDES decrypter = new CardonerSistemas.Encrypt.TripleDES(CardonerSistemas.Constants.PublicEncryptionPassword);
                string decryptedPassword = "";
                if (decrypter.Decrypt(Properties.Settings.Default.DatabasePassword, ref decryptedPassword))
                {
                    database.Password = decryptedPassword;
                }
            }
            database.WorkstationID = "";
            database.CreateConnectionString();

            return database.Connect();
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
                busquedaReservas.CerrarConexionABaseDeDatos(database);
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

                case 3: // Selección de Pasajeros e Impresión
                    if (VerificarPaso3())
                    {
                        return RealizarCheckInEImprimirTicket();
                    }
                    else
                    {
                        return false;
                    }

                default:
                    break;
            }
            return true;
        }

        private bool VerificarPaso1()
        {
            if (radioPaso1_Documento.Checked == false & radioPaso1_Reserva.Checked == false)
            {
                MessageBox.Show("Debe seleccionar alguna de las opciones de búsqueda.", kiosko.KioskoConfiguracion);
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
        }

        #endregion

        #region Avance de Pasos

        private void AvanzarPaso()
        {
            if (VerificarAvancePaso())
            {
                if (pasoActual == 0)
                {
                    // Este es para saltear el paso de elegir el tipo de búsqueda
                    radioPaso1_Documento.Checked = true;
                    pasoActual = 2;
                }
                else if (pasoActual == 3)
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
            if (pasoActual == 2)
            {
                // Este es para saltear el paso de elegir el tipo de búsqueda
                radioPaso1_Documento.Checked = true;
                pasoActual = 0;
            }
            else
            {
                pasoActual--;
            }
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
            if (pasoActual <= 2)
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

        #region Búsqueda de pasajeros

        private bool BuscarViajesYPersonas()
        {
            // Buscar datos en la base de datos
            listPersonasEncontradas.Clear();

            if (busquedaReservas.BuscarViajesPorDocumento(database, kiosko.IdEmpresa, kiosko.IdLugar, textboxPaso2_Valor.Text.Trim(), listPersonasEncontradas, kiosko.KioskoConfiguracion))
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

        private bool RealizarCheckInEImprimirTicket()
        {
            foreach (BusquedaReservas.Persona persona in listPersonasSeleccionadas)
            {
                ViajeDetalle viajeDetalle = new ViajeDetalle();
                if (viajeDetalle.RealizarCheckIn(database.Connection, kiosko.IdEmpresa, persona.IDViajeDetalle))
                {
                    viajeDetalle = null;
                    return ticket.SendCommandsToPrinter(persona, printer);
                }
                viajeDetalle = null;
            }
            return false;
        }

        #endregion

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