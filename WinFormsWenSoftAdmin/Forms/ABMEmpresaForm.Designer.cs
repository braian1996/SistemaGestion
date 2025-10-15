namespace WinFormsWenSoftAdmin.Presentacion.Forms
{
    partial class ABMEmpresaForm
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
            dgvEmpresas = new DataGridView();
            btnNuevaEmpresa = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEmpresas).BeginInit();
            SuspendLayout();
            // 
            // dgvEmpresas
            // 
            dgvEmpresas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmpresas.Location = new Point(12, 50);
            dgvEmpresas.Name = "dgvEmpresas";
            dgvEmpresas.Size = new Size(445, 295);
            dgvEmpresas.TabIndex = 0;
            dgvEmpresas.CellClick += dgvEmpresas_CellClick;
            // 
            // btnNuevaEmpresa
            // 
            btnNuevaEmpresa.Location = new Point(340, 21);
            btnNuevaEmpresa.Name = "btnNuevaEmpresa";
            btnNuevaEmpresa.Size = new Size(117, 23);
            btnNuevaEmpresa.TabIndex = 1;
            btnNuevaEmpresa.Text = "Nueva Empresa";
            btnNuevaEmpresa.UseVisualStyleBackColor = true;
            btnNuevaEmpresa.Click += btnNuevaEmpresa_Click;
            // 
            // ABMEmpresaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(469, 357);
            Controls.Add(btnNuevaEmpresa);
            Controls.Add(dgvEmpresas);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ABMEmpresaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Empresa";
            Load += ABMEmpresaForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEmpresas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvEmpresas;
        private Button btnNuevaEmpresa;
    }
}