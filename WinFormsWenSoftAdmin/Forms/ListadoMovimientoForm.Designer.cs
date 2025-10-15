namespace WinFormsWenSoftAdmin.Presentacion.Forms
{
    partial class ListadoMovimientoForm
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
            dgvMovimientos = new DataGridView();
            label1 = new Label();
            cmbTipo = new ComboBox();
            label2 = new Label();
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            label3 = new Label();
            btnNuevoRegistro = new Button();
            btnFiltrar = new Button();
            btnExportarExcel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
            SuspendLayout();
            // 
            // dgvMovimientos
            // 
            dgvMovimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovimientos.Location = new Point(12, 110);
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.Size = new Size(539, 418);
            dgvMovimientos.TabIndex = 0;
            dgvMovimientos.CellClick += dgvMovimientos_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(-3, 44);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 1;
            label1.Text = "Tipo:";
            // 
            // cmbTipo
            // 
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(36, 41);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(82, 23);
            cmbTipo.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(124, 44);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 3;
            label2.Text = "Fecha Desde:";
            // 
            // dtpDesde
            // 
            dtpDesde.Location = new Point(196, 41);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(97, 23);
            dtpDesde.TabIndex = 4;
            // 
            // dtpHasta
            // 
            dtpHasta.Location = new Point(335, 41);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(97, 23);
            dtpHasta.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(299, 44);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 5;
            label3.Text = "Hasta:";
            // 
            // btnNuevoRegistro
            // 
            btnNuevoRegistro.Location = new Point(447, 81);
            btnNuevoRegistro.Name = "btnNuevoRegistro";
            btnNuevoRegistro.Size = new Size(104, 23);
            btnNuevoRegistro.TabIndex = 7;
            btnNuevoRegistro.Text = "Nuevo Registro";
            btnNuevoRegistro.UseVisualStyleBackColor = true;
            btnNuevoRegistro.Click += btnNuevoRegistro_Click;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(447, 41);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(104, 23);
            btnFiltrar.TabIndex = 8;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.Location = new Point(337, 81);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new Size(104, 23);
            btnExportarExcel.TabIndex = 9;
            btnExportarExcel.Text = "Exportar a Excel";
            btnExportarExcel.UseVisualStyleBackColor = true;
            btnExportarExcel.Click += btnExportarExcel_Click;
            // 
            // ListadoMovimientoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(567, 540);
            Controls.Add(btnExportarExcel);
            Controls.Add(btnFiltrar);
            Controls.Add(btnNuevoRegistro);
            Controls.Add(dtpHasta);
            Controls.Add(label3);
            Controls.Add(dtpDesde);
            Controls.Add(label2);
            Controls.Add(cmbTipo);
            Controls.Add(label1);
            Controls.Add(dgvMovimientos);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ListadoMovimientoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Listado Compra/Venta";
            Load += ListadoMovimientoForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMovimientos;
        private Label label1;
        private ComboBox cmbTipo;
        private Label label2;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Label label3;
        private Button btnNuevoRegistro;
        private Button btnFiltrar;
        private Button btnExportarExcel;
    }
}