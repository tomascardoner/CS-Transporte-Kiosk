namespace CSTransporteKiosko
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            C1.Win.C1Tile.PanelElement panelElement1 = new C1.Win.C1Tile.PanelElement();
            C1.Win.C1Tile.ImageElement imageElement1 = new C1.Win.C1Tile.ImageElement();
            C1.Win.C1Tile.TextElement textElement1 = new C1.Win.C1Tile.TextElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelPasos = new System.Windows.Forms.TableLayoutPanel();
            this.pictureboxLogoEmpresa = new System.Windows.Forms.PictureBox();
            this.panelUser = new System.Windows.Forms.Panel();
            this.panelPaso2 = new System.Windows.Forms.TableLayoutPanel();
            this.textboxPaso2_Valor = new System.Windows.Forms.TextBox();
            this.labelPaso2_Valor = new System.Windows.Forms.Label();
            this.panelPaso1 = new System.Windows.Forms.TableLayoutPanel();
            this.radioPaso1_Documento = new System.Windows.Forms.RadioButton();
            this.radioPaso1_Reserva = new System.Windows.Forms.RadioButton();
            this.panelPaso3 = new System.Windows.Forms.TableLayoutPanel();
            this.panelPaso3_Viaje_Personas = new System.Windows.Forms.TableLayoutPanel();
            this.panelPaso3_Viaje = new System.Windows.Forms.TableLayoutPanel();
            this.labelPaso3_Viaje_Vehiculo = new System.Windows.Forms.Label();
            this.labelPaso3_Viaje_Vehiculo_Leyenda = new System.Windows.Forms.Label();
            this.panelPaso3_Viaje_Origen = new System.Windows.Forms.TableLayoutPanel();
            this.labelPaso3_Viaje_Origen_FechaHora = new System.Windows.Forms.Label();
            this.labelPaso3_Viaje_Origen_Lugar = new System.Windows.Forms.Label();
            this.labelPaso3_Viaje_Origen_Leyenda = new System.Windows.Forms.Label();
            this.labelPaso3_Viaje_Destino_Leyenda = new System.Windows.Forms.Label();
            this.panelPaso3_Viaje_Destino = new System.Windows.Forms.TableLayoutPanel();
            this.labelPaso3_Viaje_Destino_FechaHora = new System.Windows.Forms.Label();
            this.labelPaso3_Viaje_Destino_Lugar = new System.Windows.Forms.Label();
            this.tilecontrolPaso3_Pasajeros = new C1.Win.C1Tile.C1TileControl();
            this.groupMain = new C1.Win.C1Tile.Group();
            this.tile1 = new C1.Win.C1Tile.Tile();
            this.panelPaso4 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.panelPasosNavegacion = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPasoAnterior = new System.Windows.Forms.Button();
            this.buttonPasoSiguiente = new System.Windows.Forms.Button();
            this.panelPasosPie = new System.Windows.Forms.TableLayoutPanel();
            this.labelPasosVersion = new System.Windows.Forms.Label();
            this.pictureboxPasosLogoCompaniaSoftware = new System.Windows.Forms.PictureBox();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.panelInicio = new System.Windows.Forms.TableLayoutPanel();
            this.labelInicio_LeyendaIniciar = new System.Windows.Forms.Label();
            this.wmInicio_Player = new AxWMPLib.AxWindowsMediaPlayer();
            this.keyboardNumeric = new CardonerSistemas.ControlsOnScreenKeyboard();
            this.panelPasos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxLogoEmpresa)).BeginInit();
            this.panelUser.SuspendLayout();
            this.panelPaso2.SuspendLayout();
            this.panelPaso1.SuspendLayout();
            this.panelPaso3.SuspendLayout();
            this.panelPaso3_Viaje_Personas.SuspendLayout();
            this.panelPaso3_Viaje.SuspendLayout();
            this.panelPaso3_Viaje_Origen.SuspendLayout();
            this.panelPaso3_Viaje_Destino.SuspendLayout();
            this.panelPaso4.SuspendLayout();
            this.panelPasosNavegacion.SuspendLayout();
            this.panelPasosPie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxPasosLogoCompaniaSoftware)).BeginInit();
            this.panelInicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wmInicio_Player)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPasos
            // 
            this.panelPasos.ColumnCount = 1;
            this.panelPasos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelPasos.Controls.Add(this.pictureboxLogoEmpresa, 0, 0);
            this.panelPasos.Controls.Add(this.panelUser, 0, 1);
            this.panelPasos.Controls.Add(this.panelPasosNavegacion, 0, 2);
            this.panelPasos.Controls.Add(this.panelPasosPie, 0, 3);
            this.panelPasos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPasos.Location = new System.Drawing.Point(0, 0);
            this.panelPasos.Name = "panelPasos";
            this.panelPasos.RowCount = 4;
            this.panelPasos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelPasos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.panelPasos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.panelPasos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.panelPasos.Size = new System.Drawing.Size(800, 600);
            this.panelPasos.TabIndex = 4;
            // 
            // pictureboxLogoEmpresa
            // 
            this.pictureboxLogoEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureboxLogoEmpresa.Location = new System.Drawing.Point(3, 3);
            this.pictureboxLogoEmpresa.Name = "pictureboxLogoEmpresa";
            this.pictureboxLogoEmpresa.Size = new System.Drawing.Size(794, 96);
            this.pictureboxLogoEmpresa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureboxLogoEmpresa.TabIndex = 1;
            this.pictureboxLogoEmpresa.TabStop = false;
            this.pictureboxLogoEmpresa.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Click_ToStart);
            // 
            // panelUser
            // 
            this.panelUser.Controls.Add(this.panelPaso2);
            this.panelUser.Controls.Add(this.panelPaso1);
            this.panelUser.Controls.Add(this.panelPaso3);
            this.panelUser.Controls.Add(this.panelPaso4);
            this.panelUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUser.Location = new System.Drawing.Point(3, 105);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(794, 351);
            this.panelUser.TabIndex = 4;
            // 
            // panelPaso2
            // 
            this.panelPaso2.ColumnCount = 4;
            this.panelPaso2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelPaso2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelPaso2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.panelPaso2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelPaso2.Controls.Add(this.textboxPaso2_Valor, 2, 1);
            this.panelPaso2.Controls.Add(this.labelPaso2_Valor, 1, 1);
            this.panelPaso2.Controls.Add(this.keyboardNumeric, 2, 2);
            this.panelPaso2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPaso2.Location = new System.Drawing.Point(0, 0);
            this.panelPaso2.Name = "panelPaso2";
            this.panelPaso2.RowCount = 3;
            this.panelPaso2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.panelPaso2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelPaso2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.panelPaso2.Size = new System.Drawing.Size(794, 351);
            this.panelPaso2.TabIndex = 6;
            this.panelPaso2.Visible = false;
            // 
            // textboxPaso2_Valor
            // 
            this.textboxPaso2_Valor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textboxPaso2_Valor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textboxPaso2_Valor.Enabled = false;
            this.textboxPaso2_Valor.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.textboxPaso2_Valor.Location = new System.Drawing.Point(418, 127);
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
            this.labelPaso2_Valor.Location = new System.Drawing.Point(81, 124);
            this.labelPaso2_Valor.Name = "labelPaso2_Valor";
            this.labelPaso2_Valor.Size = new System.Drawing.Size(331, 41);
            this.labelPaso2_Valor.TabIndex = 1;
            this.labelPaso2_Valor.Text = "Ingrese el Documento / Reserva:";
            this.labelPaso2_Valor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.panelPaso1.Size = new System.Drawing.Size(794, 351);
            this.panelPaso1.TabIndex = 3;
            this.panelPaso1.Visible = false;
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
            this.radioPaso1_Documento.Location = new System.Drawing.Point(231, 73);
            this.radioPaso1_Documento.Name = "radioPaso1_Documento";
            this.radioPaso1_Documento.Size = new System.Drawing.Size(331, 64);
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
            this.radioPaso1_Reserva.Location = new System.Drawing.Point(231, 213);
            this.radioPaso1_Reserva.Name = "radioPaso1_Reserva";
            this.radioPaso1_Reserva.Size = new System.Drawing.Size(331, 64);
            this.radioPaso1_Reserva.TabIndex = 6;
            this.radioPaso1_Reserva.TabStop = true;
            this.radioPaso1_Reserva.Text = "Ingresar con Nº de Reserva";
            this.radioPaso1_Reserva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioPaso1_Reserva.UseVisualStyleBackColor = false;
            // 
            // panelPaso3
            // 
            this.panelPaso3.ColumnCount = 3;
            this.panelPaso3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelPaso3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelPaso3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelPaso3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelPaso3.Controls.Add(this.panelPaso3_Viaje_Personas, 1, 0);
            this.panelPaso3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPaso3.Location = new System.Drawing.Point(0, 0);
            this.panelPaso3.Name = "panelPaso3";
            this.panelPaso3.RowCount = 1;
            this.panelPaso3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelPaso3.Size = new System.Drawing.Size(794, 351);
            this.panelPaso3.TabIndex = 7;
            this.panelPaso3.Visible = false;
            // 
            // panelPaso3_Viaje_Personas
            // 
            this.panelPaso3_Viaje_Personas.ColumnCount = 1;
            this.panelPaso3_Viaje_Personas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelPaso3_Viaje_Personas.Controls.Add(this.panelPaso3_Viaje, 0, 0);
            this.panelPaso3_Viaje_Personas.Controls.Add(this.tilecontrolPaso3_Pasajeros, 0, 1);
            this.panelPaso3_Viaje_Personas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPaso3_Viaje_Personas.Location = new System.Drawing.Point(33, 3);
            this.panelPaso3_Viaje_Personas.Name = "panelPaso3_Viaje_Personas";
            this.panelPaso3_Viaje_Personas.RowCount = 2;
            this.panelPaso3_Viaje_Personas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.panelPaso3_Viaje_Personas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelPaso3_Viaje_Personas.Size = new System.Drawing.Size(728, 345);
            this.panelPaso3_Viaje_Personas.TabIndex = 0;
            // 
            // panelPaso3_Viaje
            // 
            this.panelPaso3_Viaje.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.panelPaso3_Viaje.ColumnCount = 2;
            this.panelPaso3_Viaje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelPaso3_Viaje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.panelPaso3_Viaje.Controls.Add(this.labelPaso3_Viaje_Vehiculo, 1, 2);
            this.panelPaso3_Viaje.Controls.Add(this.labelPaso3_Viaje_Vehiculo_Leyenda, 0, 2);
            this.panelPaso3_Viaje.Controls.Add(this.panelPaso3_Viaje_Origen, 1, 0);
            this.panelPaso3_Viaje.Controls.Add(this.labelPaso3_Viaje_Origen_Leyenda, 0, 0);
            this.panelPaso3_Viaje.Controls.Add(this.labelPaso3_Viaje_Destino_Leyenda, 0, 1);
            this.panelPaso3_Viaje.Controls.Add(this.panelPaso3_Viaje_Destino, 1, 1);
            this.panelPaso3_Viaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPaso3_Viaje.Location = new System.Drawing.Point(3, 3);
            this.panelPaso3_Viaje.Name = "panelPaso3_Viaje";
            this.panelPaso3_Viaje.RowCount = 3;
            this.panelPaso3_Viaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelPaso3_Viaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelPaso3_Viaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.panelPaso3_Viaje.Size = new System.Drawing.Size(722, 174);
            this.panelPaso3_Viaje.TabIndex = 2;
            // 
            // labelPaso3_Viaje_Vehiculo
            // 
            this.labelPaso3_Viaje_Vehiculo.AutoSize = true;
            this.labelPaso3_Viaje_Vehiculo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPaso3_Viaje_Vehiculo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelPaso3_Viaje_Vehiculo.Location = new System.Drawing.Point(148, 115);
            this.labelPaso3_Viaje_Vehiculo.Name = "labelPaso3_Viaje_Vehiculo";
            this.labelPaso3_Viaje_Vehiculo.Size = new System.Drawing.Size(570, 58);
            this.labelPaso3_Viaje_Vehiculo.TabIndex = 6;
            this.labelPaso3_Viaje_Vehiculo.Text = "Nombre del vehículo";
            this.labelPaso3_Viaje_Vehiculo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPaso3_Viaje_Vehiculo_Leyenda
            // 
            this.labelPaso3_Viaje_Vehiculo_Leyenda.AutoSize = true;
            this.labelPaso3_Viaje_Vehiculo_Leyenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPaso3_Viaje_Vehiculo_Leyenda.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaso3_Viaje_Vehiculo_Leyenda.Location = new System.Drawing.Point(4, 115);
            this.labelPaso3_Viaje_Vehiculo_Leyenda.Name = "labelPaso3_Viaje_Vehiculo_Leyenda";
            this.labelPaso3_Viaje_Vehiculo_Leyenda.Size = new System.Drawing.Size(137, 58);
            this.labelPaso3_Viaje_Vehiculo_Leyenda.TabIndex = 5;
            this.labelPaso3_Viaje_Vehiculo_Leyenda.Text = "Vehículo:";
            this.labelPaso3_Viaje_Vehiculo_Leyenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelPaso3_Viaje_Origen
            // 
            this.panelPaso3_Viaje_Origen.ColumnCount = 1;
            this.panelPaso3_Viaje_Origen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelPaso3_Viaje_Origen.Controls.Add(this.labelPaso3_Viaje_Origen_FechaHora, 0, 1);
            this.panelPaso3_Viaje_Origen.Controls.Add(this.labelPaso3_Viaje_Origen_Lugar, 0, 0);
            this.panelPaso3_Viaje_Origen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPaso3_Viaje_Origen.Location = new System.Drawing.Point(148, 4);
            this.panelPaso3_Viaje_Origen.Name = "panelPaso3_Viaje_Origen";
            this.panelPaso3_Viaje_Origen.RowCount = 2;
            this.panelPaso3_Viaje_Origen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelPaso3_Viaje_Origen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelPaso3_Viaje_Origen.Size = new System.Drawing.Size(570, 50);
            this.panelPaso3_Viaje_Origen.TabIndex = 4;
            // 
            // labelPaso3_Viaje_Origen_FechaHora
            // 
            this.labelPaso3_Viaje_Origen_FechaHora.AutoSize = true;
            this.labelPaso3_Viaje_Origen_FechaHora.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPaso3_Viaje_Origen_FechaHora.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaso3_Viaje_Origen_FechaHora.Location = new System.Drawing.Point(3, 30);
            this.labelPaso3_Viaje_Origen_FechaHora.Name = "labelPaso3_Viaje_Origen_FechaHora";
            this.labelPaso3_Viaje_Origen_FechaHora.Size = new System.Drawing.Size(564, 20);
            this.labelPaso3_Viaje_Origen_FechaHora.TabIndex = 4;
            this.labelPaso3_Viaje_Origen_FechaHora.Text = "Fecha y hora de salida";
            this.labelPaso3_Viaje_Origen_FechaHora.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPaso3_Viaje_Origen_Lugar
            // 
            this.labelPaso3_Viaje_Origen_Lugar.AutoSize = true;
            this.labelPaso3_Viaje_Origen_Lugar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPaso3_Viaje_Origen_Lugar.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelPaso3_Viaje_Origen_Lugar.Location = new System.Drawing.Point(3, 0);
            this.labelPaso3_Viaje_Origen_Lugar.Name = "labelPaso3_Viaje_Origen_Lugar";
            this.labelPaso3_Viaje_Origen_Lugar.Size = new System.Drawing.Size(564, 30);
            this.labelPaso3_Viaje_Origen_Lugar.TabIndex = 3;
            this.labelPaso3_Viaje_Origen_Lugar.Text = "Parada de origen y lugar";
            this.labelPaso3_Viaje_Origen_Lugar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPaso3_Viaje_Origen_Leyenda
            // 
            this.labelPaso3_Viaje_Origen_Leyenda.AutoSize = true;
            this.labelPaso3_Viaje_Origen_Leyenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPaso3_Viaje_Origen_Leyenda.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaso3_Viaje_Origen_Leyenda.Location = new System.Drawing.Point(4, 1);
            this.labelPaso3_Viaje_Origen_Leyenda.Name = "labelPaso3_Viaje_Origen_Leyenda";
            this.labelPaso3_Viaje_Origen_Leyenda.Size = new System.Drawing.Size(137, 56);
            this.labelPaso3_Viaje_Origen_Leyenda.TabIndex = 0;
            this.labelPaso3_Viaje_Origen_Leyenda.Text = "Salida de:";
            this.labelPaso3_Viaje_Origen_Leyenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPaso3_Viaje_Destino_Leyenda
            // 
            this.labelPaso3_Viaje_Destino_Leyenda.AutoSize = true;
            this.labelPaso3_Viaje_Destino_Leyenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPaso3_Viaje_Destino_Leyenda.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaso3_Viaje_Destino_Leyenda.Location = new System.Drawing.Point(4, 58);
            this.labelPaso3_Viaje_Destino_Leyenda.Name = "labelPaso3_Viaje_Destino_Leyenda";
            this.labelPaso3_Viaje_Destino_Leyenda.Size = new System.Drawing.Size(137, 56);
            this.labelPaso3_Viaje_Destino_Leyenda.TabIndex = 1;
            this.labelPaso3_Viaje_Destino_Leyenda.Text = "Llegada a:";
            this.labelPaso3_Viaje_Destino_Leyenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelPaso3_Viaje_Destino
            // 
            this.panelPaso3_Viaje_Destino.ColumnCount = 1;
            this.panelPaso3_Viaje_Destino.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelPaso3_Viaje_Destino.Controls.Add(this.labelPaso3_Viaje_Destino_FechaHora, 0, 1);
            this.panelPaso3_Viaje_Destino.Controls.Add(this.labelPaso3_Viaje_Destino_Lugar, 0, 0);
            this.panelPaso3_Viaje_Destino.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPaso3_Viaje_Destino.Location = new System.Drawing.Point(148, 61);
            this.panelPaso3_Viaje_Destino.Name = "panelPaso3_Viaje_Destino";
            this.panelPaso3_Viaje_Destino.RowCount = 2;
            this.panelPaso3_Viaje_Destino.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelPaso3_Viaje_Destino.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelPaso3_Viaje_Destino.Size = new System.Drawing.Size(570, 50);
            this.panelPaso3_Viaje_Destino.TabIndex = 3;
            // 
            // labelPaso3_Viaje_Destino_FechaHora
            // 
            this.labelPaso3_Viaje_Destino_FechaHora.AutoSize = true;
            this.labelPaso3_Viaje_Destino_FechaHora.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPaso3_Viaje_Destino_FechaHora.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaso3_Viaje_Destino_FechaHora.Location = new System.Drawing.Point(3, 30);
            this.labelPaso3_Viaje_Destino_FechaHora.Name = "labelPaso3_Viaje_Destino_FechaHora";
            this.labelPaso3_Viaje_Destino_FechaHora.Size = new System.Drawing.Size(564, 20);
            this.labelPaso3_Viaje_Destino_FechaHora.TabIndex = 4;
            this.labelPaso3_Viaje_Destino_FechaHora.Text = "Fecha y hora de llegada";
            this.labelPaso3_Viaje_Destino_FechaHora.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPaso3_Viaje_Destino_Lugar
            // 
            this.labelPaso3_Viaje_Destino_Lugar.AutoSize = true;
            this.labelPaso3_Viaje_Destino_Lugar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPaso3_Viaje_Destino_Lugar.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelPaso3_Viaje_Destino_Lugar.Location = new System.Drawing.Point(3, 0);
            this.labelPaso3_Viaje_Destino_Lugar.Name = "labelPaso3_Viaje_Destino_Lugar";
            this.labelPaso3_Viaje_Destino_Lugar.Size = new System.Drawing.Size(564, 30);
            this.labelPaso3_Viaje_Destino_Lugar.TabIndex = 3;
            this.labelPaso3_Viaje_Destino_Lugar.Text = "Parada de destino y lugar";
            this.labelPaso3_Viaje_Destino_Lugar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tilecontrolPaso3_Pasajeros
            // 
            this.tilecontrolPaso3_Pasajeros.AllowChecking = true;
            this.tilecontrolPaso3_Pasajeros.CellSpacing = 20;
            this.tilecontrolPaso3_Pasajeros.CellWidth = 200;
            // 
            // 
            // 
            panelElement1.Alignment = System.Drawing.ContentAlignment.BottomLeft;
            panelElement1.Children.Add(imageElement1);
            panelElement1.Children.Add(textElement1);
            panelElement1.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.tilecontrolPaso3_Pasajeros.DefaultTemplate.Elements.Add(panelElement1);
            this.tilecontrolPaso3_Pasajeros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilecontrolPaso3_Pasajeros.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tilecontrolPaso3_Pasajeros.GroupPadding = new System.Windows.Forms.Padding(20, 35, 20, 20);
            this.tilecontrolPaso3_Pasajeros.Groups.Add(this.groupMain);
            this.tilecontrolPaso3_Pasajeros.GroupTextY = 0;
            this.tilecontrolPaso3_Pasajeros.Location = new System.Drawing.Point(3, 183);
            this.tilecontrolPaso3_Pasajeros.Name = "tilecontrolPaso3_Pasajeros";
            this.tilecontrolPaso3_Pasajeros.Orientation = C1.Win.C1Tile.LayoutOrientation.Vertical;
            this.tilecontrolPaso3_Pasajeros.Padding = new System.Windows.Forms.Padding(0);
            this.tilecontrolPaso3_Pasajeros.Size = new System.Drawing.Size(722, 159);
            this.tilecontrolPaso3_Pasajeros.SurfaceContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tilecontrolPaso3_Pasajeros.TabIndex = 3;
            this.tilecontrolPaso3_Pasajeros.TextX = 0;
            this.tilecontrolPaso3_Pasajeros.TextY = 0;
            this.tilecontrolPaso3_Pasajeros.UncheckTilesOnClick = false;
            this.tilecontrolPaso3_Pasajeros.TileClicked += new System.EventHandler<C1.Win.C1Tile.TileEventArgs>(this.ClickEnPasajero);
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
            // panelPaso4
            // 
            this.panelPaso4.ColumnCount = 3;
            this.panelPaso4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelPaso4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelPaso4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelPaso4.Controls.Add(this.radioButton1, 1, 1);
            this.panelPaso4.Controls.Add(this.radioButton2, 1, 3);
            this.panelPaso4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPaso4.Location = new System.Drawing.Point(0, 0);
            this.panelPaso4.Name = "panelPaso4";
            this.panelPaso4.RowCount = 5;
            this.panelPaso4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelPaso4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelPaso4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelPaso4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelPaso4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelPaso4.Size = new System.Drawing.Size(794, 351);
            this.panelPaso4.TabIndex = 8;
            this.panelPaso4.Visible = false;
            // 
            // radioButton1
            // 
            this.radioButton1.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.radioButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.radioButton1.Location = new System.Drawing.Point(231, 73);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(331, 64);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Ingresar con Nº de Documento";
            this.radioButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton1.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            this.radioButton2.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.radioButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.radioButton2.Location = new System.Drawing.Point(231, 213);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(331, 64);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Ingresar con Nº de Reserva";
            this.radioButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButton2.UseVisualStyleBackColor = false;
            // 
            // panelPasosNavegacion
            // 
            this.panelPasosNavegacion.ColumnCount = 5;
            this.panelPasosNavegacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelPasosNavegacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelPasosNavegacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.panelPasosNavegacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.panelPasosNavegacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.panelPasosNavegacion.Controls.Add(this.buttonPasoAnterior, 1, 0);
            this.panelPasosNavegacion.Controls.Add(this.buttonPasoSiguiente, 3, 0);
            this.panelPasosNavegacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPasosNavegacion.Location = new System.Drawing.Point(3, 462);
            this.panelPasosNavegacion.Name = "panelPasosNavegacion";
            this.panelPasosNavegacion.RowCount = 1;
            this.panelPasosNavegacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelPasosNavegacion.Size = new System.Drawing.Size(794, 45);
            this.panelPasosNavegacion.TabIndex = 6;
            // 
            // buttonPasoAnterior
            // 
            this.buttonPasoAnterior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonPasoAnterior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPasoAnterior.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonPasoAnterior.Location = new System.Drawing.Point(23, 3);
            this.buttonPasoAnterior.Name = "buttonPasoAnterior";
            this.buttonPasoAnterior.Size = new System.Drawing.Size(144, 39);
            this.buttonPasoAnterior.TabIndex = 3;
            this.buttonPasoAnterior.Text = "Anterior";
            this.buttonPasoAnterior.UseVisualStyleBackColor = false;
            this.buttonPasoAnterior.Click += new System.EventHandler(this.ButtonPasoAnterior_Click);
            // 
            // buttonPasoSiguiente
            // 
            this.buttonPasoSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonPasoSiguiente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPasoSiguiente.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonPasoSiguiente.Location = new System.Drawing.Point(623, 3);
            this.buttonPasoSiguiente.Name = "buttonPasoSiguiente";
            this.buttonPasoSiguiente.Size = new System.Drawing.Size(144, 39);
            this.buttonPasoSiguiente.TabIndex = 2;
            this.buttonPasoSiguiente.Text = "Siguiente";
            this.buttonPasoSiguiente.UseVisualStyleBackColor = false;
            this.buttonPasoSiguiente.Click += new System.EventHandler(this.ButtonPasoSiguiente_Click);
            // 
            // panelPasosPie
            // 
            this.panelPasosPie.ColumnCount = 3;
            this.panelPasosPie.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelPasosPie.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelPasosPie.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelPasosPie.Controls.Add(this.labelPasosVersion, 0, 1);
            this.panelPasosPie.Controls.Add(this.pictureboxPasosLogoCompaniaSoftware, 2, 1);
            this.panelPasosPie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPasosPie.Location = new System.Drawing.Point(3, 513);
            this.panelPasosPie.Name = "panelPasosPie";
            this.panelPasosPie.RowCount = 2;
            this.panelPasosPie.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelPasosPie.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelPasosPie.Size = new System.Drawing.Size(794, 84);
            this.panelPasosPie.TabIndex = 7;
            // 
            // labelPasosVersion
            // 
            this.labelPasosVersion.AutoSize = true;
            this.labelPasosVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPasosVersion.Location = new System.Drawing.Point(3, 20);
            this.labelPasosVersion.Name = "labelPasosVersion";
            this.labelPasosVersion.Size = new System.Drawing.Size(41, 64);
            this.labelPasosVersion.TabIndex = 1;
            this.labelPasosVersion.Text = "version";
            this.labelPasosVersion.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pictureboxPasosLogoCompaniaSoftware
            // 
            this.pictureboxPasosLogoCompaniaSoftware.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureboxPasosLogoCompaniaSoftware.Location = new System.Drawing.Point(641, 23);
            this.pictureboxPasosLogoCompaniaSoftware.Name = "pictureboxPasosLogoCompaniaSoftware";
            this.pictureboxPasosLogoCompaniaSoftware.Size = new System.Drawing.Size(150, 58);
            this.pictureboxPasosLogoCompaniaSoftware.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureboxPasosLogoCompaniaSoftware.TabIndex = 0;
            this.pictureboxPasosLogoCompaniaSoftware.TabStop = false;
            this.pictureboxPasosLogoCompaniaSoftware.Click += new System.EventHandler(this.SoftwareCompanyClick);
            // 
            // timerMain
            // 
            this.timerMain.Enabled = true;
            this.timerMain.Interval = 1000;
            this.timerMain.Tick += new System.EventHandler(this.TimerMain_Tick);
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
            this.panelInicio.Size = new System.Drawing.Size(800, 600);
            this.panelInicio.TabIndex = 5;
            this.panelInicio.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Click_ToStart);
            // 
            // labelInicio_LeyendaIniciar
            // 
            this.labelInicio_LeyendaIniciar.AutoSize = true;
            this.labelInicio_LeyendaIniciar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInicio_LeyendaIniciar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInicio_LeyendaIniciar.Location = new System.Drawing.Point(3, 550);
            this.labelInicio_LeyendaIniciar.Name = "labelInicio_LeyendaIniciar";
            this.labelInicio_LeyendaIniciar.Size = new System.Drawing.Size(794, 50);
            this.labelInicio_LeyendaIniciar.TabIndex = 4;
            this.labelInicio_LeyendaIniciar.Text = "Toque la pantalla para comenzar";
            this.labelInicio_LeyendaIniciar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelInicio_LeyendaIniciar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Click_ToStart);
            // 
            // wmInicio_Player
            // 
            this.wmInicio_Player.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wmInicio_Player.Enabled = true;
            this.wmInicio_Player.Location = new System.Drawing.Point(3, 3);
            this.wmInicio_Player.Name = "wmInicio_Player";
            this.wmInicio_Player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmInicio_Player.OcxState")));
            this.wmInicio_Player.Size = new System.Drawing.Size(794, 544);
            this.wmInicio_Player.TabIndex = 1;
            this.wmInicio_Player.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.WindowsMediaPlayer_PlayStateChange);
            this.wmInicio_Player.ClickEvent += new AxWMPLib._WMPOCXEvents_ClickEventHandler(this.Click_ToStart);
            // 
            // keyboardNumeric
            // 
            this.keyboardNumeric.DestinationTextBox = this.textboxPaso2_Valor;
            this.keyboardNumeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyboardNumeric.KeyboardLayout = CardonerSistemas.ControlsOnScreenKeyboard.KeyboardLayoutEnums.NumericCalculator;
            this.keyboardNumeric.Location = new System.Drawing.Point(418, 168);
            this.keyboardNumeric.Name = "keyboardNumeric";
            this.keyboardNumeric.Size = new System.Drawing.Size(294, 180);
            this.keyboardNumeric.TabIndex = 3;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.panelPasos);
            this.Controls.Add(this.panelInicio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyCombinationManager);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Click_ToStart);
            this.panelPasos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxLogoEmpresa)).EndInit();
            this.panelUser.ResumeLayout(false);
            this.panelPaso2.ResumeLayout(false);
            this.panelPaso2.PerformLayout();
            this.panelPaso1.ResumeLayout(false);
            this.panelPaso1.PerformLayout();
            this.panelPaso3.ResumeLayout(false);
            this.panelPaso3_Viaje_Personas.ResumeLayout(false);
            this.panelPaso3_Viaje.ResumeLayout(false);
            this.panelPaso3_Viaje.PerformLayout();
            this.panelPaso3_Viaje_Origen.ResumeLayout(false);
            this.panelPaso3_Viaje_Origen.PerformLayout();
            this.panelPaso3_Viaje_Destino.ResumeLayout(false);
            this.panelPaso3_Viaje_Destino.PerformLayout();
            this.panelPaso4.ResumeLayout(false);
            this.panelPaso4.PerformLayout();
            this.panelPasosNavegacion.ResumeLayout(false);
            this.panelPasosPie.ResumeLayout(false);
            this.panelPasosPie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxPasosLogoCompaniaSoftware)).EndInit();
            this.panelInicio.ResumeLayout(false);
            this.panelInicio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wmInicio_Player)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelPasos;
        private System.Windows.Forms.PictureBox pictureboxLogoEmpresa;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.TableLayoutPanel panelPaso1;
        private System.Windows.Forms.TableLayoutPanel panelPasosNavegacion;
        private System.Windows.Forms.Button buttonPasoSiguiente;
        private System.Windows.Forms.Button buttonPasoAnterior;
        private System.Windows.Forms.TableLayoutPanel panelPasosPie;
        private System.Windows.Forms.Label labelPasosVersion;
        private System.Windows.Forms.TableLayoutPanel panelInicio;
        private System.Windows.Forms.Label labelInicio_LeyendaIniciar;
        private AxWMPLib.AxWindowsMediaPlayer wmInicio_Player;
        private System.Windows.Forms.TableLayoutPanel panelPaso2;
        private System.Windows.Forms.Label labelPaso2_Valor;
        private System.Windows.Forms.Panel panelUser;
        private System.Windows.Forms.RadioButton radioPaso1_Documento;
        private System.Windows.Forms.RadioButton radioPaso1_Reserva;
        private System.Windows.Forms.PictureBox pictureboxPasosLogoCompaniaSoftware;
        private System.Windows.Forms.TextBox textboxPaso2_Valor;
        private System.Windows.Forms.TableLayoutPanel panelPaso3;
        private System.Windows.Forms.TableLayoutPanel panelPaso3_Viaje_Personas;
        private System.Windows.Forms.TableLayoutPanel panelPaso3_Viaje;
        private System.Windows.Forms.Label labelPaso3_Viaje_Origen_Leyenda;
        private System.Windows.Forms.Label labelPaso3_Viaje_Destino_Leyenda;
        private C1.Win.C1Tile.C1TileControl tilecontrolPaso3_Pasajeros;
        private C1.Win.C1Tile.Group groupMain;
        private System.Windows.Forms.TableLayoutPanel panelPaso4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TableLayoutPanel panelPaso3_Viaje_Destino;
        private System.Windows.Forms.Label labelPaso3_Viaje_Destino_Lugar;
        private System.Windows.Forms.Label labelPaso3_Viaje_Destino_FechaHora;
        private System.Windows.Forms.TableLayoutPanel panelPaso3_Viaje_Origen;
        private System.Windows.Forms.Label labelPaso3_Viaje_Origen_FechaHora;
        private System.Windows.Forms.Label labelPaso3_Viaje_Origen_Lugar;
        private System.Windows.Forms.Label labelPaso3_Viaje_Vehiculo;
        private System.Windows.Forms.Label labelPaso3_Viaje_Vehiculo_Leyenda;
        private C1.Win.C1Tile.Tile tile1;
        private CardonerSistemas.ControlsOnScreenKeyboard keyboardNumeric;
    }
}

