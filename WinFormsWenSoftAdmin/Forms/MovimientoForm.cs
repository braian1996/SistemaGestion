using System.Windows.Forms;
using WinFormsWenSoftAdmin.Datos;
using WinFormsWenSoftAdmin.Entidades;
using WinFormsWenSoftAdmin.Negocio;

namespace WinFormsWenSoftAdmin.Presentacion.Forms
{
    public partial class MovimientoForm : Form
    {
        private int? idMovimiento_edit;
        private List<Categoria> categorias = new();
        public MovimientoForm(int? idMovimiento)
        {
            InitializeComponent();
            this.idMovimiento_edit = idMovimiento;
        }

        List<Producto> listaProductos = new List<Producto>();

        private void MovimientoForm_Load(object sender, EventArgs e)
        {
            CargarTipoMovimiento();
            categorias = NegocioCategoria.ObtenerCategoriasPorEmpresa(SesionActual.IdEmpresa);
            listaProductos = NegocioProducto.GetProductosPorEmpresa(SesionActual.IdEmpresa);
            ConfigurarGrilla();

            dgvDetalle.DataError += (s, ev) =>
            {
                MessageBox.Show("Error al mostrar los datos en la grilla. Revise categorías y productos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            };

            if (idMovimiento_edit.HasValue)
            {
                var mov = NegocioMovimiento.ObtenerMovimientoPorId(idMovimiento_edit.Value);
                if (mov != null)
                {
                    cmbTipo.SelectedItem = mov.Tipo;
                    cmbTipo.Enabled = false;

                    foreach (var det in mov.Detalles)
                    {                       
                        var producto = listaProductos.FirstOrDefault(p => p.Id == det.IdProducto);
                        int idCategoria = producto?.IdCategoria ?? 0;

                        dgvDetalle.Rows.Add(
                            det.Id=det.Id,
                            det.IdMovimiento = det.IdMovimiento,
                            idCategoria,
                            det.IdProducto,
                            det.Cantidad,
                            det.PrecioUnitario,
                            det.Cantidad * det.PrecioUnitario
                        );
                        var currentRow = dgvDetalle.Rows[dgvDetalle.Rows.Count - 1];
                        var cellProducto = (DataGridViewComboBoxCell)currentRow.Cells["Producto"];
                        var productosFiltrados = listaProductos.Where(p => p.IdCategoria == idCategoria).ToList();
                        cellProducto.DataSource = productosFiltrados;
                        cellProducto.DisplayMember = "Nombre";
                        cellProducto.ValueMember = "Id";
                    }
                }
            }

            dgvDetalle.CellValueChanged += dgvDetalle_CellValueChanged!;
            dgvDetalle.CurrentCellDirtyStateChanged += (s, ev) =>
            {
                if (dgvDetalle.IsCurrentCellDirty)
                {
                    dgvDetalle.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            };
        }

        private void btnAgregarFila_Click(object sender, EventArgs e)
        {
            dgvDetalle.Rows.Add();
        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
#pragma warning disable CS8602
            if (dgvDetalle.Columns["Cantidad"] != null && dgvDetalle.Columns["PrecioUnitario"] != null &&
                (e.ColumnIndex == dgvDetalle.Columns["Cantidad"].Index || e.ColumnIndex == dgvDetalle.Columns["PrecioUnitario"].Index))
            {
                try
                {
                    int cantidad = Convert.ToInt32(dgvDetalle.Rows[e.RowIndex].Cells["Cantidad"].Value);
                    decimal precio = Convert.ToDecimal(dgvDetalle.Rows[e.RowIndex].Cells["PrecioUnitario"].Value);
                    dgvDetalle.Rows[e.RowIndex].Cells["Subtotal"].Value = cantidad * precio;

                    if (cantidad <= 0)
                    {
                        MessageBox.Show("La cantidad debe ser mayor a cero.");
                        dgvDetalle.Rows[e.RowIndex].Cells["Cantidad"].Value = null;
                        return;
                    }

                    if (cmbTipo.SelectedItem?.ToString() == "Venta")
                    {
                        int idProd = Convert.ToInt32(dgvDetalle.Rows[e.RowIndex].Cells["Producto"].Value);
                        var prod = listaProductos.FirstOrDefault(p => p.Id == idProd);

                        if (prod != null && cantidad > prod.Stock)
                        {
                            MessageBox.Show($"Stock insuficiente. Disponible: {prod.Stock}");
                            dgvDetalle.Rows[e.RowIndex].Cells["Cantidad"].Value = null;
                            return;
                        }
                    }
                }
                catch
                {
                    // Opcional: manejar error de formato
                }
            }
        }

        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDetalle.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                var confirm = MessageBox.Show("¿Desea eliminar este ítem?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    int idDetalleMovimiento = Convert.ToInt32(dgvDetalle.Rows[e.RowIndex].Cells["Id"].Value);
                    if (idDetalleMovimiento == 0)
                    {
                        dgvDetalle.Rows.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        NegocioDetallesMovimiento.EliminarRenglonDetalle(Conexion.ObtenerConexion(), idDetalleMovimiento);
                        dgvDetalle.Rows.RemoveAt(e.RowIndex);
                    }
                        
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count <= 0)
            {
                MessageBox.Show("Se debe ingresar al menos un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Movimiento mov = new Movimiento
            {
                Fecha = DateTime.Now,
                Tipo = cmbTipo.SelectedItem.ToString() ?? "",
                IdEmpresa = SesionActual.IdEmpresa,
                Detalles = new List<DetalleMovimiento>()
            };

            decimal total = 0;

            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.IsNewRow) continue;             

                if (row.Cells["Cantidad"].Value == null || string.IsNullOrWhiteSpace(row.Cells["Cantidad"].Value.ToString()))
                {
                    MessageBox.Show("Todas las filas deben tener una cantidad válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal subtotal = Convert.ToInt32(row.Cells["Cantidad"].Value) * Convert.ToDecimal(row.Cells["PrecioUnitario"].Value);

                string tipoMovimiento = cmbTipo.SelectedItem?.ToString() == "Compra" ? "C" : "V";
                NegocioHistoricoProducto.GuardarHistorico(
                    idProducto: Convert.ToInt32(row.Cells["Producto"].Value),
                    tipoMovimiento: tipoMovimiento,
                    idUsuario: SesionActual.IdUsuario,
                    descripcion: $"{tipoMovimiento} de {Convert.ToInt32(row.Cells["Cantidad"].Value)} unidad(es) a precio ${Convert.ToDecimal(row.Cells["PrecioUnitario"].Value)}."
                );

                mov.Detalles.Add(new DetalleMovimiento
                {
                    Id = Convert.ToInt32(row.Cells["Id"].Value),
                    IdMovimiento = Convert.ToInt32(row.Cells["IdMovimiento"].Value),
                    IdProducto = Convert.ToInt32(row.Cells["Producto"].Value),
                    Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value),
                    PrecioUnitario = Convert.ToDecimal(row.Cells["PrecioUnitario"].Value)
                });

                total += subtotal;
            }

            mov.Total = total;

            try
            {
                if (idMovimiento_edit.HasValue)
                {
                    mov.Id = idMovimiento_edit.Value;
                    NegocioMovimiento.ActualizarMovimiento(mov);
                    MessageBox.Show("Movimiento actualizado correctamente.", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    NegocioStock.RegistrarMovimiento(mov);
                    MessageBox.Show("Movimiento registrado correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDetalle.Columns[e.ColumnIndex].Name == "Producto")
            {
                var cell = dgvDetalle.Rows[e.RowIndex].Cells["Producto"];
                if (cell?.Value != null)
                {
                    int idProdSeleccionado = Convert.ToInt32(cell.Value);

                    for (int i = 0; i < dgvDetalle.Rows.Count; i++)
                    {
                        if (i != e.RowIndex && !dgvDetalle.Rows[i].IsNewRow)
                        {
                            var val = dgvDetalle.Rows[i].Cells["Producto"].Value;
                            if (val != null && Convert.ToInt32(val) == idProdSeleccionado)
                            {
                                MessageBox.Show("Este producto ya fue seleccionado en otra fila.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                cell.Value = null;
                                dgvDetalle.Rows[e.RowIndex].Cells["PrecioUnitario"].Value = null;
                                return;
                            }
                        }
                    }
                    var producto = listaProductos.FirstOrDefault(p => p.Id == idProdSeleccionado);
                    if (producto != null)
                    {
                        // Nuevo: Validar stock
                        if (cmbTipo.SelectedItem?.ToString() == "Venta")
                        {
                            if (producto.Stock == 0)
                            {
                                MessageBox.Show("Este producto no tiene stock disponible.", "Stock agotado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                cell.Value = null;
                                dgvDetalle.Rows[e.RowIndex].Cells["PrecioUnitario"].Value = null;
                                return;
                            }
                            else if (producto.Stock <= 10)
                            {
                                MessageBox.Show($"Advertencia: Quedan solo {producto.Stock} unidades de este producto.", "Stock bajo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        dgvDetalle.Rows[e.RowIndex].Cells["PrecioUnitario"].Value = producto.PrecioVenta;
                    }
                }
            }
            else if (e.RowIndex >= 0 && dgvDetalle.Columns[e.ColumnIndex].Name == "Categoria")
            {
                var currentRow = dgvDetalle.Rows[e.RowIndex];
                int idCategoria = Convert.ToInt32(currentRow.Cells["Categoria"].Value);
                var productosFiltrados = NegocioProducto.GetProductosPorCategoria(SesionActual.IdEmpresa, idCategoria).Where(x => x.Activo == true).ToList();

                var cellProducto = (DataGridViewComboBoxCell)currentRow.Cells["Producto"];
                cellProducto.DataSource = productosFiltrados;
                cellProducto.DisplayMember = "Nombre";
                cellProducto.ValueMember = "Id";

                // Limpiar selección previa del producto y precio:
                cellProducto.Value = null;
                currentRow.Cells["PrecioUnitario"].Value = null;
            }
        }

        private void dgvDetalle_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDetalle.IsCurrentCellDirty &&
                dgvDetalle.CurrentCell is DataGridViewComboBoxCell)
            {
                dgvDetalle.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvDetalle.CurrentCell.ColumnIndex == dgvDetalle.Columns["Cantidad"].Index)
            {
                TextBox? txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= SoloNumeros_KeyPress;
                    txt.KeyPress += SoloNumeros_KeyPress;
                }
            }
        }
        private void SoloNumeros_KeyPress(object? sender, KeyPressEventArgs e)
        {
            // Permite solo números y la tecla borrar
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CargarTipoMovimiento()
        {
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("Compra");
            cmbTipo.Items.Add("Venta");
            cmbTipo.SelectedIndex = 0;
        }

        private void ConfigurarGrilla()
        {
            dgvDetalle.Columns.Clear();
            dgvDetalle.AllowUserToAddRows = false;

            var colIdDetalle = new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "Cod.",
                ReadOnly = true,
                Visible = false,
            };
            dgvDetalle.Columns.Add(colIdDetalle);
            var colIdMovimiento = new DataGridViewTextBoxColumn
            {
                Name = "IdMovimiento",
                HeaderText = "IdMovimiento",
                ReadOnly = true,
                Visible = false,
            };
            dgvDetalle.Columns.Add(colIdMovimiento);
            var colCategoria = new DataGridViewComboBoxColumn
            {
                Name = "Categoria",
                HeaderText = "Categoría",
                DataSource = categorias,  // Lista de categorías cargada previamente
                DisplayMember = "Nombre",
                ValueMember = "Id",
                Width = 150
            };
            dgvDetalle.Columns.Add(colCategoria);

            // Columna de Producto
            var colProducto = new DataGridViewComboBoxColumn
            {
                Name = "Producto",
                HeaderText = "Producto",
                DataSource = listaProductos,
                DisplayMember = "Nombre",
                ValueMember = "Id",
                Width = 200
            };
            dgvDetalle.Columns.Add(colProducto);
            dgvDetalle.Columns.Add("Cantidad", "Cantidad");

            var colPrecioUnitario = new DataGridViewTextBoxColumn
            {
                Name = "PrecioUnitario",
                HeaderText = "Precio Unitario",
                ReadOnly = true
            };
            dgvDetalle.Columns.Add(colPrecioUnitario);

            var colSubtotal = new DataGridViewTextBoxColumn
            {
                Name = "Subtotal",
                HeaderText = "Subtotal",
                ReadOnly = true
            };
            dgvDetalle.Columns.Add(colSubtotal);

            var colEliminar = new DataGridViewImageColumn
            {
                Name = "Eliminar",
                HeaderText = "",
                Width = 30,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Image = Properties.Resources.delete
            };
            dgvDetalle.Columns.Add(colEliminar);
        }


    }
}
