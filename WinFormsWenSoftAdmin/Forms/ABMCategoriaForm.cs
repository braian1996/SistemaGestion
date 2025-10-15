using System.ComponentModel;
using WinFormsWenSoftAdmin.Datos;
using WinFormsWenSoftAdmin.Entidades;
using WinFormsWenSoftAdmin.Negocio;

namespace WinFormsWenSoftAdmin.Presentacion.Forms
{
    public partial class frmCategoria : Form
    {
        private BindingList<Categoria> categorias = new();
        public frmCategoria()
        {
            InitializeComponent();
        }
        private void frmCategoria_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();
            CargarCategorias();
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                if (dgvCategorias.Rows[e.RowIndex].IsNewRow)
                    return;

                if (dgvCategorias.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    if (dgvCategorias.Rows[e.RowIndex].DataBoundItem is Categoria cat)
                    {
                        if (MessageBox.Show("¿Eliminar la categoría?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                NegocioCategoria.EliminarCategoria(cat.Id);
                                CargarCategorias();
                            }
                            catch (InvalidOperationException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }
        }
        private void btnNuevaCategoria_Click(object sender, EventArgs e)
        {
            categorias.Add(new Categoria { Nombre = "" });  // Agregás una nueva categoría vacía
            //dgvCategorias.DataSource = null;
            //dgvCategorias.DataSource = categorias;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.Rows.Count <= 0)
            {
                MessageBox.Show("Se debe ingresar al menos una Categoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (DataGridViewRow row in dgvCategorias.Rows)
            {
                if (row.IsNewRow) continue;

                int id = row.Cells["Id"].Value == null ? 0 : Convert.ToInt32(row.Cells["Id"].Value);
                string nombre = row.Cells["Nombre"].Value?.ToString()?.Trim() ?? "";

                if (string.IsNullOrWhiteSpace(nombre))
                    continue;

                Categoria c = new Categoria
                {
                    Id = id,
                    Nombre = nombre,
                    IdEmpresa = SesionActual.IdEmpresa
                };

                NegocioCategoria.GuardarCategoria(c);
            }

            MessageBox.Show("Cambios guardados correctamente.");
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            var listacategorias = NegocioCategoria.ObtenerCategoriasPorEmpresa(SesionActual.IdEmpresa) ?? new List<Categoria>(); ;
            categorias = new BindingList<Categoria>(listacategorias);
            dgvCategorias.DataSource = null;
            dgvCategorias.DataSource = categorias;
        }

        private void ConfigurarGrilla()
        {
            dgvCategorias.AutoGenerateColumns = false;
            dgvCategorias.AllowUserToAddRows = false; // Permitir nuevas filas

            dgvCategorias.Columns.Clear();

            dgvCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                Name = "Id",
                HeaderText = "Cod.",
                ReadOnly = true,
                Width = 50
            });

            dgvCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                Name = "Nombre",
                HeaderText = "Categoría",
                Width = 200,
                MaxInputLength = 70
            });
            var colEliminar = new DataGridViewImageColumn
            {
                Name = "Eliminar",
                HeaderText = "",
                Width = 30,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Image = Properties.Resources.delete // asegurate que el recurso existe
            };
            dgvCategorias.Columns.Add(colEliminar);
        }
    }
}
