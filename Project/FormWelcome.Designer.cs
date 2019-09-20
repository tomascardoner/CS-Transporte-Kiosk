namespace CSTransporteKiosko
{
    partial class FormWelcome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWelcome));
            this.panelInicio = new System.Windows.Forms.TableLayoutPanel();
            this.labelIniciar = new System.Windows.Forms.Label();
            this.wmPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.panelInicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wmPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInicio
            // 
            this.panelInicio.ColumnCount = 1;
            this.panelInicio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelInicio.Controls.Add(this.wmPlayer, 0, 0);
            this.panelInicio.Controls.Add(this.labelIniciar, 0, 1);
            this.panelInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInicio.Location = new System.Drawing.Point(0, 0);
            this.panelInicio.Name = "panelInicio";
            this.panelInicio.RowCount = 2;
            this.panelInicio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelInicio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.panelInicio.Size = new System.Drawing.Size(800, 450);
            this.panelInicio.TabIndex = 6;
            // 
            // labelIniciar
            // 
            this.labelIniciar.AutoSize = true;
            this.labelIniciar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelIniciar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIniciar.Location = new System.Drawing.Point(3, 400);
            this.labelIniciar.Name = "labelIniciar";
            this.labelIniciar.Size = new System.Drawing.Size(794, 50);
            this.labelIniciar.TabIndex = 4;
            this.labelIniciar.Text = "Toque la pantalla para comenzar";
            this.labelIniciar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelIniciar.Click += new System.EventHandler(this.labelIniciar_Click);
            // 
            // wmPlayer
            // 
            this.wmPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wmPlayer.Enabled = true;
            this.wmPlayer.Location = new System.Drawing.Point(3, 3);
            this.wmPlayer.Name = "wmPlayer";
            this.wmPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmPlayer.OcxState")));
            this.wmPlayer.Size = new System.Drawing.Size(794, 394);
            this.wmPlayer.TabIndex = 1;
            this.wmPlayer.ClickEvent += new AxWMPLib._WMPOCXEvents_ClickEventHandler(this.wmPlayer_Click);
            // 
            // FormWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.panelInicio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FormWelcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelInicio.ResumeLayout(false);
            this.panelInicio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wmPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelInicio;
        private System.Windows.Forms.Label labelIniciar;
        private AxWMPLib.AxWindowsMediaPlayer wmPlayer;
    }
}