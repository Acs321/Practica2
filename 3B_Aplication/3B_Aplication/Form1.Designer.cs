namespace _3B_Aplication
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.grpCliente = new System.Windows.Forms.GroupBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpAcciones = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRecargar = new System.Windows.Forms.Button();
            this.btnRegistrarVenta = new System.Windows.Forms.Button();
            this.grpProductos = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDetalleVenta = new System.Windows.Forms.Button();
            this.grpCliente.SuspendLayout();
            this.grpAcciones.SuspendLayout();
            this.grpProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpCliente
            // 
            this.grpCliente.Controls.Add(this.txtCiudad);
            this.grpCliente.Controls.Add(this.label3);
            this.grpCliente.Controls.Add(this.txtPais);
            this.grpCliente.Controls.Add(this.label2);
            this.grpCliente.Controls.Add(this.cmbClientes);
            this.grpCliente.Controls.Add(this.label1);
            this.grpCliente.Location = new System.Drawing.Point(12, 12);
            this.grpCliente.Name = "grpCliente";
            this.grpCliente.Size = new System.Drawing.Size(1300, 91);
            this.grpCliente.TabIndex = 0;
            this.grpCliente.TabStop = false;
            this.grpCliente.Text = "Datos del cliente";
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(770, 39);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.ReadOnly = true;
            this.txtCiudad.Size = new System.Drawing.Size(190, 22);
            this.txtCiudad.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(713, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ciudad";
            // 
            // txtPais
            // 
            this.txtPais.Location = new System.Drawing.Point(494, 39);
            this.txtPais.Name = "txtPais";
            this.txtPais.ReadOnly = true;
            this.txtPais.Size = new System.Drawing.Size(176, 22);
            this.txtPais.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(458, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pais";
            // 
            // cmbClientes
            // 
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(83, 38);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(341, 24);
            this.cmbClientes.TabIndex = 1;
            this.cmbClientes.SelectedIndexChanged += new System.EventHandler(this.cmbClientes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente";
            // 
            // grpAcciones
            // 
            this.grpAcciones.Controls.Add(this.btnDetalleVenta);
            this.grpAcciones.Controls.Add(this.lblTotal);
            this.grpAcciones.Controls.Add(this.label5);
            this.grpAcciones.Controls.Add(this.btnRecargar);
            this.grpAcciones.Controls.Add(this.btnRegistrarVenta);
            this.grpAcciones.Location = new System.Drawing.Point(12, 109);
            this.grpAcciones.Name = "grpAcciones";
            this.grpAcciones.Size = new System.Drawing.Size(1300, 71);
            this.grpAcciones.TabIndex = 1;
            this.grpAcciones.TabStop = false;
            this.grpAcciones.Text = "Acciones";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(831, 28);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(24, 25);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(766, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "Total";
            // 
            // btnRecargar
            // 
            this.btnRecargar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRecargar.Location = new System.Drawing.Point(462, 21);
            this.btnRecargar.Name = "btnRecargar";
            this.btnRecargar.Size = new System.Drawing.Size(120, 37);
            this.btnRecargar.TabIndex = 1;
            this.btnRecargar.Text = "Recargar";
            this.btnRecargar.UseVisualStyleBackColor = false;
            this.btnRecargar.Click += new System.EventHandler(this.btnRecargar_Click);
            // 
            // btnRegistrarVenta
            // 
            this.btnRegistrarVenta.BackColor = System.Drawing.Color.PaleGreen;
            this.btnRegistrarVenta.Location = new System.Drawing.Point(309, 21);
            this.btnRegistrarVenta.Name = "btnRegistrarVenta";
            this.btnRegistrarVenta.Size = new System.Drawing.Size(136, 37);
            this.btnRegistrarVenta.TabIndex = 0;
            this.btnRegistrarVenta.Text = "Registrar venta";
            this.btnRegistrarVenta.UseVisualStyleBackColor = false;
            this.btnRegistrarVenta.Click += new System.EventHandler(this.btnRegistrarVenta_Click);
            // 
            // grpProductos
            // 
            this.grpProductos.Controls.Add(this.dataGridView1);
            this.grpProductos.Location = new System.Drawing.Point(12, 186);
            this.grpProductos.Name = "grpProductos";
            this.grpProductos.Size = new System.Drawing.Size(1347, 347);
            this.grpProductos.TabIndex = 2;
            this.grpProductos.TabStop = false;
            this.grpProductos.Text = "Productos";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1341, 326);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
            // 
            // btnDetalleVenta
            // 
            this.btnDetalleVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnDetalleVenta.Location = new System.Drawing.Point(990, 22);
            this.btnDetalleVenta.Name = "btnDetalleVenta";
            this.btnDetalleVenta.Size = new System.Drawing.Size(129, 35);
            this.btnDetalleVenta.TabIndex = 4;
            this.btnDetalleVenta.Text = "Detalle de venta";
            this.btnDetalleVenta.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1386, 687);
            this.Controls.Add(this.grpProductos);
            this.Controls.Add(this.grpAcciones);
            this.Controls.Add(this.grpCliente);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de ventas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpCliente.ResumeLayout(false);
            this.grpCliente.PerformLayout();
            this.grpAcciones.ResumeLayout(false);
            this.grpAcciones.PerformLayout();
            this.grpProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCliente;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpAcciones;
        private System.Windows.Forms.Button btnRegistrarVenta;
        private System.Windows.Forms.GroupBox grpProductos;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRecargar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDetalleVenta;
    }
}
