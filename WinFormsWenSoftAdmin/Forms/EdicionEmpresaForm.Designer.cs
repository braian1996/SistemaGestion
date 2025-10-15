namespace WinFormsWenSoftAdmin.Presentacion.Forms
{
    partial class EdicionEmpresaForm
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
            txtNombre = new TextBox();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 54);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 0;
            label1.Text = "Empresa:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(73, 51);
            txtNombre.MaxLength = 70;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(304, 23);
            txtNombre.TabIndex = 1;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(139, 149);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(109, 23);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // EdicionEmpresaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(396, 184);
            Controls.Add(btnGuardar);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EdicionEmpresaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Empresa";
            Load += EdicionEmpresaForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombre;
        private Button btnGuardar;
    }
}