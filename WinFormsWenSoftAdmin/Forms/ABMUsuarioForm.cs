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
    public partial class ABMUsuarioForm : Form
    {
        private Usuario? usuarioEditar;
        public ABMUsuarioForm(Usuario? usuario = null)
        {
            InitializeComponent();
            this.usuarioEditar = usuario;
        }

        private void ABMUsuarioForm_Load(object sender, EventArgs e)
        {
            CargarRoles();
            CargarEmpresas();

            if (usuarioEditar != null)
            {
                txtUsuario.Text = usuarioEditar.UsuarioNombre;
                cmbRol.SelectedValue = usuarioEditar.IdRol;
                cmbEmpresa.SelectedValue = usuarioEditar.IdEmpresa;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Usuario y clave son obligatorios.");
                return;
            }

            Usuario usuario = usuarioEditar ?? new Usuario();

            usuario.UsuarioNombre = txtUsuario.Text.Trim();
            usuario.Clave = Seguridad.ObtenerHashSha256(txtClave.Text.Trim());
            usuario.IdRol = Convert.ToInt32(cmbRol.SelectedValue);
            usuario.IdEmpresa = Convert.ToInt32(cmbEmpresa.SelectedValue);

            try
            {
                NegocioUsuario.GuardarUsuario(usuario);
                MessageBox.Show("Usuario guardado correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }
        private void CargarEmpresas()
        {
            var listaEmpresas = NegocioEmpresa.GetEmpresas();

            if (SesionActual.Admin)
            {
                cmbEmpresa.DataSource = listaEmpresas
                    .Where(e => e.Id == SesionActual.IdEmpresa).ToList();
                cmbEmpresa.Enabled = false; // Solo su empresa
            }
            else
            {
                cmbEmpresa.DataSource = listaEmpresas;
            }

            cmbEmpresa.DisplayMember = "Nombre";
            cmbEmpresa.ValueMember = "Id";
        }
        private void CargarRoles()
        {
            var listaRoles = NegocioRol.ObtenerRoles();

            // Filtrar según el rol del usuario logueado
            if (SesionActual.Admin)
            {
                listaRoles = listaRoles.Where(r => r.Id == 1 || r.Id == 2).ToList(); // Operador o Admin
            }

            cmbRol.DataSource = listaRoles;
            cmbRol.DisplayMember = "Nombre";
            cmbRol.ValueMember = "Id";
        }

    }
}
