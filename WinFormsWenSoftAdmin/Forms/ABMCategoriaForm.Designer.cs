namespace WinFormsWenSoftAdmin.Presentacion.Forms
{
    partial class frmCategoria
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
            dgvCategorias = new DataGridView();
            btnGuardar = new Button();
            btnNuevaCategoria = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            SuspendLayout();
            // 
            // dgvCategorias
            // 
            dgvCategorias.Location = new Point(12, 39);
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.Size = new Size(427, 292);
            dgvCategorias.TabIndex = 0;
            dgvCategorias.CellClick += dgvCategorias_CellClick;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(157, 337);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(121, 23);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNuevaCategoria
            // 
            btnNuevaCategoria.Location = new Point(318, 12);
            btnNuevaCategoria.Name = "btnNuevaCategoria";
            btnNuevaCategoria.Size = new Size(121, 23);
            btnNuevaCategoria.TabIndex = 2;
            btnNuevaCategoria.Text = "Nueva Categoria";
            btnNuevaCategoria.UseVisualStyleBackColor = true;
            btnNuevaCategoria.Click += btnNuevaCategoria_Click;
            // 
            // frmCategoria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 366);
            Controls.Add(btnNuevaCategoria);
            Controls.Add(btnGuardar);
            Controls.Add(dgvCategorias);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCategoria";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Categoria";
            Load += frmCategoria_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvCategorias;
        private Button btnGuardar;
        private Button btnNuevaCategoria;
    }
}