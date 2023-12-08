namespace MicroSisPlani.Personal
{
    partial class Frm_Registro_Personal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Registro_Personal));
            this.pnl_titulo = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_Salir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_IdProducto = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp_fecha = new System.Windows.Forms.DateTimePicker();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txt_tipo = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txt_PrecioCompra = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txt_PrecioMayoreo = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txt_codigo = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.btn_aceptar = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btn_cancelar = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txt_Descripcion = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txt_cantidad = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_PrecioVenta = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txt_PrecioEspecial = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txt_Categoria = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label22 = new System.Windows.Forms.Label();
            this.txt_CantidadMinima = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.pnl_titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_aceptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancelar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_titulo
            // 
            this.pnl_titulo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_titulo.Controls.Add(this.label7);
            this.pnl_titulo.Controls.Add(this.btn_Salir);
            this.pnl_titulo.Controls.Add(this.label1);
            this.pnl_titulo.Controls.Add(this.txt_IdProducto);
            this.pnl_titulo.Controls.Add(this.label6);
            this.pnl_titulo.Controls.Add(this.dtp_fecha);
            this.pnl_titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titulo.Location = new System.Drawing.Point(0, 0);
            this.pnl_titulo.Name = "pnl_titulo";
            this.pnl_titulo.Size = new System.Drawing.Size(797, 50);
            this.pnl_titulo.TabIndex = 8;
            this.pnl_titulo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_titulo_Paint);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(6, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 20);
            this.label7.TabIndex = 25;
            this.label7.Text = "Registro de Productos";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // btn_Salir
            // 
            this.btn_Salir.FlatAppearance.BorderSize = 0;
            this.btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Salir.ForeColor = System.Drawing.Color.White;
            this.btn_Salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_Salir.Image")));
            this.btn_Salir.Location = new System.Drawing.Point(750, 8);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(32, 32);
            this.btn_Salir.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btn_Salir, "Salir / Cerrar Ventana");
            this.btn_Salir.UseVisualStyleBackColor = true;
            this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LimeGreen;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(797, 2);
            this.label1.TabIndex = 0;
            // 
            // txt_IdProducto
            // 
            this.txt_IdProducto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_IdProducto.Enabled = false;
            this.txt_IdProducto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IdProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_IdProducto.HintForeColor = System.Drawing.Color.Gray;
            this.txt_IdProducto.HintText = "";
            this.txt_IdProducto.isPassword = false;
            this.txt_IdProducto.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_IdProducto.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_IdProducto.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_IdProducto.LineThickness = 2;
            this.txt_IdProducto.Location = new System.Drawing.Point(286, 8);
            this.txt_IdProducto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_IdProducto.Name = "txt_IdProducto";
            this.txt_IdProducto.Size = new System.Drawing.Size(168, 32);
            this.txt_IdProducto.TabIndex = 33;
            this.txt_IdProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_IdProducto.Visible = false;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
            this.label6.Location = new System.Drawing.Point(255, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 24);
            this.label6.TabIndex = 34;
            this.toolTip1.SetToolTip(this.label6, "Nro de Dni");
            this.label6.Visible = false;
            // 
            // dtp_fecha
            // 
            this.dtp_fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fecha.Location = new System.Drawing.Point(222, 18);
            this.dtp_fecha.Name = "dtp_fecha";
            this.dtp_fecha.Size = new System.Drawing.Size(27, 22);
            this.dtp_fecha.TabIndex = 42;
            this.dtp_fecha.Visible = false;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Image = ((System.Drawing.Image)(resources.GetObject("label8.Image")));
            this.label8.Location = new System.Drawing.Point(151, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 24);
            this.label8.TabIndex = 36;
            this.toolTip1.SetToolTip(this.label8, "Nro de Celular");
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(460, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 24);
            this.label2.TabIndex = 449;
            this.toolTip1.SetToolTip(this.label2, "Nro de Celular");
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(151, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 24);
            this.label3.TabIndex = 450;
            this.toolTip1.SetToolTip(this.label3, "Nro de Celular");
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.Location = new System.Drawing.Point(151, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 24);
            this.label4.TabIndex = 451;
            this.toolTip1.SetToolTip(this.label4, "Nro de Celular");
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.Location = new System.Drawing.Point(151, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 24);
            this.label5.TabIndex = 452;
            this.toolTip1.SetToolTip(this.label5, "Nro de Celular");
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Image = ((System.Drawing.Image)(resources.GetObject("label10.Image")));
            this.label10.Location = new System.Drawing.Point(151, 280);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 24);
            this.label10.TabIndex = 454;
            this.toolTip1.SetToolTip(this.label10, "Nro de Celular");
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Image = ((System.Drawing.Image)(resources.GetObject("label14.Image")));
            this.label14.Location = new System.Drawing.Point(487, 238);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 24);
            this.label14.TabIndex = 456;
            this.toolTip1.SetToolTip(this.label14, "Nro de Celular");
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Image = ((System.Drawing.Image)(resources.GetObject("label15.Image")));
            this.label15.Location = new System.Drawing.Point(487, 285);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(24, 24);
            this.label15.TabIndex = 457;
            this.toolTip1.SetToolTip(this.label15, "Nro de Celular");
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Image = ((System.Drawing.Image)(resources.GetObject("label21.Image")));
            this.label21.Location = new System.Drawing.Point(151, 196);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(24, 24);
            this.label21.TabIndex = 459;
            this.toolTip1.SetToolTip(this.label21, "Nro de Celular");
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Image = ((System.Drawing.Image)(resources.GetObject("label23.Image")));
            this.label23.Location = new System.Drawing.Point(151, 319);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(24, 24);
            this.label23.TabIndex = 462;
            this.toolTip1.SetToolTip(this.label23, "Nro de Celular");
            // 
            // txt_tipo
            // 
            this.txt_tipo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_tipo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_tipo.HintForeColor = System.Drawing.Color.Gray;
            this.txt_tipo.HintText = "";
            this.txt_tipo.isPassword = false;
            this.txt_tipo.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_tipo.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_tipo.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_tipo.LineThickness = 2;
            this.txt_tipo.Location = new System.Drawing.Point(187, 146);
            this.txt_tipo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_tipo.Name = "txt_tipo";
            this.txt_tipo.Size = new System.Drawing.Size(472, 32);
            this.txt_tipo.TabIndex = 27;
            this.txt_tipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txt_PrecioCompra
            // 
            this.txt_PrecioCompra.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_PrecioCompra.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PrecioCompra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_PrecioCompra.HintForeColor = System.Drawing.Color.Gray;
            this.txt_PrecioCompra.HintText = "";
            this.txt_PrecioCompra.isPassword = false;
            this.txt_PrecioCompra.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_PrecioCompra.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_PrecioCompra.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_PrecioCompra.LineThickness = 2;
            this.txt_PrecioCompra.Location = new System.Drawing.Point(187, 227);
            this.txt_PrecioCompra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_PrecioCompra.Name = "txt_PrecioCompra";
            this.txt_PrecioCompra.Size = new System.Drawing.Size(148, 32);
            this.txt_PrecioCompra.TabIndex = 29;
            this.txt_PrecioCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_PrecioCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_PrecioCompra_KeyPress);
            // 
            // txt_PrecioMayoreo
            // 
            this.txt_PrecioMayoreo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_PrecioMayoreo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PrecioMayoreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_PrecioMayoreo.HintForeColor = System.Drawing.Color.Gray;
            this.txt_PrecioMayoreo.HintText = "";
            this.txt_PrecioMayoreo.isPassword = false;
            this.txt_PrecioMayoreo.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_PrecioMayoreo.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_PrecioMayoreo.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_PrecioMayoreo.LineThickness = 2;
            this.txt_PrecioMayoreo.Location = new System.Drawing.Point(187, 269);
            this.txt_PrecioMayoreo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_PrecioMayoreo.Name = "txt_PrecioMayoreo";
            this.txt_PrecioMayoreo.Size = new System.Drawing.Size(148, 32);
            this.txt_PrecioMayoreo.TabIndex = 31;
            this.txt_PrecioMayoreo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_PrecioMayoreo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_PrecioMayoreo_KeyPress);
            // 
            // txt_codigo
            // 
            this.txt_codigo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_codigo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_codigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_codigo.HintForeColor = System.Drawing.Color.Gray;
            this.txt_codigo.HintText = "";
            this.txt_codigo.isPassword = false;
            this.txt_codigo.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_codigo.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_codigo.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_codigo.LineThickness = 2;
            this.txt_codigo.Location = new System.Drawing.Point(189, 63);
            this.txt_codigo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(168, 32);
            this.txt_codigo.TabIndex = 35;
            this.txt_codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_aceptar.BackgroundStyle.SolidColor = System.Drawing.Color.DimGray;
            this.btn_aceptar.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_aceptar.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_aceptar.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_aceptar.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_aceptar.BorderStyle.SolidColor = System.Drawing.Color.DimGray;
            this.btn_aceptar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_aceptar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_aceptar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_aceptar.Location = new System.Drawing.Point(429, 387);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(239, 49);
            this.btn_aceptar.StateStyles.HoverStyle.BackgroundGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_aceptar.StateStyles.HoverStyle.BackgroundGradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_aceptar.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_aceptar.StateStyles.HoverStyle.BorderGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_aceptar.StateStyles.HoverStyle.BorderGradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_aceptar.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_aceptar.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_aceptar.TabIndex = 44;
            this.btn_aceptar.TextStyle.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_aceptar.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_aceptar.TextStyle.Text = "Listo";
            this.btn_aceptar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_aceptar.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cancelar.BackgroundStyle.SolidColor = System.Drawing.Color.WhiteSmoke;
            this.btn_cancelar.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancelar.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancelar.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancelar.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancelar.BorderStyle.SolidColor = System.Drawing.Color.DimGray;
            this.btn_cancelar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cancelar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_cancelar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancelar.Location = new System.Drawing.Point(113, 387);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(239, 49);
            this.btn_cancelar.StateStyles.HoverStyle.BackgroundGradientEndColor = System.Drawing.Color.White;
            this.btn_cancelar.StateStyles.HoverStyle.BackgroundGradientStartColor = System.Drawing.Color.White;
            this.btn_cancelar.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.White;
            this.btn_cancelar.StateStyles.HoverStyle.BorderGradientEndColor = System.Drawing.Color.White;
            this.btn_cancelar.StateStyles.HoverStyle.BorderGradientStartColor = System.Drawing.Color.White;
            this.btn_cancelar.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.DimGray;
            this.btn_cancelar.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar.TabIndex = 48;
            this.btn_cancelar.TextStyle.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar.TextStyle.ForeColor = System.Drawing.Color.DimGray;
            this.btn_cancelar.TextStyle.Text = "Cancelar";
            this.btn_cancelar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancelar.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label16.Location = new System.Drawing.Point(66, 120);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 16);
            this.label16.TabIndex = 57;
            this.label16.Text = "Descripcion";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label17.Location = new System.Drawing.Point(110, 162);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 16);
            this.label17.TabIndex = 58;
            this.label17.Text = "Tipo";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label18.Location = new System.Drawing.Point(31, 238);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(114, 16);
            this.label18.TabIndex = 59;
            this.label18.Text = "Precio de compra";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label19.Location = new System.Drawing.Point(387, 243);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(103, 16);
            this.label19.TabIndex = 60;
            this.label19.Text = "Precio de Venta";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label20.Location = new System.Drawing.Point(28, 79);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(126, 16);
            this.label20.TabIndex = 61;
            this.label20.Text = "Codigo de producto";
            // 
            // txt_Descripcion
            // 
            this.txt_Descripcion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Descripcion.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Descripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_Descripcion.HintForeColor = System.Drawing.Color.DarkGray;
            this.txt_Descripcion.HintText = "";
            this.txt_Descripcion.isPassword = false;
            this.txt_Descripcion.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_Descripcion.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_Descripcion.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_Descripcion.LineThickness = 2;
            this.txt_Descripcion.Location = new System.Drawing.Point(189, 104);
            this.txt_Descripcion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Descripcion.Name = "txt_Descripcion";
            this.txt_Descripcion.Size = new System.Drawing.Size(470, 32);
            this.txt_Descripcion.TabIndex = 440;
            this.txt_Descripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txt_cantidad
            // 
            this.txt_cantidad.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_cantidad.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_cantidad.HintForeColor = System.Drawing.Color.DarkGray;
            this.txt_cantidad.HintText = "";
            this.txt_cantidad.isPassword = false;
            this.txt_cantidad.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_cantidad.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_cantidad.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_cantidad.LineThickness = 2;
            this.txt_cantidad.Location = new System.Drawing.Point(491, 75);
            this.txt_cantidad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_cantidad.Name = "txt_cantidad";
            this.txt_cantidad.Size = new System.Drawing.Size(168, 28);
            this.txt_cantidad.TabIndex = 445;
            this.txt_cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_cantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cantidad_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(395, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 16);
            this.label9.TabIndex = 444;
            this.label9.Text = "cantidad";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(42, 280);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 16);
            this.label11.TabIndex = 446;
            this.label11.Text = "Precio Mayoreo";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(388, 288);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 16);
            this.label12.TabIndex = 447;
            this.label12.Text = "Precio Especial";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(79, 199);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 16);
            this.label13.TabIndex = 448;
            this.label13.Text = "Categoria";
            // 
            // txt_PrecioVenta
            // 
            this.txt_PrecioVenta.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_PrecioVenta.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PrecioVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_PrecioVenta.HintForeColor = System.Drawing.Color.Gray;
            this.txt_PrecioVenta.HintText = "";
            this.txt_PrecioVenta.isPassword = false;
            this.txt_PrecioVenta.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_PrecioVenta.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_PrecioVenta.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_PrecioVenta.LineThickness = 2;
            this.txt_PrecioVenta.Location = new System.Drawing.Point(511, 227);
            this.txt_PrecioVenta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_PrecioVenta.Name = "txt_PrecioVenta";
            this.txt_PrecioVenta.Size = new System.Drawing.Size(148, 32);
            this.txt_PrecioVenta.TabIndex = 453;
            this.txt_PrecioVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_PrecioVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_PrecioVenta_KeyPress);
            // 
            // txt_PrecioEspecial
            // 
            this.txt_PrecioEspecial.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_PrecioEspecial.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PrecioEspecial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_PrecioEspecial.HintForeColor = System.Drawing.Color.Gray;
            this.txt_PrecioEspecial.HintText = "";
            this.txt_PrecioEspecial.isPassword = false;
            this.txt_PrecioEspecial.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_PrecioEspecial.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_PrecioEspecial.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_PrecioEspecial.LineThickness = 2;
            this.txt_PrecioEspecial.Location = new System.Drawing.Point(511, 269);
            this.txt_PrecioEspecial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_PrecioEspecial.Name = "txt_PrecioEspecial";
            this.txt_PrecioEspecial.Size = new System.Drawing.Size(148, 32);
            this.txt_PrecioEspecial.TabIndex = 455;
            this.txt_PrecioEspecial.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_PrecioEspecial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_PrecioEspecial_KeyPress);
            // 
            // txt_Categoria
            // 
            this.txt_Categoria.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Categoria.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Categoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_Categoria.HintForeColor = System.Drawing.Color.Gray;
            this.txt_Categoria.HintText = "";
            this.txt_Categoria.isPassword = false;
            this.txt_Categoria.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_Categoria.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_Categoria.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_Categoria.LineThickness = 2;
            this.txt_Categoria.Location = new System.Drawing.Point(187, 188);
            this.txt_Categoria.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Categoria.Name = "txt_Categoria";
            this.txt_Categoria.Size = new System.Drawing.Size(472, 32);
            this.txt_Categoria.TabIndex = 458;
            this.txt_Categoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label22.Location = new System.Drawing.Point(42, 327);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(107, 16);
            this.label22.TabIndex = 460;
            this.label22.Text = "Cantidad Minima";
            // 
            // txt_CantidadMinima
            // 
            this.txt_CantidadMinima.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_CantidadMinima.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CantidadMinima.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_CantidadMinima.HintForeColor = System.Drawing.Color.Gray;
            this.txt_CantidadMinima.HintText = "";
            this.txt_CantidadMinima.isPassword = false;
            this.txt_CantidadMinima.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_CantidadMinima.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_CantidadMinima.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_CantidadMinima.LineThickness = 2;
            this.txt_CantidadMinima.Location = new System.Drawing.Point(187, 311);
            this.txt_CantidadMinima.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_CantidadMinima.Name = "txt_CantidadMinima";
            this.txt_CantidadMinima.Size = new System.Drawing.Size(148, 32);
            this.txt_CantidadMinima.TabIndex = 461;
            this.txt_CantidadMinima.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_CantidadMinima.OnValueChanged += new System.EventHandler(this.txt_CantidadMinima_OnValueChanged);
            this.txt_CantidadMinima.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_CantidadMinima_KeyPress);
            // 
            // Frm_Registro_Personal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(797, 465);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txt_CantidadMinima);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txt_Categoria);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txt_PrecioEspecial);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_PrecioVenta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_cantidad);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_Descripcion);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_codigo);
            this.Controls.Add(this.txt_PrecioMayoreo);
            this.Controls.Add(this.txt_PrecioCompra);
            this.Controls.Add(this.txt_tipo);
            this.Controls.Add(this.pnl_titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Registro_Personal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Personal";
            this.Load += new System.EventHandler(this.Frm_Registro_Personal_Load);
            this.pnl_titulo.ResumeLayout(false);
            this.pnl_titulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_aceptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancelar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_titulo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_tipo;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_PrecioCompra;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_PrecioMayoreo;
        private System.Windows.Forms.Label label6;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_IdProducto;
        private System.Windows.Forms.Label label8;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_codigo;
        internal System.Windows.Forms.DateTimePicker dtp_fecha;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public Klik.Windows.Forms.v1.EntryLib.ELButton btn_aceptar;
        public Klik.Windows.Forms.v1.EntryLib.ELButton btn_cancelar;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_Descripcion;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_cantidad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label23;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_CantidadMinima;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_Categoria;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_PrecioEspecial;
        private System.Windows.Forms.Label label10;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_PrecioVenta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
    }
}