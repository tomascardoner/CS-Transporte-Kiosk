using CardonerSistemas.Database.ADO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CSTransporteKiosko
{
    public partial class Paso4 : UserControl
    {

        #region Declarations

        private FormMessageBox messageBox;
        private KioskoConfiguracion kioskoConfiguracion;
        private List<BusquedaReservas.Persona> personas;
        private int cantidadAsientosASeleccionar;

        private const string SeatNamePrefix = "buttonSeat";
        private const string SeatNameRowPrefix = "R";
        private const string SeatNameColumnPrefix = "C";
        private TableLayoutPanel panelSeatLayout;
        private class SeatRowAndCol
        {
            public int Row;
            public int Column;
        }
        private Dictionary<string, SeatRowAndCol> seatsMap = new Dictionary<string, SeatRowAndCol>();
        private List<string> seatsSelected = new List<string>();

        #endregion

        #region Main functions

        public Paso4()
        {
            InitializeComponent();
        }

        public void SetAppearance(KioskoConfiguracion configuracion)
        {
            panelPaso4.BackColor = CardonerSistemas.Colors.SetColor(configuracion.ValorScreenBackColor, panelPaso4.BackColor);

            labelEncabezadoPasajeros.Font = configuracion.ValorInformacionPrincipalFont;
            labelEnbezadoAsientos.Font = labelEncabezadoPasajeros.Font;
        }

        public bool Verificar(ref FormMessageBox messageBox, int cantidadPersonas)
        {
            int asientosPendientesDeSeleccionar = cantidadPersonas - seatsSelected.Count;
            if (asientosPendientesDeSeleccionar == cantidadPersonas)
            {
                if (cantidadPersonas == 1)
                {
                    messageBox.Show("Debe seleccionar el asiento.");
                }
                else
                {
                    messageBox.Show("Debe seleccionar los asientos.");
                }
                return false;
            }
            else if (asientosPendientesDeSeleccionar == 1)
            {
                messageBox.Show("Falta seleccionar un asiento.");
                return false;
            }
            else if (asientosPendientesDeSeleccionar > 0)
            {
                messageBox.Show(String.Format("Faltan seleccionar {0} asientos.", asientosPendientesDeSeleccionar));
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool PrepararParaMostrar(FormMessageBox formMessageBox, SQLServer dbLocal, SQLServer dbEmpresa, KioskoConfiguracion kioskoConfig, byte idVehiculoConfiguracion, int idViaje, List<BusquedaReservas.Persona> personasSeleccionadas)
        {
            messageBox = formMessageBox;
            kioskoConfiguracion = kioskoConfig;
            VehiculoConfiguracion vehiculoConfiguracion = new VehiculoConfiguracion();
            Viaje viaje = new Viaje();
            personas = personasSeleccionadas;
            cantidadAsientosASeleccionar = personasSeleccionadas.Count;

            // Cargo la configuración del Vehículo
            if (!vehiculoConfiguracion.CargarPorID(dbLocal.Connection, idVehiculoConfiguracion))
            {
                return false;
            }
            if (!vehiculoConfiguracion.VehiculoConfiguracionDetallesCargar(dbLocal.Connection))
            {
                return false;
            }

            // Cargo los datos del viaje
            if (!viaje.CargarPorID(dbEmpresa.Connection, idViaje))
            {
                return false;
            }
            if (!viaje.ViajeDetallesCargar(dbEmpresa.Connection))
            {
                return false;
            }

            // Creo el mapa de asientos y marco los ocupados
            CreateLayout(vehiculoConfiguracion);
            ShowOccupation(viaje);
            TablaAsignacionCrearPasajeros();

            return true;
        }

        #endregion

        #region Layout

        private void CreateLayout(VehiculoConfiguracion vehiculoConfiguracion)
        {
            SuspendLayout();

            DestroyPreviousLayout();
            CreatePanel(vehiculoConfiguracion);
            CreateButtonsSequentially(vehiculoConfiguracion);
            // CreateButtonsIndexed(vehiculoConfiguracion);

            ResumeLayout();
        }

        private void DestroyPreviousLayout()
        {
            if (panelSeatLayout != null)
            {
                // Clean old keyboard keys
                foreach (Control button in panelSeatLayout.Controls)
                {
                    panelSeatLayout.Controls.Remove(button);
                    button.Dispose();
                }

                panelSeatLayout.Dispose();
            }
            seatsMap.Clear();
            seatsSelected.Clear();
        }

        private void CreatePanel(VehiculoConfiguracion vehiculoConfiguracion)
        {
            // Create the TableLayoutPanel
            panelSeatLayout = new TableLayoutPanel();
            panelSeatLayout.Name = "panelLayout";
            panelSeatLayout.Location = new System.Drawing.Point(0, 0);
            panelSeatLayout.TabIndex = 0;
            panelSeatLayoutBorder.Controls.Add(panelSeatLayout);
            panelSeatLayoutBorder.BorderStyle = BorderStyle.FixedSingle;

            // Prepare rows
            panelSeatLayout.RowCount = vehiculoConfiguracion.UnidadAncho;
            Single height = Convert.ToSingle(100) / Convert.ToSingle(panelSeatLayout.RowCount);
            for (int row = 0; row < panelSeatLayout.RowCount; row++)
            {
                panelSeatLayout.RowStyles.Add(new RowStyle(SizeType.Percent, height));
            }

            // Prepare columns
            panelSeatLayout.ColumnCount = vehiculoConfiguracion.UnidadLargo;
            Single width = Convert.ToSingle(100) / Convert.ToSingle(panelSeatLayout.ColumnCount);
            for (int column = 0; column < panelSeatLayout.ColumnCount; column++)
            {
                panelSeatLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, width));
            }

            ResizeAndPositionPanel();
        }

        private void ResizeAndPositionPanel()
        {
            // Obtener el ancho máximo de las imágenes
            int width = kioskoConfiguracion.ValorVehiculoConfiguracionPuerta.Width;
            if (kioskoConfiguracion.ValorVehiculoConfiguracionConductor.Width > width)
            {
                width = kioskoConfiguracion.ValorVehiculoConfiguracionConductor.Width;
            }
            if (kioskoConfiguracion.ValorVehiculoConfiguracionAsientoLibre.Width > width)
            {
                width = kioskoConfiguracion.ValorVehiculoConfiguracionAsientoLibre.Width;
            }
            if (kioskoConfiguracion.ValorVehiculoConfiguracionAsientoSeleccionado.Width > width)
            {
                width = kioskoConfiguracion.ValorVehiculoConfiguracionAsientoSeleccionado.Width;
            }
            if (kioskoConfiguracion.ValorVehiculoConfiguracionAsientoOcupado.Width > width)
            {
                width = kioskoConfiguracion.ValorVehiculoConfiguracionAsientoOcupado.Width;
            }

            // Calcular el ancho total
            panelSeatLayout.Width = (panelSeatLayout.ColumnCount * (panelSeatLayout.Padding.Left + width + panelSeatLayout.Padding.Right));
            
            // Obtener la altura máxima de las imágenes
            int height = kioskoConfiguracion.ValorVehiculoConfiguracionPuerta.Height;
            if (kioskoConfiguracion.ValorVehiculoConfiguracionConductor.Height > height)
            {
                height = kioskoConfiguracion.ValorVehiculoConfiguracionConductor.Height;
            }
            if (kioskoConfiguracion.ValorVehiculoConfiguracionAsientoLibre.Height > height)
            {
                height = kioskoConfiguracion.ValorVehiculoConfiguracionAsientoLibre.Height;
            }
            if (kioskoConfiguracion.ValorVehiculoConfiguracionAsientoSeleccionado.Height > height)
            {
                height = kioskoConfiguracion.ValorVehiculoConfiguracionAsientoSeleccionado.Height;
            }
            if (kioskoConfiguracion.ValorVehiculoConfiguracionAsientoOcupado.Height > height)
            {
                height = kioskoConfiguracion.ValorVehiculoConfiguracionAsientoOcupado.Height;
            }

            // Calcular la altura total
            panelSeatLayout.Height = (panelSeatLayout.RowCount * (panelSeatLayout.Padding.Top + height + panelSeatLayout.Padding.Bottom));
        }

        private void CreateButtonsSequentially(VehiculoConfiguracion vehiculoConfiguracion)
        {
            int row = 0;
            int column = 0;

            foreach (VehiculoConfiguracionDetalle detalle in vehiculoConfiguracion.VehiculoConfiguracionDetalles)
            {
                if (detalle.Tipo != VehiculoConfiguracionDetalle.TipoEspacio)
                {
                    CreateButton(row, column, detalle);
                }

                // Increment position variables
                row++;
                if (row == vehiculoConfiguracion.UnidadAncho)
                {
                    row = 0;
                    column++;
                }
            }
        }

        private void CreateButtonsIndexed(VehiculoConfiguracion vehiculoConfiguracion)
        {
            // Rows
            for (int row = 0; row < panelSeatLayout.RowCount; row++)
            {
                // Columns
                for (int column = 0; column < panelSeatLayout.ColumnCount; column++)
                {
                    byte idDetalle = (byte)((column * 4) + row + 1);
                    VehiculoConfiguracionDetalle detalle = vehiculoConfiguracion.VehiculoConfiguracionDetalles.Find(vcd => vcd.IdDetalle == idDetalle);
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
            button.Name = String.Format("{0}{1}{2}{3}{4}", SeatNamePrefix, SeatNameRowPrefix, row, SeatNameColumnPrefix, column);
            button.Tag = String.Format("{0}|{1}", detalle.Tipo, detalle.AsientoIdentificacion);
            button.Image = detalle.TipoImagen(kioskoConfiguracion);
            button.SizeMode = PictureBoxSizeMode.Zoom;
            button.Margin = new Padding(kioskoConfiguracion.ValorVehiculoConfiguracionCellMargin);
            panelSeatLayout.Controls.Add(button, column, row);
            button.Dock = DockStyle.Fill;
            button.MouseUp += Seat_Select;
            button = null;

            // Add to seats map dictionary
            if (detalle.Tipo == VehiculoConfiguracionDetalle.TipoAsiento && !String.IsNullOrEmpty(detalle.AsientoIdentificacion))
            {
                SeatRowAndCol rowAndCol = new SeatRowAndCol();
                rowAndCol.Row = row;
                rowAndCol.Column = column;
                seatsMap.Add(detalle.AsientoIdentificacion, rowAndCol);
                rowAndCol = null;
            }
        }

        #endregion

        #region Occupation

        private void ShowOccupation(Viaje viaje)
        {
            foreach (ViajeDetalle detalle in viaje.ViajeDetalles)
            {
                if (!String.IsNullOrEmpty(detalle.AsientoIdentificacion))
                {
                    SeatRowAndCol rowAndCol;
                    if (seatsMap.TryGetValue(detalle.AsientoIdentificacion, out rowAndCol))
                    {
                        PictureBox button = (PictureBox)panelSeatLayout.GetControlFromPosition(rowAndCol.Column, rowAndCol.Row);
                        button.Image = kioskoConfiguracion.ValorVehiculoConfiguracionAsientoOcupado;
                        button.Tag = String.Format("{0}|{1}", VehiculoConfiguracionDetalle.TipoAsientoOcupado, detalle.AsientoIdentificacion);
                        button = null;
                    }
                }
            }
        }

        private void Seat_Select(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            string tipo = CardonerSistemas.String.GetSubString(pictureBox.Tag.ToString(), 0, "|");
            string asiento = CardonerSistemas.String.GetSubString(pictureBox.Tag.ToString(), 1, "|");
            switch (tipo)
            {
                case VehiculoConfiguracionDetalle.TipoConductor:
                    messageBox.Show("No se puede seleccionar el asiento del Conductor.");
                    break;
                case VehiculoConfiguracionDetalle.TipoAsientoOcupado:
                    messageBox.Show("No se puede seleccionar este asiento ya que se encuentra ocupado.");
                    break;
                case VehiculoConfiguracionDetalle.TipoAsiento:
                    if (seatsSelected.Count == cantidadAsientosASeleccionar)
                    {
                        if (cantidadAsientosASeleccionar == 1)
                        {
                            messageBox.Show("Ya se ha seleccionado el asiento. Para cambiarlo, toque en el asiento asignado.");
                        }
                        else
                        {
                            messageBox.Show(String.Format("Ya se han seleccionado los {0} asientos.", cantidadAsientosASeleccionar));
                        }
                    }
                    else
                    {
                        pictureBox.Image = kioskoConfiguracion.ValorVehiculoConfiguracionAsientoSeleccionado;
                        pictureBox.Tag = String.Format("{0}|{1}", VehiculoConfiguracionDetalle.TipoAsientoSeleccionado, asiento);
                        seatsSelected.Add(asiento);
                        TablaAsignacionAgregarAsiento(asiento);
                    }
                    break;
                case VehiculoConfiguracionDetalle.TipoAsientoSeleccionado:
                    pictureBox.Image = kioskoConfiguracion.ValorVehiculoConfiguracionAsientoLibre;
                    pictureBox.Tag = String.Format("{0}|{1}", VehiculoConfiguracionDetalle.TipoAsiento, asiento);
                    seatsSelected.RemoveAt(seatsSelected.Count -1);
                    TablaAsignacionBorrarUltimoAsiento();
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Seats assignation table

        private void TablaAsignacionVaciar()
        {
            for (int row = 1, j = panelPasajerosAsientos.RowCount; row < j; row++)
            {
                // Eliminar label del pasajero
                Label pasajero = (Label)panelPasajerosAsientos.GetControlFromPosition(0, row);
                if (pasajero != null)
                {
                    panelPasajerosAsientos.Controls.Remove(pasajero);
                    pasajero.Dispose();
                    pasajero = null;
                }

                // Eliminar label del asiento
                Label asiento = (Label)panelPasajerosAsientos.GetControlFromPosition(0, row);
                if (asiento != null)
                { 
                    panelPasajerosAsientos.Controls.Remove(asiento);
                    asiento.Dispose();
                    asiento = null;
                }
            }
            panelPasajerosAsientos.RowCount = 1;
        }

        private void TablaAsignacionCrearPasajeros()
        {
            TablaAsignacionVaciar();

            // Completo la tabla de asignación de asientos con los nombres de los pasajeros
            foreach (BusquedaReservas.Persona persona in personas)
            {
                panelPasajerosAsientos.RowCount++;

                // Pasajero
                Label labelPasajero = new Label();
                panelPasajerosAsientos.Controls.Add(labelPasajero, 0, panelPasajerosAsientos.RowCount - 1);
                labelPasajero.Text = persona.ApellidoNombre;
                labelPasajero.Font = kioskoConfiguracion.ValorInformacionSecundariaFont;
                labelPasajero.AutoSize = true;
                labelPasajero.Dock = DockStyle.Fill;

                // Asiento
                Label labelAsiento = new Label();
                panelPasajerosAsientos.Controls.Add(labelAsiento, 1, panelPasajerosAsientos.RowCount - 1);
                labelAsiento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                labelAsiento.Font = kioskoConfiguracion.ValorInformacionSecundariaFont;
                labelAsiento.AutoSize = true;
                labelAsiento.Dock = DockStyle.Fill;
            }
        }

        private void TablaAsignacionAgregarAsiento(string asiento)
        {
            Label asientoLabel = (Label)panelPasajerosAsientos.GetControlFromPosition(1, seatsSelected.Count);
            asientoLabel.Text = asiento;
        }

        private void TablaAsignacionBorrarUltimoAsiento()
        {
            Label asientoLabel = (Label)panelPasajerosAsientos.GetControlFromPosition(1, seatsSelected.Count + 1);
            asientoLabel.Text = "";
        }

        #endregion

    }
}
