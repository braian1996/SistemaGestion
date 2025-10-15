
namespace WinFormsWenSoftAdmin
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtUsuario = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtContraseña = new TextBox();
            cmbEmpresa = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            btnLogin = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(108, 116);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(247, 23);
            txtUsuario.TabIndex = 0;
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 148);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 3;
            label2.Text = "Contraseña:";
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(108, 145);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(247, 23);
            txtContraseña.TabIndex = 2;
            txtContraseña.UseSystemPasswordChar = true;
            // 
            // cmbEmpresa
            // 
            cmbEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmpresa.FormattingEnabled = true;
            cmbEmpresa.Location = new Point(108, 174);
            cmbEmpresa.Name = "cmbEmpresa";
            cmbEmpresa.Size = new Size(247, 23);
            cmbEmpresa.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 177);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 5;
            label3.Text = "Empresa:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(130, 27);
            label4.Name = "label4";
            label4.Size = new Size(182, 32);
            label4.TabIndex = 6;
            label4.Text = "WenSoft Admin";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(150, 240);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(145, 23);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Iniciar Sesion";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(47, 119);
            label5.Name = "label5";
            label5.Size = new Size(50, 15);
            label5.TabIndex = 9;
            label5.Text = "Usuario:";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 367);
            Controls.Add(label5);
            Controls.Add(btnLogin);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cmbEmpresa);
            Controls.Add(label2);
            Controls.Add(txtContraseña);
            Controls.Add(label1);
            Controls.Add(txtUsuario);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private TextBox txtUsuario;
        private Label label1;
        private Label label2;
        private TextBox txtContraseña;
        private ComboBox cmbEmpresa;
        private Label label3;
        private Label label4;
        private Button btnLogin;
        private Label label5;
    }
}
