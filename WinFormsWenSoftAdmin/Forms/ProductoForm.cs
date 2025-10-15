using ClosedXML.Excel;
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
    public partial class ProductoForm : Form
    {
        private List<Producto> productos = new();
        private List<Categoria> categorias = new();
        public ProductoForm()
        {
            InitializeComponent();
        }

        private void ProductoForm_Load(object sender, EventArgs e)
        {
            try
            {
                categorias = NegocioCategoria.ObtenerCategoriasPorEmpresa(SesionActual.IdEmpresa);
                ConfigurarGrilla();
                CargarProductos();
                CargarCategorias();
                cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged!;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar formulario: " + ex.Message);
            }
        }

        private void btnAplicarAGrilla_Click(object sender, EventArgs e)
        {
            if (nudGananciaGlobal.Value > 100)
            {
                MessageBox.Show("No se puede aplicar un % mayor a 100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (nudGananciaGlobal.Value <= 0)
            {
                MessageBox.Show("No se puede aplicar un % menor o igual 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            decimal porcentaje = nudGananciaGlobal.Value;

            if (dgvProductos.IsCurrentCellInEditMode)
            {
                dgvProductos.EndEdit();
            }
            var seleccionados = productos.Where(p => p.Seleccionado).ToList();

            if (seleccionados.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NegocioProducto.AplicarPorcentajeAGrilla(seleccionados, porcentaje);
            dgvProductos.Refresh();
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            foreach (var p in productos)
            {
                NegocioProducto.GuardarProducto(p);

                NegocioHistoricoProducto.GuardarHistorico(
                    idProducto: p.Id,
                    tipoMovimiento: "AP",
                    idUsuario: SesionActual.IdUsuario,
                    descripcion: $"Actualización de precio: ${p.PrecioBase} / Activo: {(p.Activo ? "Sí" : "No")}"
                );

                if (!p.Activo)
                {
                    NegocioHistoricoProducto.GuardarHistorico(
                        idProducto: p.Id,
                        tipoMovimiento: "I",
                        idUsuario: SesionActual.IdUsuario,
                        descripcion: "Producto marcado como inactivo."
                    );
                }
            }

            MessageBox.Show("Cambios guardados correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            var frm = new ABMProductoForm(null);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarProductos();
            }
        }
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string nombreColumna = dgvProductos.Columns[e.ColumnIndex].Name;

            try
            {
                if (dgvProductos.Rows[e.RowIndex].DataBoundItem is Producto seleccionado)
                {
                    if (nombreColumna == "Editar")
                    {
                        var frm = new ABMProductoForm(seleccionado);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            CargarProductos();
                        }
                    }
                    else if (nombreColumna == "Eliminar")
                    {
                        var confirmar = MessageBox.Show(
                            $"¿Seguro que desea eliminar el producto \"{seleccionado.Nombre}\"?",
                            "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (confirmar == DialogResult.Yes)
                        {
                            NegocioProducto.EliminarProducto(seleccionado.Id);
                            CargarProductos();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedItem is Categoria categoriaSeleccionada)
            {
                int idCategoria = categoriaSeleccionada.Id;

                // 1. Obtener productos según la categoría seleccionada
                productos = (idCategoria == 0)
                    ? NegocioProducto.GetProductosPorEmpresa(SesionActual.IdEmpresa)
                    : NegocioProducto.GetProductosPorCategoria(SesionActual.IdEmpresa, idCategoria);

                productos = productos?.Where(p => p != null).ToList() ?? new List<Producto>();

                // 2. Asegurar que todos los IdCategoria tengan una categoría válida
                foreach (var producto in productos)
                {
                    var cat = categorias.FirstOrDefault(c => c.Id == producto.IdCategoria);
                    if (cat == null)
                    {
                        var nueva = new Categoria { Id = producto.IdCategoria, Nombre = "Desconocida" };
                        categorias.Add(nueva);
                    }

                    producto.NombreCategoria = cat?.Nombre ?? "Desconocida";
                }

                // 3. Asignar categorías al ComboBox de la grilla (después de cargarlas)
                if (dgvProductos.Columns["Categoria"] is DataGridViewComboBoxColumn colCategoria)
                {
                    colCategoria.DataSource = null;
                    colCategoria.DataSource = categorias;
                    colCategoria.DisplayMember = "Nombre";
                    colCategoria.ValueMember = "Id";
                }

                // 4. Mostrar productos en la grilla
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = productos;
            }
        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportarProductosAExcel();
        }

        private void CargarCategorias()
        {
            var categoriasFiltro = NegocioCategoria.ObtenerCategoriasPorEmpresa(SesionActual.IdEmpresa);
            categorias = categoriasFiltro.ToList();  // Solo las reales, sin "TODOS"

            // Solo para el ComboBox de filtro, no para la grilla
            var listaFiltro = categoriasFiltro.Select(c => new Categoria { Id = c.Id, Nombre = c.Nombre }).ToList();
            listaFiltro.Insert(0, new Categoria { Id = 0, Nombre = "TODOS" });

            cmbCategoria.DataSource = listaFiltro;
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "Id";
        }
        private void ConfigurarGrilla()
        {
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            var chkCol = new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "Seleccionado",
                Name = "Seleccionado",
                HeaderText = "",
                Width = 30
            };
            dgvProductos.Columns.Insert(0, chkCol);

            // 2. Crear checkbox flotante sobre el header
            CheckBox chkHeader = new CheckBox();
            chkHeader.Size = new Size(15, 15);
            chkHeader.BackColor = Color.Transparent;

            // Posicionarlo correctamente
            Rectangle rect = dgvProductos.GetCellDisplayRectangle(0, -1, true);
            chkHeader.Location = new Point(
                rect.Location.X + (rect.Width - chkHeader.Width) / 2,
                rect.Location.Y + (rect.Height - chkHeader.Height) / 2);

            // Manejar evento CheckedChanged
            chkHeader.CheckedChanged += (s, e) =>
            {
                bool estado = chkHeader.Checked;

                if (dgvProductos.IsCurrentCellInEditMode)
                {
                    dgvProductos.EndEdit();
                }

                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    row.Cells["Seleccionado"].Value = estado;
                }
            };

            // Agregar al DataGridView
            dgvProductos.Controls.Add(chkHeader);

            var colCategoria = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "IdCategoria",
                Name = "Categoria",
                HeaderText = "Categoría",
                DataSource = categorias,
                DisplayMember = "Nombre",
                ValueMember = "Id",
                Width = 150
            };
            dgvProductos.Columns.Add(colCategoria);

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Name = "Nombre",
                Width = 200
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioBase",
                HeaderText = "Precio Base",
                Name = "PrecioBase"
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioVenta",
                HeaderText = "Precio Venta",
                Name = "PrecioVenta"
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Stock",
                HeaderText = "Stock",
                Name = "Stock"
            });

            dgvProductos.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "Activo",
                HeaderText = "Activo",
                Name = "Activo"
            });
            var colEditar = new DataGridViewImageColumn
            {
                Name = "Editar",
                HeaderText = "",
                Width = 30,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Image = Properties.Resources.editar,
            };
            dgvProductos.Columns.Add(colEditar);
            var colEliminar = new DataGridViewImageColumn
            {
                Name = "Eliminar",
                HeaderText = "",
                Width = 30,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Image = Properties.Resources.delete // asegurate que el recurso existe
            };
            dgvProductos.Columns.Add(colEliminar);
        }

        private void CargarProductos()
        {
            int idcategoriaSeleccionado = cmbCategoria.SelectedValue is null ? 0 : (int)cmbCategoria.SelectedValue;
            categorias = NegocioCategoria.ObtenerCategoriasPorEmpresa(SesionActual.IdEmpresa);
 
            productos = (idcategoriaSeleccionado == 0) 
                ? NegocioProducto.GetProductosPorEmpresa(SesionActual.IdEmpresa)
                : NegocioProducto.GetProductosPorCategoria(SesionActual.IdEmpresa, idcategoriaSeleccionado);


            foreach (var producto in productos)
            {
                var categoria = categorias.FirstOrDefault(c => c.Id == producto.IdCategoria);
                if (categoria == null)
                {
                    categoria = new Categoria { Id = producto.IdCategoria, Nombre = "Categoría desconocida" };
                    categorias.Add(categoria);
                }

                producto.NombreCategoria = categoria.Nombre;
            }
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = productos;
            
        }

        private void ExportarProductosAExcel()
        {
            // Supongamos que tu grilla es dgvProductos
            DataTable dt = ObtenerDataTableDesdeDataGridView(dgvProductos);

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Guardar Reporte de Productos"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "Productos");
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
                    column.Name != "Eliminar" &&
                    column.Name != "Seleccionado")
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
                            column.Name != "Eliminar" &&
                            column.Name != "Seleccionado")
                        {
                            object valor = row.Cells[column.Index].Value ?? "";

                            if (column.Name == "Categoria")
                            {
                                int idCategoria = 0;
                                int.TryParse(valor.ToString(), out idCategoria);
                                var cat = categorias.FirstOrDefault(c => c.Id == idCategoria);
                                valor = cat?.Nombre ?? "Sin categoría";
                            }

                            dr[colIndex] = valor;
                            colIndex++;
                        }
                    }
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
