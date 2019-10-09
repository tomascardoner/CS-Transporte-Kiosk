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
            this.keyboardMain = new CardonerSistemas.OnScreenKeyboard();
            this.textboxValor = new System.Windows.Forms.TextBox();
            this.panelValorYBusqueda = new System.Windows.Forms.TableLayoutPanel();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.panelPaso2.SuspendLayout();
            this.panelValorYBusqueda.SuspendLayout();
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
            this.panelPaso2.Controls.Add(this.keyboardMain, 2, 2);
            this.panelPaso2.Controls.Add(this.panelValorYBusqueda, 2, 1);
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
            this.labelValor.Location = new System.Drawing.Point(28, 183);
            this.labelValor.Name = "labelValor";
            this.labelValor.Size = new System.Drawing.Size(331, 47);
            this.labelValor.TabIndex = 1;
            this.labelValor.Text = "Ingrese el Documento / Reserva:";
            this.labelValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // keyboardMain
            // 
            this.keyboardMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyboardMain.DestinationTextBox = this.textboxValor;
            this.keyboardMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyboardMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.keyboardMain.KeyBackColor = System.Drawing.SystemColors.Control;
            this.keyboardMain.KeyboardLayout = CardonerSistemas.OnScreenKeyboard.KeyboardLayoutEnums.NumericCalculator;
            this.keyboardMain.Location = new System.Drawing.Point(365, 233);
            this.keyboardMain.Name = "keyboardMain";
            this.keyboardMain.Size = new System.Drawing.Size(294, 270);
            this.keyboardMain.TabIndex = 3;
            // 
            // textboxValor
            // 
            this.textboxValor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textboxValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textboxValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textboxValor.Enabled = false;
            this.textboxValor.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.textboxValor.Location = new System.Drawing.Point(3, 3);
            this.textboxValor.MaxLength = 8;
            this.textboxValor.Name = "textboxValor";
            this.textboxValor.Size = new System.Drawing.Size(141, 35);
            this.textboxValor.TabIndex = 3;
            this.textboxValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textboxValor.WordWrap = false;
            // 
            // panelValorYBusqueda
            // 
            this.panelValorYBusqueda.AutoSize = true;
            this.panelValorYBusqueda.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelValorYBusqueda.ColumnCount = 2;
            this.panelValorYBusqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelValorYBusqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelValorYBusqueda.Controls.Add(this.textboxValor, 0, 0);
            this.panelValorYBusqueda.Controls.Add(this.buttonBuscar, 1, 0);
            this.panelValorYBusqueda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelValorYBusqueda.Location = new System.Drawing.Point(365, 186);
            this.panelValorYBusqueda.Name = "panelValorYBusqueda";
            this.panelValorYBusqueda.RowCount = 1;
            this.panelValorYBusqueda.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelValorYBusqueda.Size = new System.Drawing.Size(294, 41);
            this.panelValorYBusqueda.TabIndex = 4;
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.AutoSize = true;
            this.buttonBuscar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBuscar.Location = new System.Drawing.Point(150, 3);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(141, 35);
            this.buttonBuscar.TabIndex = 4;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
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
            this.panelValorYBusqueda.ResumeLayout(false);
            this.panelValorYBusqueda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelPaso2;
        private System.Windows.Forms.Label labelValor;
        private CardonerSistemas.OnScreenKeyboard keyboardMain;
        private System.Windows.Forms.TableLayoutPanel panelValorYBusqueda;
        private System.Windows.Forms.TextBox textboxValor;
        private System.Windows.Forms.Button buttonBuscar;
    }
}
