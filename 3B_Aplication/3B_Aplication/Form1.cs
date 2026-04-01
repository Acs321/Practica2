using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace _3B_Aplication
{
    public partial class Form1 : Form
    {
        ServiceReference_Ventas.WebVentasSoapClient clientVentas = null;
       //WebVentasSoapClient clientVentas = null;
        BindingSource _bindingSource = new BindingSource();
        private string idCliente = "";

        public Form1()
        {
            InitializeComponent();
            clientVentas = new ServiceReference_Ventas.WebVentasSoapClient();
            ConfigurarGrid();
            CargarClientes();
            CargarProductos();
        }

        private void ConfigurarGrid()
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.Columns.Clear();

            DataGridViewCheckBoxColumn seleccionar = new DataGridViewCheckBoxColumn();
            seleccionar.Name = "Seleccionar";
            seleccionar.HeaderText = "Seleccionar";
            this.dataGridView1.Columns.Add(seleccionar);

            DataGridViewTextBoxColumn cantidad = new DataGridViewTextBoxColumn();
            cantidad.Name = "Cantidad";
            cantidad.HeaderText = "Cantidad";
            this.dataGridView1.Columns.Add(cantidad);

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn 
            { DataPropertyName = "IdProducto"
            , HeaderText = "Id producto"
            , Name = "IdProducto", ReadOnly = true });

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn 
            { DataPropertyName = "Nombre",
                HeaderText = "Nombre", 
                Name = "Nombre", ReadOnly = true, Width = 240 });
            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn 
            { DataPropertyName = "Precio"
            , HeaderText = "Precio"
            , Name = "Precio"
            , ReadOnly = true });

            this.dataGridView1.Columns.Add(
                new DataGridViewTextBoxColumn 
                { DataPropertyName = "Existencia"
                , HeaderText = "Existencia"
                , Name = "Existencia"
                , ReadOnly = true });

            this.dataGridView1.DataSource = this._bindingSource;
        }

        private void CargarClientes()
        {
            try
            {
                var listaClientes = clientVentas.GetAllClientes();
                this.cmbClientes.DataSource = listaClientes;
                this.cmbClientes.DisplayMember = "Nombre";
                this.cmbClientes.ValueMember = "IdCliente";
                this.cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cmbClientes.FormattingEnabled = true;
                if (listaClientes != null && listaClientes.Length > 0)
                {
                    this.cmbClientes.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes \n" + ex.Message);
            }
        }

        private void CargarProductos()
        {
            try
            {
                this._bindingSource.DataSource = clientVentas.GetAllProductos();
                this.dataGridView1.DataSource = this._bindingSource;
                lblTotal.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos \n" + ex.Message);
            }
        }

        private void LimpiarSeleccion()
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                row.Cells["Seleccionar"].Value = false;
                row.Cells["Cantidad"].Value = "";
            }
            lblTotal.Text = "0";
        }

        private ServiceReference_Ventas.DetalleVentaModel[] ObtenerDetalle()
        {
            List<ServiceReference_Ventas.DetalleVentaModel> lista = new List<ServiceReference_Ventas.DetalleVentaModel>();

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                bool seleccionado = false;
                if (row.Cells["Seleccionar"].Value != null)
                {
                    bool.TryParse(row.Cells["Seleccionar"].Value.ToString(), out seleccionado);
                }

                if (seleccionado)
                {
                    int cantidad = 0;
                    if (row.Cells["Cantidad"].Value != null)
                    {
                        int.TryParse(row.Cells["Cantidad"].Value.ToString(), out cantidad);
                    }

                    if (cantidad > 0)
                    {
                        ServiceReference_Ventas.DetalleVentaModel detalle = new ServiceReference_Ventas.DetalleVentaModel();
                        detalle.IdProducto = int.Parse(row.Cells["IdProducto"].Value.ToString());
                        detalle.Cantidad = cantidad;
                        lista.Add(detalle);
                    }
                }
            }

            return lista.ToArray();
        }

        private decimal CalcularTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                bool seleccionado = false;
                if (row.Cells["Seleccionar"].Value != null)
                {
                    bool.TryParse(row.Cells["Seleccionar"].Value.ToString(), out seleccionado);
                }

                if (seleccionado)
                {
                    int cantidad = 0;
                    if (row.Cells["Cantidad"].Value != null)
                    {
                        int.TryParse(row.Cells["Cantidad"].Value.ToString(), out cantidad);
                    }

                    if (cantidad > 0)
                    {
                        decimal precio = decimal.Parse(row.Cells["Precio"].Value.ToString());
                        total = total + (precio * cantidad);
                    }
                }
            }

            return total;
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                var detalle = ObtenerDetalle();
                if (string.IsNullOrEmpty(idCliente))
                {
                    MessageBox.Show("Seleccione un cliente");
                    return;
                }

                if (detalle.Length == 0)
                {
                    MessageBox.Show("Seleccione productos y capture cantidad");
                    return;
                }

                var respuesta = clientVentas.RegistrarVenta(idCliente, detalle);
                if (respuesta != null && respuesta.Respuesta)
                {
                    MessageBox.Show("La venta se registro con el id " + respuesta.IdVenta);
                    CargarProductos();
                    LimpiarSeleccion();
                }
                else
                {
                    if (respuesta != null)
                    {
                        MessageBox.Show(respuesta.Mensaje);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo registrar la venta");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el servicio \n" + ex.Message);
            }
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbClientes.SelectedIndex > -1)
            {
                ServiceReference_Ventas.ClienteModel cliente = (ServiceReference_Ventas.ClienteModel)this.cmbClientes.SelectedItem;
                this.idCliente = cliente.IdCliente;
                txtPais.Text = cliente.Pais;
                txtCiudad.Text = cliente.Ciudad;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            lblTotal.Text = CalcularTotal().ToString();
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.IsCurrentCellDirty)
            {
                this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                if (this.dataGridView1.CurrentCell != null)
                {
                    if (this.dataGridView1.Columns[this.dataGridView1.CurrentCell.ColumnIndex].Name == "Seleccionar")
                    {
                        DataGridViewRow row = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex];
                        bool seleccionado = false;
                        if (row.Cells["Seleccionar"].Value != null)
                        {
                            bool.TryParse(row.Cells["Seleccionar"].Value.ToString(), out seleccionado);
                        }

                        if (seleccionado)
                        {
                            if (row.Cells["Cantidad"].Value == null || row.Cells["Cantidad"].Value.ToString().Equals(""))
                            {
                                row.Cells["Cantidad"].Value = "1";
                            }
                        }
                        else
                        {
                            row.Cells["Cantidad"].Value = "";
                        }
                    }
                }
                lblTotal.Text = CalcularTotal().ToString();
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            CargarClientes();
            CargarProductos();
            LimpiarSeleccion();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                bool seleccionado = false;
                if (row.Cells["Seleccionar"].Value != null)
                {
                    bool.TryParse(row.Cells["Seleccionar"].Value.ToString(), out seleccionado);
                }

                if (seleccionado)
                {
                    if (row.Cells["Cantidad"].Value == null || row.Cells["Cantidad"].Value.ToString().Equals(""))
                    {
                        row.Cells["Cantidad"].Value = "1";
                    }
                }
                else
                {
                    row.Cells["Cantidad"].Value = "";
                }

                lblTotal.Text = CalcularTotal().ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
