namespace CSTransporteKiosko
{
    partial class Paso3
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
            C1.Win.C1Tile.PanelElement panelElement1 = new C1.Win.C1Tile.PanelElement();
            C1.Win.C1Tile.ImageElement imageElement1 = new C1.Win.C1Tile.ImageElement();
            C1.Win.C1Tile.TextElement textElement1 = new C1.Win.C1Tile.TextElement();
            this.panelPaso3 = new System.Windows.Forms.TableLayoutPanel();
            this.panelViaje_Personas = new System.Windows.Forms.TableLayoutPanel();
            this.panelViaje = new System.Windows.Forms.TableLayoutPanel();
            this.labelViaje_Vehiculo = new System.Windows.Forms.Label();
            this.labelViaje_Vehiculo_Leyenda = new System.Windows.Forms.Label();
            this.panelViaje_Origen = new System.Windows.Forms.TableLayoutPanel();
            this.labelViaje_Origen_FechaHora = new System.Windows.Forms.Label();
            this.labelViaje_Origen_Lugar = new System.Windows.Forms.Label();
            this.labelViaje_Origen_Leyenda = new System.Windows.Forms.Label();
            this.labelViaje_Destino_Leyenda = new System.Windows.Forms.Label();
            this.panelViaje_Destino = new System.Windows.Forms.TableLayoutPanel();
            this.labelViaje_Destino_FechaHora = new System.Windows.Forms.Label();
            this.labelViaje_Destino_Lugar = new System.Windows.Forms.Label();
            this.tilecontrolPasajeros = new C1.Win.C1Tile.C1TileControl();
            this.groupMain = new C1.Win.C1Tile.Group();
            this.tile1 = new C1.Win.C1Tile.Tile();
            this.panelPaso3.SuspendLayout();
            this.panelViaje_Personas.SuspendLayout();
            this.panelViaje.SuspendLayout();
            this.panelViaje_Origen.SuspendLayout();
            this.panelViaje_Destino.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPaso3
            // 
            this.panelPaso3.ColumnCount = 3;
            this.panelPaso3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelPaso3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelPaso3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelPaso3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelPaso3.Controls.Add(this.panelViaje_Personas, 1, 0);
            this.panelPaso3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPaso3.Location = new System.Drawing.Point(0, 0);
            this.panelPaso3.Name = "panelPaso3";
            this.panelPaso3.RowCount = 1;
            this.panelPaso3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelPaso3.Size = new System.Drawing.Size(832, 499);
            this.panelPaso3.TabIndex = 8;
            this.panelPaso3.Visible = false;
            // 
            // panelViaje_Personas
            // 
            this.panelViaje_Personas.ColumnCount = 1;
            this.panelViaje_Personas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelViaje_Personas.Controls.Add(this.panelViaje, 0, 0);
            this.panelViaje_Personas.Controls.Add(this.tilecontrolPasajeros, 0, 1);
            this.panelViaje_Personas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelViaje_Personas.Location = new System.Drawing.Point(33, 3);
            this.panelViaje_Personas.Name = "panelViaje_Personas";
            this.panelViaje_Personas.RowCount = 2;
            this.panelViaje_Personas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.panelViaje_Personas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelViaje_Personas.Size = new System.Drawing.Size(766, 493);
            this.panelViaje_Personas.TabIndex = 0;
            // 
            // panelViaje
            // 
            this.panelViaje.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.panelViaje.ColumnCount = 2;
            this.panelViaje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelViaje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.panelViaje.Controls.Add(this.labelViaje_Vehiculo, 1, 2);
            this.panelViaje.Controls.Add(this.labelViaje_Vehiculo_Leyenda, 0, 2);
            this.panelViaje.Controls.Add(this.panelViaje_Origen, 1, 0);
            this.panelViaje.Controls.Add(this.labelViaje_Origen_Leyenda, 0, 0);
            this.panelViaje.Controls.Add(this.labelViaje_Destino_Leyenda, 0, 1);
            this.panelViaje.Controls.Add(this.panelViaje_Destino, 1, 1);
            this.panelViaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelViaje.Location = new System.Drawing.Point(3, 3);
            this.panelViaje.Name = "panelViaje";
            this.panelViaje.RowCount = 3;
            this.panelViaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelViaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelViaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelViaje.Size = new System.Drawing.Size(760, 174);
            this.panelViaje.TabIndex = 2;
            // 
            // labelViaje_Vehiculo
            // 
            this.labelViaje_Vehiculo.AutoSize = true;
            this.labelViaje_Vehiculo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelViaje_Vehiculo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelViaje_Vehiculo.Location = new System.Drawing.Point(156, 115);
            this.labelViaje_Vehiculo.Name = "labelViaje_Vehiculo";
            this.labelViaje_Vehiculo.Size = new System.Drawing.Size(600, 58);
            this.labelViaje_Vehiculo.TabIndex = 6;
            this.labelViaje_Vehiculo.Text = "Nombre del vehículo";
            this.labelViaje_Vehiculo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelViaje_Vehiculo_Leyenda
            // 
            this.labelViaje_Vehiculo_Leyenda.AutoSize = true;
            this.labelViaje_Vehiculo_Leyenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelViaje_Vehiculo_Leyenda.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelViaje_Vehiculo_Leyenda.Location = new System.Drawing.Point(4, 115);
            this.labelViaje_Vehiculo_Leyenda.Name = "labelViaje_Vehiculo_Leyenda";
            this.labelViaje_Vehiculo_Leyenda.Size = new System.Drawing.Size(145, 58);
            this.labelViaje_Vehiculo_Leyenda.TabIndex = 5;
            this.labelViaje_Vehiculo_Leyenda.Text = "Vehículo:";
            this.labelViaje_Vehiculo_Leyenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelViaje_Origen
            // 
            this.panelViaje_Origen.ColumnCount = 1;
            this.panelViaje_Origen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelViaje_Origen.Controls.Add(this.labelViaje_Origen_FechaHora, 0, 1);
            this.panelViaje_Origen.Controls.Add(this.labelViaje_Origen_Lugar, 0, 0);
            this.panelViaje_Origen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelViaje_Origen.Location = new System.Drawing.Point(156, 4);
            this.panelViaje_Origen.Name = "panelViaje_Origen";
            this.panelViaje_Origen.RowCount = 2;
            this.panelViaje_Origen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelViaje_Origen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelViaje_Origen.Size = new System.Drawing.Size(600, 50);
            this.panelViaje_Origen.TabIndex = 4;
            // 
            // labelViaje_Origen_FechaHora
            // 
            this.labelViaje_Origen_FechaHora.AutoSize = true;
            this.labelViaje_Origen_FechaHora.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelViaje_Origen_FechaHora.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelViaje_Origen_FechaHora.Location = new System.Drawing.Point(3, 30);
            this.labelViaje_Origen_FechaHora.Name = "labelViaje_Origen_FechaHora";
            this.labelViaje_Origen_FechaHora.Size = new System.Drawing.Size(594, 20);
            this.labelViaje_Origen_FechaHora.TabIndex = 4;
            this.labelViaje_Origen_FechaHora.Text = "Fecha y hora de salida";
            this.labelViaje_Origen_FechaHora.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelViaje_Origen_Lugar
            // 
            this.labelViaje_Origen_Lugar.AutoSize = true;
            this.labelViaje_Origen_Lugar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelViaje_Origen_Lugar.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelViaje_Origen_Lugar.Location = new System.Drawing.Point(3, 0);
            this.labelViaje_Origen_Lugar.Name = "labelViaje_Origen_Lugar";
            this.labelViaje_Origen_Lugar.Size = new System.Drawing.Size(594, 30);
            this.labelViaje_Origen_Lugar.TabIndex = 3;
            this.labelViaje_Origen_Lugar.Text = "Parada de origen y lugar";
            this.labelViaje_Origen_Lugar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelViaje_Origen_Leyenda
            // 
            this.labelViaje_Origen_Leyenda.AutoSize = true;
            this.labelViaje_Origen_Leyenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelViaje_Origen_Leyenda.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelViaje_Origen_Leyenda.Location = new System.Drawing.Point(4, 1);
            this.labelViaje_Origen_Leyenda.Name = "labelViaje_Origen_Leyenda";
            this.labelViaje_Origen_Leyenda.Size = new System.Drawing.Size(145, 56);
            this.labelViaje_Origen_Leyenda.TabIndex = 0;
            this.labelViaje_Origen_Leyenda.Text = "Salida de:";
            this.labelViaje_Origen_Leyenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelViaje_Destino_Leyenda
            // 
            this.labelViaje_Destino_Leyenda.AutoSize = true;
            this.labelViaje_Destino_Leyenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelViaje_Destino_Leyenda.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelViaje_Destino_Leyenda.Location = new System.Drawing.Point(4, 58);
            this.labelViaje_Destino_Leyenda.Name = "labelViaje_Destino_Leyenda";
            this.labelViaje_Destino_Leyenda.Size = new System.Drawing.Size(145, 56);
            this.labelViaje_Destino_Leyenda.TabIndex = 1;
            this.labelViaje_Destino_Leyenda.Text = "Llegada a:";
            this.labelViaje_Destino_Leyenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelViaje_Destino
            // 
            this.panelViaje_Destino.ColumnCount = 1;
            this.panelViaje_Destino.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelViaje_Destino.Controls.Add(this.labelViaje_Destino_FechaHora, 0, 1);
            this.panelViaje_Destino.Controls.Add(this.labelViaje_Destino_Lugar, 0, 0);
            this.panelViaje_Destino.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelViaje_Destino.Location = new System.Drawing.Point(156, 61);
            this.panelViaje_Destino.Name = "panelViaje_Destino";
            this.panelViaje_Destino.RowCount = 2;
            this.panelViaje_Destino.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelViaje_Destino.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelViaje_Destino.Size = new System.Drawing.Size(600, 50);
            this.panelViaje_Destino.TabIndex = 3;
            // 
            // labelViaje_Destino_FechaHora
            // 
            this.labelViaje_Destino_FechaHora.AutoSize = true;
            this.labelViaje_Destino_FechaHora.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelViaje_Destino_FechaHora.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelViaje_Destino_FechaHora.Location = new System.Drawing.Point(3, 30);
            this.labelViaje_Destino_FechaHora.Name = "labelViaje_Destino_FechaHora";
            this.labelViaje_Destino_FechaHora.Size = new System.Drawing.Size(594, 20);
            this.labelViaje_Destino_FechaHora.TabIndex = 4;
            this.labelViaje_Destino_FechaHora.Text = "Fecha y hora de llegada";
            this.labelViaje_Destino_FechaHora.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelViaje_Destino_Lugar
            // 
            this.labelViaje_Destino_Lugar.AutoSize = true;
            this.labelViaje_Destino_Lugar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelViaje_Destino_Lugar.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelViaje_Destino_Lugar.Location = new System.Drawing.Point(3, 0);
            this.labelViaje_Destino_Lugar.Name = "labelViaje_Destino_Lugar";
            this.labelViaje_Destino_Lugar.Size = new System.Drawing.Size(594, 30);
            this.labelViaje_Destino_Lugar.TabIndex = 3;
            this.labelViaje_Destino_Lugar.Text = "Parada de destino y lugar";
            this.labelViaje_Destino_Lugar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tilecontrolPasajeros
            // 
            this.tilecontrolPasajeros.AllowChecking = true;
            this.tilecontrolPasajeros.CellSpacing = 20;
            this.tilecontrolPasajeros.CellWidth = 200;
            // 
            // 
            // 
            panelElement1.Alignment = System.Drawing.ContentAlignment.BottomLeft;
            panelElement1.Children.Add(imageElement1);
            panelElement1.Children.Add(textElement1);
            panelElement1.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.tilecontrolPasajeros.DefaultTemplate.Elements.Add(panelElement1);
            this.tilecontrolPasajeros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilecontrolPasajeros.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tilecontrolPasajeros.GroupPadding = new System.Windows.Forms.Padding(20, 35, 20, 20);
            this.tilecontrolPasajeros.Groups.Add(this.groupMain);
            this.tilecontrolPasajeros.GroupTextY = 0;
            this.tilecontrolPasajeros.Location = new System.Drawing.Point(3, 183);
            this.tilecontrolPasajeros.Name = "tilecontrolPasajeros";
            this.tilecontrolPasajeros.Orientation = C1.Win.C1Tile.LayoutOrientation.Vertical;
            this.tilecontrolPasajeros.Padding = new System.Windows.Forms.Padding(0);
            this.tilecontrolPasajeros.Size = new System.Drawing.Size(760, 307);
            this.tilecontrolPasajeros.SurfaceContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tilecontrolPasajeros.TabIndex = 3;
            this.tilecontrolPasajeros.TextX = 0;
            this.tilecontrolPasajeros.TextY = 0;
            this.tilecontrolPasajeros.UncheckTilesOnClick = false;
            // 
            // groupMain
            // 
            this.groupMain.Name = "groupMain";
            this.groupMain.Text = "Seleccione las Personas que van a viajar:";
            this.groupMain.Tiles.Add(this.tile1);
            // 
            // tile1
            // 
            this.tile1.Name = "tile1";
            this.tile1.Text = "Pasajero nº 1";
            // 
            // Paso3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelPaso3);
            this.Name = "Paso3";
            this.Size = new System.Drawing.Size(832, 499);
            this.panelPaso3.ResumeLayout(false);
            this.panelViaje_Personas.ResumeLayout(false);
            this.panelViaje.ResumeLayout(false);
            this.panelViaje.PerformLayout();
            this.panelViaje_Origen.ResumeLayout(false);
            this.panelViaje_Origen.PerformLayout();
            this.panelViaje_Destino.ResumeLayout(false);
            this.panelViaje_Destino.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelPaso3;
        private System.Windows.Forms.TableLayoutPanel panelViaje_Personas;
        private System.Windows.Forms.TableLayoutPanel panelViaje;
        private System.Windows.Forms.Label labelViaje_Vehiculo;
        private System.Windows.Forms.Label labelViaje_Vehiculo_Leyenda;
        private System.Windows.Forms.TableLayoutPanel panelViaje_Origen;
        private System.Windows.Forms.Label labelViaje_Origen_FechaHora;
        private System.Windows.Forms.Label labelViaje_Origen_Lugar;
        private System.Windows.Forms.Label labelViaje_Origen_Leyenda;
        private System.Windows.Forms.Label labelViaje_Destino_Leyenda;
        private System.Windows.Forms.TableLayoutPanel panelViaje_Destino;
        private System.Windows.Forms.Label labelViaje_Destino_FechaHora;
        private System.Windows.Forms.Label labelViaje_Destino_Lugar;
        private C1.Win.C1Tile.C1TileControl tilecontrolPasajeros;
        private C1.Win.C1Tile.Group groupMain;
        private C1.Win.C1Tile.Tile tile1;
    }
}
