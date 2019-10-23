using CardonerSistemas.Database.ADO;
using CardonerSistemas.PointOfSale;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CSTransporteKiosko
{
    public partial class FormSteps : Form
    {

        #region Declaraciones

        // Steps components
        Paso1 paso1;
        Paso2 paso2;
        Paso3 paso3;
        Paso4 paso4;

        // Variables internas
        private byte pasoActual = 0;
        private int inactivityTimeoutSeconds;
        private DateTime lastActivityDateTime = DateTime.Now;

        // Objects instances
        FormMessageBox messageBox;
        SQLServer dbLocal;
        SQLServer dbEmpresa;
        Kiosko kiosko;
        TicketPlantilla ticket = new TicketPlantilla();
        Printer printer = new Printer();

        // Reservas
        List<BusquedaReservas.Persona> personas = new List<BusquedaReservas.Persona>();

        #endregion

        #region Form intialization

        public FormSteps()
        {
            InitializeComponent();
            timerMain.Enabled = !System.Diagnostics.Debugger.IsAttached;
            CreateSteps();
        }

        private void CreateSteps()
        {
            panelUser.SuspendLayout();

            paso1 = new Paso1();
            panelUser.Controls.Add(paso1);
            paso1.Dock = DockStyle.Fill;
            paso1.TipoBusquedaCambiada += ButtonPasoSiguiente_Click;

            paso2 = new Paso2();
            panelUser.Controls.Add(paso2);
            paso2.Dock = DockStyle.Fill;
            paso2.SearchButtonPressed += ButtonPasoSiguiente_Click;

            paso3 = new Paso3();
            panelUser.Controls.Add(paso3);
            paso3.Dock = DockStyle.Fill;

            paso4 = new Paso4();
            panelUser.Controls.Add(paso4);
            paso4.Dock = DockStyle.Fill;

            panelUser.ResumeLayout();
        }

        public void SetAppearance(KioskoConfiguracion configuracion)
        {
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                TopLevel = true;
                TopMost = true;
            }

            // Apariencia
            Icon = Properties.Resources.ICON_APP;
            BackColor = CardonerSistemas.Colors.SetColor(configuracion.ValorScreenBackColor, this.BackColor);

            labelPasosVersion.Text = Application.ProductVersion;

            // Media
            pictureboxPasosLogoCompaniaSoftware.Image = configuracion.ValorCompaniaSoftwareLogotipo;
            pictureboxLogoEmpresa.Image = configuracion.ValorEmpresaLogotipo;

            // Botón anterior
            buttonPasoAnterior.Font = configuracion.ValorButtonPreviousFont;
            buttonPasoAnterior.BackColor = CardonerSistemas.Colors.SetColor(configuracion.ValorButtonPreviousBackColor, buttonPasoAnterior.BackColor);
            buttonPasoAnterior.ForeColor = CardonerSistemas.Colors.SetColor(configuracion.ValorButtonPreviousForeColor, buttonPasoAnterior.ForeColor);

            // Botón siguiente
            buttonPasoSiguiente.Font = configuracion.ValorButtonNextFont;
            buttonPasoSiguiente.BackColor = CardonerSistemas.Colors.SetColor(configuracion.ValorButtonNextBackColor, buttonPasoSiguiente.BackColor);
            buttonPasoSiguiente.ForeColor = CardonerSistemas.Colors.SetColor(configuracion.ValorButtonNextForeColor, buttonPasoSiguiente.ForeColor);

            inactivityTimeoutSeconds = configuracion.ValorInactivityTimeoutSeconds;

            paso1.SetAppearance(configuracion);
            paso2.SetAppearance(configuracion);
            paso3.SetAppearance(configuracion);
            paso4.SetAppearance(configuracion);
        }

        #endregion

        #region Controls events

        private void KeyCombinationManager(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.X) || (e.Alt && e.KeyCode == Keys.X))  // Control + X or Alt + X
            {
                Application.Exit();
            }
        }

        private void TimerMain_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now - lastActivityDateTime).TotalSeconds >= inactivityTimeoutSeconds)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void RegistrarActividad()
        {
            lastActivityDateTime = DateTime.Now;
        }

        #endregion

        #region Avance de Pasos

        private void ButtonPasoAnterior_Click(object sender, EventArgs e)
        {
            RegistrarActividad();
            RetrocederPaso();
        }

        private void ButtonPasoSiguiente_Click(object sender, EventArgs e)
        {
            RegistrarActividad();
            AvanzarPaso();
        }

        internal void PrepararParaMostrar(SQLServer databaseLocal, SQLServer databaseEmpresa, Kiosko kioskoObj, FormMessageBox formMessageBox, TicketPlantilla ticket, CardonerSistemas.PointOfSale.Printer printer)
        {
            dbLocal = databaseLocal;
            dbEmpresa = databaseEmpresa;
            kiosko = kioskoObj;
            messageBox = formMessageBox;
            pasoActual = 1;
            MostrarPasos();
        }

        private bool Verificar()
        {
            switch (pasoActual)
            {
                case 1: // Selección del tipo de búsqueda
                    return paso1.Verificar(ref messageBox);

                case 2: // Introducción de los datos a buscar y búsqueda
                    if (paso2.Verificar(ref messageBox))
                    {
                        if (paso1.BusquedaPorDocumento)
                        {
                            return BusquedaReservas.BuscarViajesPorDocumento(dbEmpresa, kiosko.IdLugar, paso2.ValorIngresado, personas, kiosko.KioskoConfiguracion, messageBox);
                        }
                        else
                        {
                            return BusquedaReservas.BuscarViajesPorReserva(dbEmpresa, kiosko.IdLugar, paso2.ValorIngresado, personas, kiosko.KioskoConfiguracion, messageBox);
                        }
                    }
                    else
                    {
                        return false;
                    }

                case 3: // Selección de Pasajeros
                    return paso3.Verificar(ref messageBox);

                case 4: // Selección de asiento
                    return paso4.Verificar(ref messageBox);

                default:
                    break;
            }
            return true;
        }

        private void AvanzarPaso()
        {
            if (Verificar())
            {
                switch (pasoActual)
                {
                    case 2:
                        // Verifico si es el mes, día, hora y minutos para salir del sistema
                        if (paso2.ValorIngresado == DateTime.Now.ToString("MMddHHmm"))
                        {
                            DialogResult = DialogResult.Cancel;
                            Close();
                        }
                        pasoActual++;
                        break;

                    case 3:
                        if (personas[0].IDVehiculoConfiguracion == Byte.MinValue)
                        {
                            // pasoActual = 5;
                        }
                        else
                        {
                            pasoActual++;
                        }
                        break;

                    case 4:
                        if (RealizarCheckInEImprimirTicket())
                        {
                            pasoActual = 1;
                        }
                        break;

                    default:
                        pasoActual++;
                        break;
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
                    paso1.PrepararParaMostrar();
                    break;
                case 2:
                    paso2.PrepararParaMostrar(paso1.BusquedaPorDocumento);
                    break;
                case 3:
                    paso3.PrepararParaMostrar(personas);
                    break;
                case 4:
                    paso4.Personas = paso3.PersonasSeleccionadas;
                    paso4.PrepararParaMostrar(messageBox, dbLocal, dbEmpresa, kiosko.KioskoConfiguracion, personas[0].IDVehiculoConfiguracion, personas[0].IDViaje);
                    break;
                default:
                    break;
            }
            paso1.Visible = (pasoActual == 1);
            paso2.Visible = (pasoActual == 2);
            paso3.Visible = (pasoActual == 3);
            paso4.Visible = (pasoActual == 4);
            buttonPasoAnterior.Visible = (pasoActual > 1);
            buttonPasoSiguiente.Visible = (pasoActual > 2);
            if (pasoActual <= 3)
            {
                buttonPasoSiguiente.Text = "Siguiente";
            }
            else
            {
                buttonPasoSiguiente.Text = "Finalizar";
            }
        }

        #endregion

        #region Check-in

        private bool RealizarCheckInEImprimirTicket()
        {
            foreach (BusquedaReservas.Persona persona in paso4.Personas)
            {
                // Guardo el check-in de la reserva en la base de datos
                ViajeDetalle viajeDetalle = new ViajeDetalle();
                if (!viajeDetalle.RealizarCheckIn(dbEmpresa.Connection, persona.IDViajeDetalle, persona.AsientoIdentificacion))
                {
                    viajeDetalle = null;
                    return false;
                }
                viajeDetalle = null;

                if (printer.IsReady)
                {
                    // Imprimo el ticket de la reserva
                    if (!ticket.SendCommandsToPrinter(persona, printer))
                    {
                        return false;
                    }
                }
            }

            // Actualizo la fecha/hora de la última operación del kiosko
            kiosko.ActualizarUltimaOperacion(dbLocal.Connection, kiosko.IdKiosko);

            return true;
        }

        #endregion

    }
}