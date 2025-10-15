namespace WinFormsWenSoftAdmin.Presentacion.Forms
{
    partial class ABMProductoForm
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
            label2 = new Label();
            nudPrecio = new NumericUpDown();
            nudStock = new NumericUpDown();
            label3 = new Label();
            chkActivo = new CheckBox();
            btnGuardar = new Button();
            label4 = new Label();
            cmbCategoria = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 57);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(72, 54);
            txtNombre.MaxLength = 20;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(353, 23);
            txtNombre.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 85);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 2;
            label2.Text = "Precio:";
            // 
            // nudPrecio
            // 
            nudPrecio.Location = new Point(72, 83);
            nudPrecio.Name = "nudPrecio";
            nudPrecio.Size = new Size(120, 23);
            nudPrecio.TabIndex = 3;
            // 
            // nudStock
            // 
            nudStock.Location = new Point(251, 83);
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(120, 23);
            nudStock.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(206, 85);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 4;
            label3.Text = "Stock:";
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(377, 85);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(60, 19);
            chkActivo.TabIndex = 6;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(148, 172);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(142, 23);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(5, 24);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 8;
            label4.Text = "Categoria:";
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(72, 21);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(353, 23);
            cmbCategoria.TabIndex = 9;
            // 
            // ABMProductoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(437, 207);
            Controls.Add(cmbCategoria);
            Controls.Add(label4);
            Controls.Add(btnGuardar);
            Controls.Add(chkActivo);
            Controls.Add(nudStock);
            Controls.Add(label3);
            Controls.Add(nudPrecio);
            Controls.Add(label2);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ABMProductoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Producto";
            Load += ABMProductoForm_Load;
            ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombre;
        private Label label2;
        private NumericUpDown nudPrecio;
        private NumericUpDown nudStock;
        private Label label3;
        private CheckBox chkActivo;
        private Button btnGuardar;
        private Label label4;
        private ComboBox cmbCategoria;
    }
}