namespace CSTransporteKiosko
{
    partial class Paso2
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelPaso2 = new System.Windows.Forms.TableLayoutPanel();
            this.textboxPaso2_Valor = new System.Windows.Forms.TextBox();
            this.labelPaso2_Valor = new System.Windows.Forms.Label();
            this.keyboardMain = new CardonerSistemas.OnScreenKeyboard();
            this.panelPaso2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPaso2
            // 
            this.panelPaso2.BackColor = System.Drawing.Color.White;
            this.panelPaso2.ColumnCount = 4;
            this.panelPaso2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelPaso2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelPaso2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.panelPaso2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelPaso2.Controls.Add(this.labelPaso2_Valor, 1, 1);
            this.panelPaso2.Controls.Add(this.textboxPaso2_Valor, 2, 1);
            this.panelPaso2.Controls.Add(this.keyboardMain, 2, 2);
            this.panelPaso2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPaso2.Location = new System.Drawing.Point(0, 0);
            this.panelPaso2.Name = "panelPaso2";
            this.panelPaso2.RowCount = 3;
            this.panelPaso2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.panelPaso2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelPaso2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.panelPaso2.Size = new System.Drawing.Size(687, 506);
            this.panelPaso2.TabIndex = 7;
            this.panelPaso2.Visible = false;
            // 
            // textboxPaso2_Valor
            // 
            this.textboxPaso2_Valor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textboxPaso2_Valor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textboxPaso2_Valor.Enabled = false;
            this.textboxPaso2_Valor.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.textboxPaso2_Valor.Location = new System.Drawing.Point(365, 189);
            this.textboxPaso2_Valor.MaxLength = 8;
            this.textboxPaso2_Valor.Name = "textboxPaso2_Valor";
            this.textboxPaso2_Valor.Size = new System.Drawing.Size(150, 35);
            this.textboxPaso2_Valor.TabIndex = 2;
            this.textboxPaso2_Valor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelPaso2_Valor
            // 
            this.labelPaso2_Valor.AutoSize = true;
            this.labelPaso2_Valor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPaso2_Valor.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelPaso2_Valor.Location = new System.Drawing.Point(28, 186);
            this.labelPaso2_Valor.Name = "labelPaso2_Valor";
            this.labelPaso2_Valor.Size = new System.Drawing.Size(331, 41);
            this.labelPaso2_Valor.TabIndex = 1;
            this.labelPaso2_Valor.Text = "Ingrese el Documento / Reserva:";
            this.labelPaso2_Valor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // keyboardMain
            // 
            this.keyboardMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyboardMain.DestinationTextBox = this.textboxPaso2_Valor;
            this.keyboardMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyboardMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.keyboardMain.KeyBackColor = System.Drawing.SystemColors.Control;
            this.keyboardMain.KeyboardLayout = CardonerSistemas.OnScreenKeyboard.KeyboardLayoutEnums.NumericCalculator;
            this.keyboardMain.Location = new System.Drawing.Point(365, 230);
            this.keyboardMain.Name = "keyboardMain";
            this.keyboardMain.Size = new System.Drawing.Size(294, 273);
            this.keyboardMain.TabIndex = 3;
            // 
            // Paso2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelPaso2);
            this.Name = "Paso2";
            this.Size = new System.Drawing.Size(687, 506);
            this.panelPaso2.ResumeLayout(false);
            this.panelPaso2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelPaso2;
        private System.Windows.Forms.Label labelPaso2_Valor;
        private System.Windows.Forms.TextBox textboxPaso2_Valor;
        private CardonerSistemas.OnScreenKeyboard keyboardMain;
    }
}
