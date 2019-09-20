using System;
using System.Windows.Forms;

namespace CSTransporteKiosko
{
    public partial class FormWelcome : Form
    {
        public FormWelcome()
        {
            InitializeComponent();
        }

        public void SetAppearance(KioskoConfiguracion configuracion)
        {
            // Apariencia
            this.Icon = Properties.Resources.ICON_APP;
            this.BackColor = CardonerSistemas.Colors.SetColor(configuracion.ValorScreenBackColor, this.BackColor);
            panelInicio.BackColor = CardonerSistemas.Colors.SetColor(configuracion.ValorInformacionPrincipalForeColor, panelInicio.BackColor);
            labelIniciar.ForeColor = CardonerSistemas.Colors.SetColor(configuracion.ValorInformacionPrincipalForeColor, labelIniciar.ForeColor);
            labelIniciar.Font = configuracion.ValorInformacionPrincipalFont;

            // Media
            wmPlayer.uiMode = "none";
            wmPlayer.URL = configuracion.ValorVideo;
        }

        private void wmPlayer_Click(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {
            Iniciar();
        }

        private void labelIniciar_Click(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            //inactivityTimeout = DateTime.Now;
            //if (pasoNumero == 0)
            //{
            //    if (wmInicio_Player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            //    {
            //        wmInicio_Player.Ctlcontrols.stop();
            //    }
            //}
        }
    }
}
