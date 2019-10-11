using C1.Win.C1Tile;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CSTransporteKiosko
{
    public partial class Paso3 : UserControl
    {

        #region Declarations

        private List<BusquedaReservas.Persona> personasSeleccionadas = new List<BusquedaReservas.Persona>();

        public List<BusquedaReservas.Persona> PersonasSeleccionadas { get => personasSeleccionadas; }

        #endregion

        #region Main functions

        public Paso3()
        {
            InitializeComponent();
        }

        public void SetAppearance(KioskoConfiguracion configuracion)
        {
            // Apariencia
            panelPaso3.BackColor = CardonerSistemas.Colors.SetColor(configuracion.ValorScreenBackColor, panelPaso3.BackColor);

            labelViaje_Origen_Leyenda.Font = configuracion.ValorInformacionLeyendaFont;
            labelViaje_Origen_Leyenda.ForeColor = CardonerSistemas.Colors.SetColor(configuracion.ValorInformacionLeyendaForeColor, labelViaje_Origen_Leyenda.ForeColor);
            labelViaje_Destino_Leyenda.Font = configuracion.ValorInformacionLeyendaFont;
            labelViaje_Destino_Leyenda.ForeColor = CardonerSistemas.Colors.SetColor(configuracion.ValorInformacionLeyendaForeColor, labelViaje_Destino_Leyenda.ForeColor);
            labelViaje_Vehiculo_Leyenda.Font = configuracion.ValorInformacionLeyendaFont;
            labelViaje_Vehiculo_Leyenda.ForeColor = CardonerSistemas.Colors.SetColor(configuracion.ValorInformacionLeyendaForeColor, labelViaje_Vehiculo_Leyenda.ForeColor);

            labelViaje_Origen_Lugar.Font = configuracion.ValorInformacionPrincipalFont;
            labelViaje_Origen_Lugar.ForeColor = CardonerSistemas.Colors.SetColor(configuracion.ValorInformacionPrincipalForeColor, labelViaje_Origen_Lugar.ForeColor);
            labelViaje_Destino_Lugar.Font = configuracion.ValorInformacionPrincipalFont;
            labelViaje_Destino_Lugar.ForeColor = CardonerSistemas.Colors.SetColor(configuracion.ValorInformacionPrincipalForeColor, labelViaje_Destino_Lugar.ForeColor);
            labelViaje_Vehiculo.Font = configuracion.ValorInformacionPrincipalFont;
            labelViaje_Vehiculo.ForeColor = CardonerSistemas.Colors.SetColor(configuracion.ValorInformacionPrincipalForeColor, labelViaje_Vehiculo.ForeColor);

            labelViaje_Origen_FechaHora.Font = configuracion.ValorInformacionSecundariaFont;
            labelViaje_Origen_FechaHora.ForeColor = CardonerSistemas.Colors.SetColor(configuracion.ValorInformacionSecundariaForeColor, labelViaje_Origen_FechaHora.ForeColor);
            labelViaje_Destino_FechaHora.Font = configuracion.ValorInformacionSecundariaFont;
            labelViaje_Destino_FechaHora.ForeColor = CardonerSistemas.Colors.SetColor(configuracion.ValorInformacionSecundariaForeColor, labelViaje_Destino_FechaHora.ForeColor);
        }

        public void PrepararParaMostrar(List<BusquedaReservas.Persona>  personas)
        {
            // Origen
            labelViaje_Origen_Lugar.Text = String.Format("{1} en {0}", personas[0].LugarGrupoOrigen, personas[0].LugarOrigen);
            if (personas[0].FechaHoraOrigen.Date == DateTime.Now.Date)
            {
                labelViaje_Origen_FechaHora.Text = String.Format("El día de hoy ({0}) a las {1} hs.", personas[0].FechaHoraOrigen.ToShortDateString(), personas[0].FechaHoraOrigen.ToShortTimeString());
            }
            else
            {
                labelViaje_Origen_FechaHora.Text = String.Format("El día {0} a las {1} hs.", personas[0].FechaHoraOrigen.ToShortDateString(), personas[0].FechaHoraOrigen.ToShortTimeString());
            }

            // Destino
            labelViaje_Destino_Lugar.Text = String.Format("{1} en {0}", personas[0].LugarGrupoDestino, personas[0].LugarDestino);
            if (personas[0].FechaHoraDestino.Date == DateTime.Now.Date)
            {
                labelViaje_Destino_FechaHora.Text = String.Format("El día de hoy ({0}) a las {1} hs.", personas[0].FechaHoraDestino.ToShortDateString(), personas[0].FechaHoraDestino.ToShortTimeString());
            }
            else
            {
                labelViaje_Destino_FechaHora.Text = String.Format("El día {0} a las {1} hs.", personas[0].FechaHoraDestino.ToShortDateString(), personas[0].FechaHoraDestino.ToShortTimeString());
            }

            // Vehículo
            labelViaje_Vehiculo.Text = personas[0].VehiculoNombre;

            // Pasajeros
            personasSeleccionadas.Clear();
            tilecontrolPasajeros.Groups[0].Tiles.Clear();
            foreach (BusquedaReservas.Persona persona in personas)
            {
                Tile tileNuevo = new Tile();
                tileNuevo.Tag = persona;
                tileNuevo.Text = persona.ApellidoNombre;
                switch (tilecontrolPasajeros.Groups[0].Tiles.Count % 4)
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
                tilecontrolPasajeros.Groups[0].Tiles.Add(tileNuevo);
                tileNuevo = null;
            }
        }

        public bool Verificar(ref FormMessageBox messageBox)
        {
            if (tilecontrolPasajeros.CheckedTiles.Length == 0)
            {
                messageBox.Show("Debe seleccionar al menos una Persona.");
                return false;
            }
            else
            {
                foreach (Tile tileItem in tilecontrolPasajeros.CheckedTiles)
                {
                    personasSeleccionadas.Add((BusquedaReservas.Persona)tileItem.Tag);
                }
                return true;
            }
        }

        #endregion

        #region Events

        public void ClickEnPasajero(object sender, C1.Win.C1Tile.TileEventArgs e)
        {
            e.Tile.Checked = !e.Tile.Checked;

            // TODO: Raise activity event
        }

        #endregion

    }
}
