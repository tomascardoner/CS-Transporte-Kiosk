using CardonerSistemas.Database.ADO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        // Seats layout
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

        // Seats assignation table
        private TableLayoutPanel panelSeatsAssignation;
        private Dictionary<string, int> seatsAssignation = new Dictionary<string, int>();

        #endregion

        #region Main functions

        public Paso4()
        {
            InitializeComponent();
        }

        public void SetAppearance(KioskoConfiguracion configuracion)
        {
            panelPaso4.BackColor = CardonerSistemas.Colors.SetColor(configuracion.ValorScreenBackColor, panelPaso4.BackColor);
        }

        public bool Verificar(ref FormMessageBox messageBox, int cantidadPersonas)
        {
            int asientosPendientesDeSeleccionar = cantidadPersonas - seatsAssignation.Count;
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
            CreateSeatsLayout(vehiculoConfiguracion);
            ShowOccupation(viaje);
            CreateSeatsAssignationTable();

            return true;
        }

        #endregion

        #region Seats Layout

        private void CreateSeatsLayout(VehiculoConfiguracion vehiculoConfiguracion)
        {
            SuspendLayout();

            DestroyPreviousSeatsLayout();
            CreateSeatsPanel(vehiculoConfiguracion);
            CreateSeatsButtonsSequentially(vehiculoConfiguracion);
            // CreateSeatsButtonsIndexed(vehiculoConfiguracion);

            ResumeLayout();
        }

        private void DestroyPreviousSeatsLayout()
        {
            if (panelSeatLayout != null)
            {
                // Clean old seats buttons
                foreach (Control button in panelSeatLayout.Controls)
                {
                    panelSeatLayout.Controls.Remove(button);
                    button.Dispose();
                }

                panelSeatLayout.Dispose();
            }
            seatsMap.Clear();
        }

        private void CreateSeatsPanel(VehiculoConfiguracion vehiculoConfiguracion)
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

            ResizeAndPositionSeatsPanel();
        }

        private void ResizeAndPositionSeatsPanel()
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

        private void CreateSeatsButtonsSequentially(VehiculoConfiguracion vehiculoConfiguracion)
        {
            int row = 0;
            int column = 0;

            foreach (VehiculoConfiguracionDetalle detalle in vehiculoConfiguracion.VehiculoConfiguracionDetalles)
            {
                if (detalle.Tipo != VehiculoConfiguracionDetalle.TipoEspacio)
                {
                    CreateSeatButton(row, column, detalle);
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

        private void CreateSeatsButtonsIndexed(VehiculoConfiguracion vehiculoConfiguracion)
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
                        CreateSeatButton(row, column, detalle);
                    }
                }
            }
        }

        private void CreateSeatButton(int row, int column, VehiculoConfiguracionDetalle detalle)
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
            button.Paint += Seat_Paint;
            button = null;

            // Draw seat number on screen


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

        private void Seat_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBoxSeat = (PictureBox)sender;
            string asiento = CardonerSistemas.String.GetSubString(pictureBoxSeat.Tag.ToString(), 1, "|");
            if (asiento != string.Empty)
            {
                Brush brush;
                if (kioskoConfiguracion.ValorVehiculoConfiguracionAsientoIdentificacionForeColor.HasValue)
                {
                    brush = new SolidBrush(kioskoConfiguracion.ValorVehiculoConfiguracionAsientoIdentificacionForeColor.Value);
                }
                else
                {
                    brush = Brushes.Black;
                }
                Point point = new Point(kioskoConfiguracion.ValorVehiculoConfiguracionAsientoIdentificacionPosicionX, kioskoConfiguracion.ValorVehiculoConfiguracionAsientoIdentificacionPosicionY);

                e.Graphics.DrawString(asiento, kioskoConfiguracion.ValorVehiculoConfiguracionAsientoIdentificacionFont, brush, point);
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
                    if (seatsAssignation.Count == cantidadAsientosASeleccionar)
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
                        foreach (BusquedaReservas.Persona persona in personas)
                        {
                            if (!seatsAssignation.ContainsValue(persona.IDPersona))
                            {
                                seatsAssignation.Add(asiento, persona.IDPersona);
                                break;
                            }
                        }
                        SeatsAssignationTableRefresh();
                    }
                    break;
                case VehiculoConfiguracionDetalle.TipoAsientoSeleccionado:
                    pictureBox.Image = kioskoConfiguracion.ValorVehiculoConfiguracionAsientoLibre;
                    pictureBox.Tag = String.Format("{0}|{1}", VehiculoConfiguracionDetalle.TipoAsiento, asiento);
                    seatsAssignation.Remove(asiento);
                    SeatsAssignationTableRefresh();
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Seats assignation table

        private void CreateSeatsAssignationTable()
        {
            SuspendLayout();

            DestroyPreviousSeatsAssignationTable();
            CreateSeatsAssignationTablePanelHeaders();
            CreateSeatsAssignationTablePanelRows();

            ResumeLayout();
        }

        private void DestroyPreviousSeatsAssignationTable()
        {
            if (panelSeatsAssignation != null)
            {
                foreach (Label label in panelSeatsAssignation.Controls)
                {
                    panelSeatsAssignation.Controls.Remove(label);
                    label.Dispose();
                }

                panelSeatsAssignation.Dispose();
            }

            seatsAssignation.Clear();
        }

        private void CreateSeatsAssignationTablePanelHeaders()
        {
            // Create the TableLayoutPanel
            panelSeatsAssignation = new TableLayoutPanel();
            panelSeatsAssignationContainer.Controls.Add(panelSeatsAssignation, 1, 1);
            panelSeatsAssignation.Dock = DockStyle.Fill;
            panelSeatsAssignation.Name = "panelSeatsAssignation";
            panelSeatsAssignation.Location = new System.Drawing.Point(0, 0);
            panelSeatsAssignation.TabIndex = 0;
            panelSeatsAssignation.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            panelSeatsAssignation.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelSeatsAssignation.AutoSize = true;

            // Prepare columns
            panelSeatsAssignation.ColumnCount = 2;
            for (int column = 0; column < panelSeatsAssignation.ColumnCount; column++)
            {
                panelSeatsAssignation.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            }

            // Prepare header columns labels
            Single height = Convert.ToSingle(100) / Convert.ToSingle(personas.Count + 1);
            panelSeatsAssignation.RowCount = personas.Count + 1;
            panelSeatsAssignation.RowStyles.Add(new RowStyle(SizeType.Percent, height));
            // Passenger header
            Label labelPassengerHeader = new Label();
            panelSeatsAssignation.Controls.Add(labelPassengerHeader, 0, 0);
            labelPassengerHeader.AutoSize = true;
            labelPassengerHeader.Name = "labelPassengerHeader";
            labelPassengerHeader.Text = "Pasajero";
            labelPassengerHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            labelPassengerHeader.Dock = DockStyle.Fill;
            labelPassengerHeader.Font = kioskoConfiguracion.ValorInformacionPrincipalFont;
            // Seats header
            Label labelSeatHeader = new Label();
            panelSeatsAssignation.Controls.Add(labelSeatHeader, 1, 0);
            labelSeatHeader.AutoSize = true;
            labelSeatHeader.Name = "labelSeatHeader";
            labelSeatHeader.Text = "Asiento";
            labelSeatHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            labelSeatHeader.Dock = DockStyle.Fill;
            labelSeatHeader.Font = labelPassengerHeader.Font;
        }

        private void CreateSeatsAssignationTablePanelRows()
        {
            Single height = Convert.ToSingle(100) / Convert.ToSingle(panelSeatsAssignation.RowCount);

            // Prepare rows
            for (int row = 1; row < panelSeatsAssignation.RowCount; row++)
            {
                panelSeatsAssignation.RowStyles.Add(new RowStyle(SizeType.Percent, height));

                // Create passenger label
                Label labelPasajero = new Label();
                panelSeatsAssignation.Controls.Add(labelPasajero, 0, row);
                labelPasajero.Text = personas[row - 1].ApellidoNombre;
                labelPasajero.Font = kioskoConfiguracion.ValorInformacionSecundariaFont;
                labelPasajero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                labelPasajero.AutoSize = true;
                labelPasajero.Dock = DockStyle.Fill;

                // Create seat label
                Label labelAsiento = new Label();
                panelSeatsAssignation.Controls.Add(labelAsiento, 1, row);
                labelAsiento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                labelAsiento.Font = kioskoConfiguracion.ValorInformacionSecundariaFont;
                labelAsiento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                labelAsiento.AutoSize = true;
                labelAsiento.Dock = DockStyle.Fill;
            }
        }

        private void SeatsAssignationTableRefresh()
        {
            for (int personaindex = 0; personaindex < personas.Count; personaindex++)
            {
                Label labelAsiento = (Label)panelSeatsAssignation.GetControlFromPosition(1, personaindex + 1);
                string asiento = seatsAssignation.FirstOrDefault(s => s.Value == personas[personaindex].IDPersona).Key;
                if (asiento == null)
                {
                    labelAsiento.Text = string.Empty;
                }
                else
                {
                    labelAsiento.Text = asiento;
                }
            }
        }

        #endregion

    }
}
