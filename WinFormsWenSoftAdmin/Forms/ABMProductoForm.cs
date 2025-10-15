using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsWenSoftAdmin.Datos;
using WinFormsWenSoftAdmin.Entidades;
using WinFormsWenSoftAdmin.Negocio;

namespace WinFormsWenSoftAdmin.Presentacion.Forms
{
    public partial class ABMProductoForm : Form
    {
        private Producto? productoEditar;
        private List<Categoria> categorias = new();
        public ABMProductoForm(Producto? producto = null)
        {
            InitializeComponent();
            this.productoEditar = producto;
        }

        private void ABMProductoForm_Load(object sender, EventArgs e)
        {
            nudPrecio.Maximum = decimal.MaxValue;
            nudStock.Maximum = int.MaxValue;
            nudPrecio.DecimalPlaces = 2;
            chkActivo.Checked = true;

            categorias = NegocioCategoria.ObtenerCategoriasPorEmpresa(SesionActual.IdEmpresa);
            cmbCategoria.DataSource = categorias;
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "Id";

            if (productoEditar != null)
            {
                txtNombre.Text = productoEditar.Nombre;
                nudPrecio.Value = productoEditar.PrecioBase;
                nudStock.Value = productoEditar.Stock;
                chkActivo.Checked = productoEditar.Activo;
                cmbCategoria.SelectedValue = productoEditar.IdCategoria;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtNombre.Text == null || nudPrecio.Value < 0 || nudPrecio.Value == 0 || nudStock.Value < 0 || nudStock.Value == 0)
            {
                MessageBox.Show("Los datos de ingreso son requeridos o son incorrectos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (productoEditar == null)
                    productoEditar = new Producto();

                productoEditar.Nombre = txtNombre.Text.Trim();
                productoEditar.PrecioBase = nudPrecio.Value;
                productoEditar.Stock = (int)nudStock.Value;
                productoEditar.Activo = chkActivo.Checked;
                productoEditar.IdCategoria = (int)cmbCategoria.SelectedValue!;

                // Si está creando y no hay ganancia, usa el precio base
                if (productoEditar.PrecioVenta == 0)
                    productoEditar.PrecioVenta = productoEditar.PrecioBase;

                NegocioProducto.GuardarProducto(productoEditar);
                MessageBox.Show("Producto guardado correctamente.","Guardado" ,MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            nudPrecio.Value = 0;
            nudStock.Value = 0;
            chkActivo.Checked = false;

            productoEditar!.Nombre = "";
            productoEditar.PrecioBase = 0;
            productoEditar.Stock = 0;
            productoEditar.Activo = chkActivo.Checked;
            productoEditar.IdCategoria = 1;
        }
    }
}
