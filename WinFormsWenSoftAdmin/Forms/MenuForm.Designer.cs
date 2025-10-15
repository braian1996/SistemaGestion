namespace WinFormsWenSoftAdmin.Presentacion.Forms
{
    partial class MenuForm
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
            menuWenSoft = new MenuStrip();
            movimientoToolStripMenuItem = new ToolStripMenuItem();
            compraVentaToolStripMenuItem1 = new ToolStripMenuItem();
            listadoCompraVentaToolStripMenuItem = new ToolStripMenuItem();
            gestionToolStripMenuItem = new ToolStripMenuItem();
            productoToolStripMenuItem = new ToolStripMenuItem();
            listadoProductosToolStripMenuItem = new ToolStripMenuItem();
            nuevoProductoToolStripMenuItem = new ToolStripMenuItem();
            categoriasToolStripMenuItem = new ToolStripMenuItem();
            empresaToolStripMenuItem = new ToolStripMenuItem();
            usuarioToolStripMenuItem = new ToolStripMenuItem();
            listadoUsuarioToolStripMenuItem = new ToolStripMenuItem();
            sesiónToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            menuWenSoft.SuspendLayout();
            SuspendLayout();
            // 
            // menuWenSoft
            // 
            menuWenSoft.Items.AddRange(new ToolStripItem[] { movimientoToolStripMenuItem, gestionToolStripMenuItem, usuarioToolStripMenuItem, sesiónToolStripMenuItem });
            menuWenSoft.Location = new Point(0, 0);
            menuWenSoft.Name = "menuWenSoft";
            menuWenSoft.Size = new Size(1325, 24);
            menuWenSoft.TabIndex = 1;
            menuWenSoft.Text = "menuStrip2";
            // 
            // movimientoToolStripMenuItem
            // 
            movimientoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { compraVentaToolStripMenuItem1, listadoCompraVentaToolStripMenuItem });
            movimientoToolStripMenuItem.Name = "movimientoToolStripMenuItem";
            movimientoToolStripMenuItem.Size = new Size(84, 20);
            movimientoToolStripMenuItem.Text = "Movimiento";
            // 
            // compraVentaToolStripMenuItem1
            // 
            compraVentaToolStripMenuItem1.Name = "compraVentaToolStripMenuItem1";
            compraVentaToolStripMenuItem1.Size = new Size(192, 22);
            compraVentaToolStripMenuItem1.Text = "Compra/Venta";
            compraVentaToolStripMenuItem1.Click += compraVentaToolStripMenuItem1_Click;
            // 
            // listadoCompraVentaToolStripMenuItem
            // 
            listadoCompraVentaToolStripMenuItem.Name = "listadoCompraVentaToolStripMenuItem";
            listadoCompraVentaToolStripMenuItem.Size = new Size(192, 22);
            listadoCompraVentaToolStripMenuItem.Text = "Listado Compra/Venta";
            listadoCompraVentaToolStripMenuItem.Click += listadoCompraVentaToolStripMenuItem_Click;
            // 
            // gestionToolStripMenuItem
            // 
            gestionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { productoToolStripMenuItem, empresaToolStripMenuItem });
            gestionToolStripMenuItem.Name = "gestionToolStripMenuItem";
            gestionToolStripMenuItem.Size = new Size(59, 20);
            gestionToolStripMenuItem.Text = "Gestion";
            // 
            // productoToolStripMenuItem
            // 
            productoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listadoProductosToolStripMenuItem, nuevoProductoToolStripMenuItem, categoriasToolStripMenuItem });
            productoToolStripMenuItem.Name = "productoToolStripMenuItem";
            productoToolStripMenuItem.Size = new Size(123, 22);
            productoToolStripMenuItem.Text = "Producto";
            productoToolStripMenuItem.Click += productoToolStripMenuItem_Click;
            // 
            // listadoProductosToolStripMenuItem
            // 
            listadoProductosToolStripMenuItem.Name = "listadoProductosToolStripMenuItem";
            listadoProductosToolStripMenuItem.Size = new Size(169, 22);
            listadoProductosToolStripMenuItem.Text = "Listado Productos";
            listadoProductosToolStripMenuItem.Click += listadoProductosToolStripMenuItem_Click;
            // 
            // nuevoProductoToolStripMenuItem
            // 
            nuevoProductoToolStripMenuItem.Name = "nuevoProductoToolStripMenuItem";
            nuevoProductoToolStripMenuItem.Size = new Size(169, 22);
            nuevoProductoToolStripMenuItem.Text = "Nuevo Producto";
            nuevoProductoToolStripMenuItem.Click += nuevoProductoToolStripMenuItem_Click;
            // 
            // categoriasToolStripMenuItem
            // 
            categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            categoriasToolStripMenuItem.Size = new Size(169, 22);
            categoriasToolStripMenuItem.Text = "Categorias";
            categoriasToolStripMenuItem.Click += categoriasToolStripMenuItem_Click;
            // 
            // empresaToolStripMenuItem
            // 
            empresaToolStripMenuItem.Name = "empresaToolStripMenuItem";
            empresaToolStripMenuItem.Size = new Size(123, 22);
            empresaToolStripMenuItem.Text = "Empresa";
            empresaToolStripMenuItem.Click += empresaToolStripMenuItem_Click;
            // 
            // usuarioToolStripMenuItem
            // 
            usuarioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listadoUsuarioToolStripMenuItem });
            usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            usuarioToolStripMenuItem.Size = new Size(59, 20);
            usuarioToolStripMenuItem.Text = "Usuario";
            // 
            // listadoUsuarioToolStripMenuItem
            // 
            listadoUsuarioToolStripMenuItem.Name = "listadoUsuarioToolStripMenuItem";
            listadoUsuarioToolStripMenuItem.Size = new Size(180, 22);
            listadoUsuarioToolStripMenuItem.Text = "Listado Usuarios";
            listadoUsuarioToolStripMenuItem.Click += listadoUsuarioToolStripMenuItem_Click;
            // 
            // sesiónToolStripMenuItem
            // 
            sesiónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cerrarSesiónToolStripMenuItem });
            sesiónToolStripMenuItem.Name = "sesiónToolStripMenuItem";
            sesiónToolStripMenuItem.Size = new Size(53, 20);
            sesiónToolStripMenuItem.Text = "Sesión";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(180, 22);
            cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            cerrarSesiónToolStripMenuItem.Click += cerrarSesiónToolStripMenuItem_Click;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1325, 685);
            Controls.Add(menuWenSoft);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MenuForm";
            Text = "Menu";
            WindowState = FormWindowState.Maximized;
            Load += MenuForm_Load;
            menuWenSoft.ResumeLayout(false);
            menuWenSoft.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuWenSoft;
        private ToolStripMenuItem movimientoToolStripMenuItem;
        private ToolStripMenuItem compraVentaToolStripMenuItem1;
        private ToolStripMenuItem gestionToolStripMenuItem;
        private ToolStripMenuItem productoToolStripMenuItem;
        private ToolStripMenuItem usuarioToolStripMenuItem;
        private ToolStripMenuItem listadoUsuarioToolStripMenuItem;
        private ToolStripMenuItem listadoCompraVentaToolStripMenuItem;
        private ToolStripMenuItem listadoProductosToolStripMenuItem;
        private ToolStripMenuItem nuevoProductoToolStripMenuItem;
        private ToolStripMenuItem empresaToolStripMenuItem;
        private ToolStripMenuItem categoriasToolStripMenuItem;
        private ToolStripMenuItem sesiónToolStripMenuItem;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
    }
}