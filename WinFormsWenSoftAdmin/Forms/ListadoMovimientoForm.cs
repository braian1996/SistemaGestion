using ClosedXML.Excel;
using System.Data;
using WinFormsWenSoftAdmin.Datos;
using WinFormsWenSoftAdmin.Negocio;

namespace WinFormsWenSoftAdmin.Presentacion.Forms
{
    public partial class ListadoMovimientoForm : Form
    {
        public ListadoMovimientoForm()
        {
            InitializeComponent();
        }

        private void ListadoMovimientoForm_Load(object sender, EventArgs e)
        {
            ConfigurarGrillaMovimientos();
            //CargarTipos();
            CargarMovimientos();
            ConfigurarFiltros();
        }

        private void dgvMovimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvMovimientos.Columns[e.ColumnIndex].Name == "Editar")
            {
                int idMov = Convert.ToInt32(dgvMovimientos.Rows[e.RowIndex].Cells["Id"].Value);
                var frm = new MovimientoForm(idMov);
                frm.ShowDialog();
                CargarMovimientos(); // recarga la grilla después
            }
            else if (dgvMovimientos.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                int idMov = Convert.ToInt32(dgvMovimientos.Rows[e.RowIndex].Cells["Id"].Value);
                var confirm = MessageBox.Show("¿Seguro que desea eliminar este movimiento?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        var movimiento_delete = NegocioMovimiento.ObtenerMovimientoPorId(idMov);
                        foreach (var mov in movimiento_delete!.Detalles)
                        {
                            NegocioHistoricoProducto.GuardarHistorico(
                                idProducto: mov.IdProducto,
                                tipoMovimiento: "D",
                                idUsuario: SesionActual.IdUsuario,
                                descripcion: $"Reversión de stock por eliminación del movimiento #{mov.Id} ({mov.IdProducto})"
                            );
                        }
                        NegocioMovimiento.EliminarMovimiento(idMov);
                        MessageBox.Show("Movimiento eliminado correctamente.");
                        CargarMovimientos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message);
                    }
                }
            }
        }
        private void btnNuevoRegistro_Click(object sender, EventArgs e)
        {
            var frm = new MovimientoForm(null);
            frm.ShowDialog();
            CargarMovimientos();
        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            DateTime? desde = dtpDesde.Checked ? dtpDesde.Value.Date : (DateTime?)null;
            DateTime? hasta = dtpHasta.Checked ? dtpHasta.Value.Date : (DateTime?)null;
            string tipo = cmbTipo.SelectedItem?.ToString() ?? "Todos";

            var lista = NegocioMovimiento.FiltrarMovimientos(SesionActual.IdEmpresa, desde, hasta, tipo);
            dgvMovimientos.DataSource = null;
            dgvMovimientos.DataSource = lista;
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            ExportarProductosAExcel();
        }

        private void CargarMovimientos()
        {
            try
            {
                var lista = NegocioMovimiento.GetMovimientosPorEmpresa(SesionActual.IdEmpresa);
                dgvMovimientos.DataSource = null;
                dgvMovimientos.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar movimientos: " + ex.Message);
            }
        }

        private void ConfigurarGrillaMovimientos()
        {
            dgvMovimientos.Columns.Clear();

            dgvMovimientos.AutoGenerateColumns = false;
            dgvMovimientos.ReadOnly = true;

            // ID (oculto)
            dgvMovimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                HeaderText = "Cod.",
                ReadOnly = true,
                Visible = true
            });

            // Fecha
            dgvMovimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Fecha",
                DataPropertyName = "Fecha",
                HeaderText = "Fecha",
                Width = 120
            });

            // Tipo
            dgvMovimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Tipo",
                DataPropertyName = "Tipo",
                HeaderText = "Tipo",
                Width = 80
            });

            // Total
            dgvMovimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Total",
                DataPropertyName = "Total",
                HeaderText = "Total",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "C2",
                    FormatProvider = new System.Globalization.CultureInfo("es-AR")
                }
            });


            // Botón Editar (con ícono)
            var colEditar = new DataGridViewImageColumn
            {
                Name = "Editar",
                HeaderText = "",
                Width = 30,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Image = Properties.Resources.editar,
            };
            dgvMovimientos.Columns.Add(colEditar);
            var colEliminar = new DataGridViewImageColumn
            {
                Name = "Eliminar",
                HeaderText = "",
                Width = 30,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Image = Properties.Resources.delete
            };
            dgvMovimientos.Columns.Add(colEliminar);
        }
        private void ConfigurarFiltros()
        {
            cmbTipo.Items.Add("Todos");
            cmbTipo.Items.Add("Compra");
            cmbTipo.Items.Add("Venta");
            cmbTipo.SelectedIndex = 0;

            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Value = dtpDesde.Value.AddMonths(-1);
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpDesde.ShowCheckBox = true;
            dtpHasta.ShowCheckBox = true;
        }

        private void ExportarProductosAExcel()
        {
            // Supongamos que tu grilla es dgvProductos
            DataTable dt = ObtenerDataTableDesdeDataGridView(dgvMovimientos);

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Guardar Reporte de Productos"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "Movimientos");
                    wb.SaveAs(saveFileDialog.FileName);
                }

                MessageBox.Show("Exportado correctamente.");
            }
        }
        private DataTable ObtenerDataTableDesdeDataGridView(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // Crear columnas (excluyendo columnas de acciones o no deseadas)
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible &&
                    !(column is DataGridViewButtonColumn) &&
                    !(column is DataGridViewImageColumn) &&
                    column.Name != "Editar" &&
                    column.Name != "Eliminar")
                {
                    dt.Columns.Add(column.HeaderText);
                }
            }

            // Agregar filas
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dr = dt.NewRow();
                    int colIndex = 0;
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        if (column.Visible &&
                            !(column is DataGridViewButtonColumn) &&
                            !(column is DataGridViewImageColumn) &&
                            column.Name != "Editar" &&
                            column.Name != "Eliminar")
                        {
                            dr[colIndex] = row.Cells[column.Index].Value ?? "";
                            colIndex++;
                        }
                    }
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }
    }
}
