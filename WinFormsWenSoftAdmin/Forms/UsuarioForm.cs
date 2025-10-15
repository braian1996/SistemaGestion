using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsWenSoftAdmin.Entidades;
using WinFormsWenSoftAdmin.Negocio;

namespace WinFormsWenSoftAdmin.Presentacion.Forms
{
    public partial class UsuarioForm : Form
    {
        private List<Usuario> usuarios = new();
        public UsuarioForm()
        {
            InitializeComponent();
        }

        private void UsuarioForm_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();
            CargarUsuarios();
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            var frm = new ABMUsuarioForm(null);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarUsuarios();
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "Editar")
            {
                if (dgvUsuarios.Rows[e.RowIndex].DataBoundItem is Usuario seleccionado)
                {
                    var frm = new ABMUsuarioForm(seleccionado);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        CargarUsuarios();
                    }
                }
            }
        }
        private void ConfigurarGrilla()
        {
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvUsuarios.Columns.Clear();

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UsuarioNombre",
                HeaderText = "Usuario",
                Name = "Usuario",
                Width = 150
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RolNombre",
                HeaderText = "Rol",
                Name = "Rol"
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "EmpresaNombre",
                HeaderText = "Empresa",
                Name = "Empresa",
                Width = 150
            });

            var colEditar = new DataGridViewImageColumn
            {
                Name = "Editar",
                HeaderText = "",
                Width = 30,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Image = Properties.Resources.editar  
            };
            dgvUsuarios.Columns.Add(colEditar);
        }

        private void CargarUsuarios()
        {
            usuarios = NegocioUsuario.ObtenerUsuarios();
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = usuarios;
        }
    }
}
