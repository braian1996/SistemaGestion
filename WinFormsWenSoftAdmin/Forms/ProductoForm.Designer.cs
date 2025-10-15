namespace WinFormsWenSoftAdmin.Presentacion.Forms
{
    partial class ProductoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvProductos = new DataGridView();
            nudGananciaGlobal = new NumericUpDown();
            label1 = new Label();
            btnAplicarAGrilla = new Button();
            btnGuardarCambios = new Button();
            btnNuevoProducto = new Button();
            btnExportExcel = new Button();
            label2 = new Label();
            cmbCategoria = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudGananciaGlobal).BeginInit();
            SuspendLayout();
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(12, 66);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new Size(907, 352);
            dgvProductos.TabIndex = 0;
            dgvProductos.CellClick += dgvProductos_CellClick;
            dgvProductos.CellContentClick += dgvProductos_CellContentClick;
            // 
            // nudGananciaGlobal
            // 
            nudGananciaGlobal.Location = new Point(408, 38);
            nudGananciaGlobal.Name = "nudGananciaGlobal";
            nudGananciaGlobal.Size = new Size(76, 23);
            nudGananciaGlobal.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(336, 40);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 2;
            label1.Text = "Porcentaje:";
            // 
            // btnAplicarAGrilla
            // 
            btnAplicarAGrilla.Location = new Point(499, 38);
            btnAplicarAGrilla.Name = "btnAplicarAGrilla";
            btnAplicarAGrilla.Size = new Size(124, 23);
            btnAplicarAGrilla.TabIndex = 3;
            btnAplicarAGrilla.Text = "Aplicar %";
            btnAplicarAGrilla.UseVisualStyleBackColor = true;
            btnAplicarAGrilla.Click += btnAplicarAGrilla_Click;
            // 
            // btnGuardarCambios
            // 
            btnGuardarCambios.Location = new Point(408, 424);
            btnGuardarCambios.Name = "btnGuardarCambios";
            btnGuardarCambios.Size = new Size(145, 23);
            btnGuardarCambios.TabIndex = 4;
            btnGuardarCambios.Text = "Guardar";
            btnGuardarCambios.UseVisualStyleBackColor = true;
            btnGuardarCambios.Click += btnGuardarCambios_Click;
            // 
            // btnNuevoProducto
            // 
            btnNuevoProducto.Location = new Point(795, 37);
            btnNuevoProducto.Name = "btnNuevoProducto";
            btnNuevoProducto.Size = new Size(124, 23);
            btnNuevoProducto.TabIndex = 5;
            btnNuevoProducto.Text = "Nuevo Producto";
            btnNuevoProducto.UseVisualStyleBackColor = true;
            btnNuevoProducto.Click += btnNuevoProducto_Click;
            // 
            // btnExportExcel
            // 
            btnExportExcel.Location = new Point(795, 12);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(124, 23);
            btnExportExcel.TabIndex = 6;
            btnExportExcel.Text = "Exportar a Excel";
            btnExportExcel.UseVisualStyleBackColor = true;
            btnExportExcel.Click += btnExportExcel_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 41);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 7;
            label2.Text = "Categoria:";
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(80, 38);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(162, 23);
            cmbCategoria.TabIndex = 8;
            cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;
            // 
            // ProductoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(931, 450);
            Controls.Add(cmbCategoria);
            Controls.Add(label2);
            Controls.Add(btnExportExcel);
            Controls.Add(btnNuevoProducto);
            Controls.Add(btnGuardarCambios);
            Controls.Add(btnAplicarAGrilla);
            Controls.Add(label1);
            Controls.Add(nudGananciaGlobal);
            Controls.Add(dgvProductos);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProductoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Producto";
            Load += ProductoForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudGananciaGlobal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProductos;
        private NumericUpDown nudGananciaGlobal;
        private Label label1;
        private Button btnAplicarAGrilla;
        private Button btnGuardarCambios;
        private Button btnNuevoProducto;
        private Button btnExportExcel;
        private Label label2;
        private ComboBox cmbCategoria;
    }
}