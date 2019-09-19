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
            this.labelInicio_LeyendaIniciar = new System.Windows.Forms.Label();
            this.wmInicio_Player = new AxWMPLib.AxWindowsMediaPlayer();
            this.panelInicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wmInicio_Player)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInicio
            // 
            this.panelInicio.ColumnCount = 1;
            this.panelInicio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelInicio.Controls.Add(this.labelInicio_LeyendaIniciar, 0, 1);
            this.panelInicio.Controls.Add(this.wmInicio_Player, 0, 0);
            this.panelInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInicio.Location = new System.Drawing.Point(0, 0);
            this.panelInicio.Name = "panelInicio";
            this.panelInicio.RowCount = 2;
            this.panelInicio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelInicio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.panelInicio.Size = new System.Drawing.Size(800, 450);
            this.panelInicio.TabIndex = 6;
            // 
            // labelInicio_LeyendaIniciar
            // 
            this.labelInicio_LeyendaIniciar.AutoSize = true;
            this.labelInicio_LeyendaIniciar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInicio_LeyendaIniciar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInicio_LeyendaIniciar.Location = new System.Drawing.Point(3, 400);
            this.labelInicio_LeyendaIniciar.Name = "labelInicio_LeyendaIniciar";
            this.labelInicio_LeyendaIniciar.Size = new System.Drawing.Size(794, 50);
            this.labelInicio_LeyendaIniciar.TabIndex = 4;
            this.labelInicio_LeyendaIniciar.Text = "Toque la pantalla para comenzar";
            this.labelInicio_LeyendaIniciar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wmInicio_Player
            // 
            this.wmInicio_Player.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wmInicio_Player.Enabled = true;
            this.wmInicio_Player.Location = new System.Drawing.Point(3, 3);
            this.wmInicio_Player.Name = "wmInicio_Player";
            this.wmInicio_Player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmInicio_Player.OcxState")));
            this.wmInicio_Player.Size = new System.Drawing.Size(794, 394);
            this.wmInicio_Player.TabIndex = 1;
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
            ((System.ComponentModel.ISupportInitialize)(this.wmInicio_Player)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelInicio;
        private System.Windows.Forms.Label labelInicio_LeyendaIniciar;
        private AxWMPLib.AxWindowsMediaPlayer wmInicio_Player;
    }
}