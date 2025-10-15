using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsWenSoftAdmin.Entidades;
using WinFormsWenSoftAdmin.Negocio;

namespace WinFormsWenSoftAdmin.Presentacion.Forms
{
    public partial class EdicionEmpresaForm : Form
    {
        private Empresa? empresaEditar;
        public EdicionEmpresaForm(Empresa? empresa = null)
        {
            InitializeComponent();
            this.empresaEditar = empresa;
        }

        private void EdicionEmpresaForm_Load(object sender, EventArgs e)
        {
            if (empresaEditar != null)
            {
                txtNombre.Text = empresaEditar.Nombre;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (empresaEditar == null)
                    empresaEditar = new Empresa();

                empresaEditar.Nombre = txtNombre.Text.Trim();

                // Validación básica
                if (string.IsNullOrWhiteSpace(empresaEditar.Nombre))
                {
                    MessageBox.Show("El nombre de la empresa es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                NegocioEmpresa.Guardar(empresaEditar);
                MessageBox.Show("Empresa guardada correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
