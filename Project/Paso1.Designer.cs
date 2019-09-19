namespace CSTransporteKiosko
{
    partial class Paso1
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
            this.panelPaso1 = new System.Windows.Forms.TableLayoutPanel();
            this.radioPaso1_Documento = new System.Windows.Forms.RadioButton();
            this.radioPaso1_Reserva = new System.Windows.Forms.RadioButton();
            this.panelPaso1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPaso1
            // 
            this.panelPaso1.ColumnCount = 3;
            this.panelPaso1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelPaso1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelPaso1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelPaso1.Controls.Add(this.radioPaso1_Documento, 1, 1);
            this.panelPaso1.Controls.Add(this.radioPaso1_Reserva, 1, 3);
            this.panelPaso1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPaso1.Location = new System.Drawing.Point(0, 0);
            this.panelPaso1.Name = "panelPaso1";
            this.panelPaso1.RowCount = 5;
            this.panelPaso1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelPaso1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelPaso1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelPaso1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelPaso1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelPaso1.Size = new System.Drawing.Size(480, 317);
            this.panelPaso1.TabIndex = 5;
            // 
            // radioPaso1_Documento
            // 
            this.radioPaso1_Documento.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioPaso1_Documento.AutoSize = true;
            this.radioPaso1_Documento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.radioPaso1_Documento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioPaso1_Documento.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radioPaso1_Documento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioPaso1_Documento.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.radioPaso1_Documento.Location = new System.Drawing.Point(74, 66);
            this.radioPaso1_Documento.Name = "radioPaso1_Documento";
            this.radioPaso1_Documento.Size = new System.Drawing.Size(331, 57);
            this.radioPaso1_Documento.TabIndex = 7;
            this.radioPaso1_Documento.TabStop = true;
            this.radioPaso1_Documento.Text = "Ingresar con Nº de Documento";
            this.radioPaso1_Documento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioPaso1_Documento.UseVisualStyleBackColor = false;
            // 
            // radioPaso1_Reserva
            // 
            this.radioPaso1_Reserva.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioPaso1_Reserva.AutoSize = true;
            this.radioPaso1_Reserva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.radioPaso1_Reserva.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioPaso1_Reserva.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radioPaso1_Reserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioPaso1_Reserva.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.radioPaso1_Reserva.Location = new System.Drawing.Point(74, 192);
            this.radioPaso1_Reserva.Name = "radioPaso1_Reserva";
            this.radioPaso1_Reserva.Size = new System.Drawing.Size(331, 57);
            this.radioPaso1_Reserva.TabIndex = 6;
            this.radioPaso1_Reserva.TabStop = true;
            this.radioPaso1_Reserva.Text = "Ingresar con Nº de Reserva";
            this.radioPaso1_Reserva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioPaso1_Reserva.UseVisualStyleBackColor = false;
            // 
            // Paso1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelPaso1);
            this.Name = "Paso1";
            this.Size = new System.Drawing.Size(480, 317);
            this.panelPaso1.ResumeLayout(false);
            this.panelPaso1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelPaso1;
        private System.Windows.Forms.RadioButton radioPaso1_Documento;
        private System.Windows.Forms.RadioButton radioPaso1_Reserva;
    }
}
