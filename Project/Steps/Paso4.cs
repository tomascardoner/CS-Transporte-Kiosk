using CardonerSistemas.Database.ADO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CSTransporteKiosko
{
    public partial class Paso4 : UserControl
    {
        private FormMessageBox messageBox;
        private KioskoConfiguracion kioskoConfiguracion;
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
        private int seatsSelected = 0;

        public Paso4()
        {
            InitializeComponent();
        }

        public bool Verificar(ref FormMessageBox messageBox, int cantidadPersonas)
        {
            int asientosPendientesDeSeleccionar = cantidadPersonas - seatsSelected;
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

        public bool PrepararParaMostrar(FormMessageBox formMessageBox, SQLServer dbLocal, SQLServer dbEmpresa, KioskoConfiguracion kioskoConfig, byte idVehiculoConfiguracion, int idViaje, int cantidadPersonasSeleccionadas)
        {
            messageBox = formMessageBox;
            kioskoConfiguracion = kioskoConfig;
            VehiculoConfiguracion vehiculoConfiguracion = new VehiculoConfiguracion();
            Viaje viaje = new Viaje();
            cantidadAsientosASeleccionar = cantidadPersonasSeleccionadas;

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
            return true;
        }

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
        }

        private void CreatePanel(VehiculoConfiguracion vehiculoConfiguracion)
        {
            // Create the TableLayoutPanel
            panelSeatLayout = new TableLayoutPanel();
            panelSeatLayout.Name = "panelLayout";
            // panelSeatLayout.Dock = DockStyle.Fill;
            panelSeatLayout.Location = new System.Drawing.Point(0, 0);
            panelSeatLayout.TabIndex = 0;
            Controls.Add(panelSeatLayout);
            panelSeatLayout.Padding = new Padding(4);

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

            // Establezco la posición
            int x = (ClientSize.Width - panelSeatLayout.Width) / 2;
            int y = (ClientSize.Height - panelSeatLayout.Height) / 2;
            panelSeatLayout.Location = new System.Drawing.Point(x, y);
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
            button.Name = string.Format("{0}{1}{2}{3}{4}", SeatNamePrefix, SeatNameRowPrefix, row, SeatNameColumnPrefix, column);
            button.Tag = detalle.Tipo;
            button.Image = detalle.TipoImagen(kioskoConfiguracion);
            button.SizeMode = PictureBoxSizeMode.Zoom;
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
                        button.Tag = VehiculoConfiguracionDetalle.TipoAsientoOcupado;
                        button.Image = kioskoConfiguracion.ValorVehiculoConfiguracionAsientoOcupado;
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
                    messageBox.Show("No se puede seleccionar el asiento del Conductor.");
                    break;
                case VehiculoConfiguracionDetalle.TipoAsientoOcupado:
                    messageBox.Show("No se puede seleccionar este asiento ya que se encuentra ocupado.");
                    break;
                case VehiculoConfiguracionDetalle.TipoAsiento:
                    if (seatsSelected == cantidadAsientosASeleccionar)
                    {
                        messageBox.Show(String.Format("Ya se han seleccionado los {0} asientos.", cantidadAsientosASeleccionar));
                    }
                    else
                    {
                        pictureBox.Tag = VehiculoConfiguracionDetalle.TipoAsientoSeleccionado;
                        pictureBox.Image = kioskoConfiguracion.ValorVehiculoConfiguracionAsientoSeleccionado;
                        seatsSelected++;
                    }
                    break;
                case VehiculoConfiguracionDetalle.TipoAsientoSeleccionado:
                    pictureBox.Tag = VehiculoConfiguracionDetalle.TipoAsiento;
                    pictureBox.Image = kioskoConfiguracion.ValorVehiculoConfiguracionAsientoLibre;
                    seatsSelected--;
                    break;
                default:
                    break;
            }
        }

        #endregion

    }
}
