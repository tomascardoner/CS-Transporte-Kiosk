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
            this.radioDocumento = new System.Windows.Forms.RadioButton();
            this.radioReserva = new System.Windows.Forms.RadioButton();
            this.panelPaso1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPaso1
            // 
            this.panelPaso1.ColumnCount = 3;
            this.panelPaso1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelPaso1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelPaso1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelPaso1.Controls.Add(this.radioDocumento, 1, 1);
            this.panelPaso1.Controls.Add(this.radioReserva, 1, 3);
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
            // radioDocumento
            // 
            this.radioDocumento.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioDocumento.AutoSize = true;
            this.radioDocumento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.radioDocumento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioDocumento.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radioDocumento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioDocumento.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.radioDocumento.Location = new System.Drawing.Point(74, 66);
            this.radioDocumento.Name = "radioDocumento";
            this.radioDocumento.Size = new System.Drawing.Size(331, 57);
            this.radioDocumento.TabIndex = 7;
            this.radioDocumento.TabStop = true;
            this.radioDocumento.Text = "Ingresar con Nº de Documento";
            this.radioDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioDocumento.UseVisualStyleBackColor = false;
            // 
            // radioReserva
            // 
            this.radioReserva.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioReserva.AutoSize = true;
            this.radioReserva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.radioReserva.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioReserva.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radioReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioReserva.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.radioReserva.Location = new System.Drawing.Point(74, 192);
            this.radioReserva.Name = "radioReserva";
            this.radioReserva.Size = new System.Drawing.Size(331, 57);
            this.radioReserva.TabIndex = 6;
            this.radioReserva.TabStop = true;
            this.radioReserva.Text = "Ingresar con Nº de Reserva";
            this.radioReserva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioReserva.UseVisualStyleBackColor = false;
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
        private System.Windows.Forms.RadioButton radioReserva;
        private System.Windows.Forms.RadioButton radioDocumento;
    }
}
