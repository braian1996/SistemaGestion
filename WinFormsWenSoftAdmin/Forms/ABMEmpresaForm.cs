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
    public partial class ABMEmpresaForm : Form
    {
        private BindingList<Empresa> listaEmpresas = new();
        public ABMEmpresaForm()
        {
            InitializeComponent();
        }

        private void ABMEmpresaForm_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();
            CargarEmpresas();
        }
        private void dgvEmpresas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var empresa = dgvEmpresas.Rows[e.RowIndex].DataBoundItem as Empresa;
            if (empresa == null) return;

            var colName = dgvEmpresas.Columns[e.ColumnIndex].Name;

            if (colName == "Editar")
            {
                var frm = new EdicionEmpresaForm(empresa);
                if (frm.ShowDialog() == DialogResult.OK)
                    CargarEmpresas();
            }

            if (colName == "Eliminar")
            {
                var confirm = MessageBox.Show($"¿Eliminar la empresa \"{empresa.Nombre}\"?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        NegocioEmpresa.Eliminar(empresa.Id);
                        CargarEmpresas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message);
                    }
                }
            }
        }
        private void btnNuevaEmpresa_Click(object sender, EventArgs e)
        {
            var frm = new EdicionEmpresaForm(null);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarEmpresas();
            }
        }

        private void ConfigurarGrilla()
        {
            dgvEmpresas.AutoGenerateColumns = false;
            dgvEmpresas.Columns.Clear();
            dgvEmpresas.ReadOnly = true;

            dgvEmpresas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "Nombre",
                Name = "Nombre",
                Width = 200
            });

            // Columna editar
            dgvEmpresas.Columns.Add(new DataGridViewImageColumn
            {
                Name = "Editar",
                HeaderText = "",
                Width = 30,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Image = Properties.Resources.editar
            });

            // Columna eliminar
            dgvEmpresas.Columns.Add(new DataGridViewImageColumn
            {
                Name = "Eliminar",
                HeaderText = "",
                Width = 30,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Image = Properties.Resources.delete
            });
        }
        private void CargarEmpresas()
        {
            var lista = NegocioEmpresa.GetEmpresasByLogin() ?? new List<Empresa>();
            listaEmpresas = new BindingList<Empresa>(lista);
            dgvEmpresas.DataSource = null;
            dgvEmpresas.DataSource = listaEmpresas;
        }

    }
}
