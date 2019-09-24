﻿using CardonerSistemas.Database.ADO;
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

        // Reservas
        List<BusquedaReservas.Persona> personas = new List<BusquedaReservas.Persona>();

        #endregion

        #region Form intialization

        public FormSteps()
        {
            InitializeComponent();
            CreateSteps();
        }

        private void CreateSteps()
        {
            panelUser.SuspendLayout();

            paso1 = new Paso1();
            panelUser.Controls.Add(paso1);
            paso1.Dock = DockStyle.Fill;

            paso2 = new Paso2();
            panelUser.Controls.Add(paso2);
            paso2.Dock = DockStyle.Fill;

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

        private void ButtonPasoSiguiente_Click(object sender, EventArgs e)
        {
            RegistrarActividad();
            AvanzarPaso();
        }

        private void ButtonPasoAnterior_Click(object sender, EventArgs e)
        {
            RegistrarActividad();
            RetrocederPaso();
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

        internal void PrepararParaMostrar(SQLServer databaseLocal, SQLServer databaseEmpresa, Kiosko kioskoObj, FormMessageBox formMessageBox)
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
                        return BusquedaReservas.BuscarViajesPorDocumento(dbEmpresa, kiosko.IdLugar, paso2.ValorIngresado, personas, kiosko.KioskoConfiguracion, messageBox);
                    }
                    return false;

                case 3: // Selección de Pasajeros
                    return paso3.Verificar(ref messageBox);

                case 4: // Selección de asiento
                    return paso4.Verificar(ref messageBox, paso3.PersonasSeleccionadas.Count);

                case 5: // Realizar chekin e imprimir ticket
                    return true; // RealizarCheckInEImprimirTicket();

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
                        pasoActual = 1;
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
                    paso4.PrepararParaMostrar(messageBox, dbLocal, dbEmpresa, kiosko.KioskoConfiguracion, personas[0].IDVehiculoConfiguracion, personas[0].IDViaje, paso3.PersonasSeleccionadas.Count);
                    break;
                default:
                    break;
            }
            paso1.Visible = (pasoActual == 1);
            paso2.Visible = (pasoActual == 2);
            paso3.Visible = (pasoActual == 3);
            paso4.Visible = (pasoActual == 4);
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

        #endregion

        //if (cantidadPersonas == 1)
        //{
        //    mensajeConfirmacion = "¿Confirma la asistencia de 1 Persona?";
        //}
        //else
        //{
        //    mensajeConfirmacion = String.Format("¿Confirma la asistencia de {0} Personas?", cantidadPersonas);
        //}
        //return (messageBox.Show(mensajeConfirmacion) == DialogResult.Yes);

        //private bool RealizarCheckInEImprimirTicket()
        //{
        //    foreach (BusquedaReservas.Persona persona in listPersonasSeleccionadas)
        //    {
        //        ViajeDetalle viajeDetalle = new ViajeDetalle();
        //        if (viajeDetalle.RealizarCheckIn(dbEmpresa.Connection, kiosko.IdEmpresa, persona.IDViajeDetalle))
        //        {
        //            viajeDetalle = null;
        //            if (printer.IsReady)
        //            {
        //                return ticket.SendCommandsToPrinter(persona, printer);
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //        viajeDetalle = null;
        //    }
        //    return false;
        //}

    }
}