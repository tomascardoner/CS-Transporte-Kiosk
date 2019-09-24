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
            this.labelValor = new System.Windows.Forms.Label();
            this.textboxValor = new System.Windows.Forms.TextBox();
            this.keyboardMain = new CardonerSistemas.OnScreenKeyboard();
            this.panelPaso2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPaso2
            // 
            this.panelPaso2.ColumnCount = 4;
            this.panelPaso2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelPaso2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelPaso2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.panelPaso2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelPaso2.Controls.Add(this.labelValor, 1, 1);
            this.panelPaso2.Controls.Add(this.textboxValor, 2, 1);
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
            // 
            // labelValor
            // 
            this.labelValor.AutoSize = true;
            this.labelValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelValor.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelValor.Location = new System.Drawing.Point(28, 186);
            this.labelValor.Name = "labelValor";
            this.labelValor.Size = new System.Drawing.Size(331, 41);
            this.labelValor.TabIndex = 1;
            this.labelValor.Text = "Ingrese el Documento / Reserva:";
            this.labelValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textboxValor
            // 
            this.textboxValor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textboxValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textboxValor.Enabled = false;
            this.textboxValor.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.textboxValor.Location = new System.Drawing.Point(365, 189);
            this.textboxValor.MaxLength = 8;
            this.textboxValor.Name = "textboxValor";
            this.textboxValor.Size = new System.Drawing.Size(150, 35);
            this.textboxValor.TabIndex = 2;
            this.textboxValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // keyboardMain
            // 
            this.keyboardMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyboardMain.DestinationTextBox = this.textboxValor;
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
        private System.Windows.Forms.Label labelValor;
        private System.Windows.Forms.TextBox textboxValor;
        private CardonerSistemas.OnScreenKeyboard keyboardMain;
    }
}
