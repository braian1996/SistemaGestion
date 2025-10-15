namespace WinFormsWenSoftAdmin.Presentacion.Forms
{
    partial class MovimientoForm
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
            dgvDetalle = new DataGridView();
            label1 = new Label();
            cmbTipo = new ComboBox();
            btnAgregarFila = new Button();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            SuspendLayout();
            // 
            // dgvDetalle
            // 
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.Location = new Point(12, 41);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.Size = new Size(776, 362);
            dgvDetalle.TabIndex = 0;
            dgvDetalle.CellClick += dgvDetalle_CellClick;
            dgvDetalle.CellEndEdit += dgvDetalle_CellEndEdit;
            dgvDetalle.CellValueChanged += dgvDetalle_CellValueChanged;
            dgvDetalle.CurrentCellDirtyStateChanged += dgvDetalle_CurrentCellDirtyStateChanged;
            dgvDetalle.EditingControlShowing += dgvDetalle_EditingControlShowing;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 15);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 1;
            label1.Text = "Movimiento:";
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(90, 12);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(121, 23);
            cmbTipo.TabIndex = 2;
            // 
            // btnAgregarFila
            // 
            btnAgregarFila.Location = new Point(652, 12);
            btnAgregarFila.Name = "btnAgregarFila";
            btnAgregarFila.Size = new Size(136, 23);
            btnAgregarFila.TabIndex = 3;
            btnAgregarFila.Text = "Agregar Producto";
            btnAgregarFila.UseVisualStyleBackColor = true;
            btnAgregarFila.Click += btnAgregarFila_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(305, 415);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(164, 23);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // MovimientoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGuardar);
            Controls.Add(btnAgregarFila);
            Controls.Add(cmbTipo);
            Controls.Add(label1);
            Controls.Add(dgvDetalle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MovimientoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Movimiento";
            Load += MovimientoForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDetalle;
        private Label label1;
        private ComboBox cmbTipo;
        private Button btnAgregarFila;
        private Button btnGuardar;
    }
}