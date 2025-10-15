namespace WinFormsWenSoftAdmin.Presentacion.Forms
{
    partial class ABMUsuarioForm
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
            label1 = new Label();
            txtUsuario = new TextBox();
            txtClave = new TextBox();
            label2 = new Label();
            label3 = new Label();
            cmbRol = new ComboBox();
            cmbEmpresa = new ComboBox();
            label4 = new Label();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 59);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 0;
            label1.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(73, 56);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(138, 23);
            txtUsuario.TabIndex = 1;
            // 
            // txtClave
            // 
            txtClave.Location = new Point(299, 56);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(138, 23);
            txtClave.TabIndex = 3;
            txtClave.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(254, 59);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 2;
            label2.Text = "Clave:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 117);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 4;
            label3.Text = "Rol:";
            // 
            // cmbRol
            // 
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(73, 114);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(138, 23);
            cmbRol.TabIndex = 5;
            // 
            // cmbEmpresa
            // 
            cmbEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmpresa.FormattingEnabled = true;
            cmbEmpresa.Location = new Point(299, 114);
            cmbEmpresa.Name = "cmbEmpresa";
            cmbEmpresa.Size = new Size(138, 23);
            cmbEmpresa.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(238, 117);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 6;
            label4.Text = "Empresa:";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(155, 191);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(138, 23);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // ABMUsuarioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 241);
            Controls.Add(btnGuardar);
            Controls.Add(cmbEmpresa);
            Controls.Add(label4);
            Controls.Add(cmbRol);
            Controls.Add(label3);
            Controls.Add(txtClave);
            Controls.Add(label2);
            Controls.Add(txtUsuario);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ABMUsuarioForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Usuario";
            Load += ABMUsuarioForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtUsuario;
        private TextBox txtClave;
        private Label label2;
        private Label label3;
        private ComboBox cmbRol;
        private ComboBox cmbEmpresa;
        private Label label4;
        private Button btnGuardar;
    }
}