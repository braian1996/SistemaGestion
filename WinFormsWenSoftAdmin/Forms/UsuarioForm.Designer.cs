namespace WinFormsWenSoftAdmin.Presentacion.Forms
{
    partial class UsuarioForm
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
            dgvUsuarios = new DataGridView();
            btnNuevoUsuario = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(12, 66);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.Size = new Size(539, 372);
            dgvUsuarios.TabIndex = 0;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
            // 
            // btnNuevoUsuario
            // 
            btnNuevoUsuario.Location = new Point(451, 37);
            btnNuevoUsuario.Name = "btnNuevoUsuario";
            btnNuevoUsuario.Size = new Size(100, 23);
            btnNuevoUsuario.TabIndex = 1;
            btnNuevoUsuario.Text = "Nuevo Usuario";
            btnNuevoUsuario.UseVisualStyleBackColor = true;
            btnNuevoUsuario.Click += btnNuevoUsuario_Click;
            // 
            // UsuarioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(563, 450);
            Controls.Add(btnNuevoUsuario);
            Controls.Add(dgvUsuarios);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UsuarioForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Usuario";
            Load += UsuarioForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvUsuarios;
        private Button btnNuevoUsuario;
    }
}