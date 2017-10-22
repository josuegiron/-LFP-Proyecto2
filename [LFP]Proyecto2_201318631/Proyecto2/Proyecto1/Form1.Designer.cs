namespace Proyecto1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lienzo = new System.Windows.Forms.Panel();
            this.tortuga = new System.Windows.Forms.Label();
            this.consola = new System.Windows.Forms.TextBox();
            this.lConsola = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.archivoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pruebaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablaDeSimbolosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archivoDeErroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualDeUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualTécnicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textoentrada1 = new System.Windows.Forms.RichTextBox();
            this.lienzo1 = new System.Windows.Forms.PictureBox();
            this.lienzo.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lienzo1)).BeginInit();
            this.SuspendLayout();
            // 
            // lienzo
            // 
            this.lienzo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lienzo.Controls.Add(this.tortuga);
            this.lienzo.Location = new System.Drawing.Point(375, 50);
            this.lienzo.MaximumSize = new System.Drawing.Size(600, 500);
            this.lienzo.MinimumSize = new System.Drawing.Size(50, 50);
            this.lienzo.Name = "lienzo";
            this.lienzo.Size = new System.Drawing.Size(50, 50);
            this.lienzo.TabIndex = 2;
            // 
            // tortuga
            // 
            this.tortuga.BackColor = System.Drawing.Color.Transparent;
            this.tortuga.Image = ((System.Drawing.Image)(resources.GetObject("tortuga.Image")));
            this.tortuga.Location = new System.Drawing.Point(0, 3);
            this.tortuga.Margin = new System.Windows.Forms.Padding(0);
            this.tortuga.Name = "tortuga";
            this.tortuga.Size = new System.Drawing.Size(32, 32);
            this.tortuga.TabIndex = 0;
            // 
            // consola
            // 
            this.consola.BackColor = System.Drawing.SystemColors.MenuText;
            this.consola.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consola.ForeColor = System.Drawing.Color.White;
            this.consola.Location = new System.Drawing.Point(5, 585);
            this.consola.Margin = new System.Windows.Forms.Padding(5);
            this.consola.Multiline = true;
            this.consola.Name = "consola";
            this.consola.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.consola.Size = new System.Drawing.Size(970, 268);
            this.consola.TabIndex = 0;
            this.consola.TabStop = false;
            this.consola.TextChanged += new System.EventHandler(this.consola_TextChanged);
            // 
            // lConsola
            // 
            this.lConsola.AutoSize = true;
            this.lConsola.Location = new System.Drawing.Point(2, 567);
            this.lConsola.Name = "lConsola";
            this.lConsola.Size = new System.Drawing.Size(48, 13);
            this.lConsola.TabIndex = 5;
            this.lConsola.Text = "Consola:";
            this.lConsola.Click += new System.EventHandler(this.label1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(110, 26);
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.archivoToolStripMenuItem.Text = "archivo";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem1,
            this.salirToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(110, 48);
            // 
            // archivoToolStripMenuItem1
            // 
            this.archivoToolStripMenuItem1.Name = "archivoToolStripMenuItem1";
            this.archivoToolStripMenuItem1.Size = new System.Drawing.Size(109, 22);
            this.archivoToolStripMenuItem1.Text = "archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem2,
            this.runToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(980, 24);
            this.menu.TabIndex = 8;
            this.menu.Text = "menuStrip1";
            this.menu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // archivoToolStripMenuItem2
            // 
            this.archivoToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pruebaToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem,
            this.salirToolStripMenuItem1});
            this.archivoToolStripMenuItem2.Name = "archivoToolStripMenuItem2";
            this.archivoToolStripMenuItem2.Size = new System.Drawing.Size(55, 20);
            this.archivoToolStripMenuItem2.Text = "Archivo";
            // 
            // pruebaToolStripMenuItem
            // 
            this.pruebaToolStripMenuItem.Name = "pruebaToolStripMenuItem";
            this.pruebaToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.pruebaToolStripMenuItem.Text = "Abrir";
            this.pruebaToolStripMenuItem.Click += new System.EventHandler(this.pruebaToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.guardarComoToolStripMenuItem.Text = "Guardar como...";
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.guardarComoToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem1
            // 
            this.salirToolStripMenuItem1.Name = "salirToolStripMenuItem1";
            this.salirToolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
            this.salirToolStripMenuItem1.Text = "Salir";
            this.salirToolStripMenuItem1.Click += new System.EventHandler(this.salirToolStripMenuItem1_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tablaDeSimbolosToolStripMenuItem,
            this.archivoDeErroresToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // tablaDeSimbolosToolStripMenuItem
            // 
            this.tablaDeSimbolosToolStripMenuItem.Name = "tablaDeSimbolosToolStripMenuItem";
            this.tablaDeSimbolosToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.tablaDeSimbolosToolStripMenuItem.Text = "Tabla de símbolos";
            this.tablaDeSimbolosToolStripMenuItem.Click += new System.EventHandler(this.tablaDeSimbolosToolStripMenuItem_Click);
            // 
            // archivoDeErroresToolStripMenuItem
            // 
            this.archivoDeErroresToolStripMenuItem.Name = "archivoDeErroresToolStripMenuItem";
            this.archivoDeErroresToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.archivoDeErroresToolStripMenuItem.Text = "Archivo de errores";
            this.archivoDeErroresToolStripMenuItem.Click += new System.EventHandler(this.archivoDeErroresToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem,
            this.manualDeUsuarioToolStripMenuItem,
            this.manualTécnicoToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de KTurtle";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // manualDeUsuarioToolStripMenuItem
            // 
            this.manualDeUsuarioToolStripMenuItem.Name = "manualDeUsuarioToolStripMenuItem";
            this.manualDeUsuarioToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.manualDeUsuarioToolStripMenuItem.Text = "Manual de usuario";
            this.manualDeUsuarioToolStripMenuItem.Click += new System.EventHandler(this.manualDeUsuarioToolStripMenuItem_Click);
            // 
            // manualTécnicoToolStripMenuItem
            // 
            this.manualTécnicoToolStripMenuItem.Name = "manualTécnicoToolStripMenuItem";
            this.manualTécnicoToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.manualTécnicoToolStripMenuItem.Text = "Manual técnico";
            this.manualTécnicoToolStripMenuItem.Click += new System.EventHandler(this.manualTécnicoToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(372, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Area de dibujo:";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Editor de texto:";
            // 
            // textoentrada1
            // 
            this.textoentrada1.AcceptsTab = true;
            this.textoentrada1.Location = new System.Drawing.Point(5, 50);
            this.textoentrada1.Name = "textoentrada1";
            this.textoentrada1.Size = new System.Drawing.Size(364, 500);
            this.textoentrada1.TabIndex = 11;
            this.textoentrada1.Text = "";
            this.textoentrada1.TextChanged += new System.EventHandler(this.textoentrada1_TextChanged);
            // 
            // lienzo1
            // 
            this.lienzo1.BackColor = System.Drawing.Color.White;
            this.lienzo1.Location = new System.Drawing.Point(378, 106);
            this.lienzo1.Name = "lienzo1";
            this.lienzo1.Size = new System.Drawing.Size(590, 444);
            this.lienzo1.TabIndex = 12;
            this.lienzo1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(980, 858);
            this.Controls.Add(this.lienzo1);
            this.Controls.Add(this.textoentrada1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.lConsola);
            this.Controls.Add(this.consola);
            this.Controls.Add(this.lienzo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menu;
            this.Name = "Form1";
            this.Text = "KTurtle";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.lienzo.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lienzo1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel lienzo;
        private System.Windows.Forms.Label tortuga;
        private System.Windows.Forms.TextBox consola;
        private System.Windows.Forms.Label lConsola;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem pruebaToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tablaDeSimbolosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archivoDeErroresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualDeUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualTécnicoToolStripMenuItem;
        private System.Windows.Forms.RichTextBox textoentrada1;
        private System.Windows.Forms.PictureBox lienzo1;
    }
}

