using System.Windows.Forms;

namespace CSTransporteKiosko
{
    public partial class Paso3 : UserControl
    {
        public Paso3()
        {
            InitializeComponent();
        }

        public void SetAppearance(KioskoConfiguracion configuracion)
        {
            // Apariencia
            panelPaso3.BackColor = CardonerSistemas.Colors.CardonerSistemas.Colors.SetColor(configuracion.ValorScreenBackColor, panelPaso3.BackColor);

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
    }
}
