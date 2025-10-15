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


namespace WinFormsWenSoftAdmin.Presentacion.Forms
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }
        private void MenuForm_Load(object sender, EventArgs e)
        {
            if (SesionActual.Operador || SesionActual.Admin)
            {
                empresaToolStripMenuItem.Enabled = false;
            }
            listadoUsuarioToolStripMenuItem.Enabled = SesionActual.SuperAdmin || SesionActual.Admin;

        }
        private void compraVentaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new MovimientoForm(null);
            frm.ShowDialog();
        }

        private void listadoCompraVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new ListadoMovimientoForm();
            frm.ShowDialog();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void listadoProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new ProductoForm();
            frm.ShowDialog();
        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new ABMProductoForm(null);
            frm.ShowDialog();
        }

        private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new ABMEmpresaForm();
            frm.ShowDialog();
        }

        private void listadoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new UsuarioForm();
            frm.ShowDialog();
        }

        private void listadoDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmCategoria();
            frm.ShowDialog();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Oculta el menú actual
            this.Hide();

            // Reinicia sesión
            SesionActual.IdUsuario = 0;
            SesionActual.IdEmpresa = 0;
            SesionActual.IdRol = 0;

            // Muestra el login nuevamente
            var loginForm = new LoginForm();
            loginForm.Show();

            // Cierra este formulario cuando se cierre el login
            loginForm.FormClosed += (s, args) => this.Close();
        }
    }
}
