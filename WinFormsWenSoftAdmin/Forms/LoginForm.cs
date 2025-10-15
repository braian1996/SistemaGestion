using System.Security.Policy;
using WinFormsWenSoftAdmin.Datos;
using WinFormsWenSoftAdmin.Entidades;
using WinFormsWenSoftAdmin.Negocio;
using WinFormsWenSoftAdmin.Presentacion.Forms;

namespace WinFormsWenSoftAdmin
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                List<Empresa> lista = NegocioEmpresa.GetEmpresas();

                cmbEmpresa.DataSource = lista;
                cmbEmpresa.DisplayMember = "Nombre";
                cmbEmpresa.ValueMember = "Id";
                cmbEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empresas: " + ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string clave = txtContraseña.Text.Trim();
            if (cmbEmpresa.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una empresa.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idEmpresa = Convert.ToInt32(cmbEmpresa.SelectedValue);

            try
            {
                Entidades.Usuario? user = NegocioUsuario.ValidarUsuario(usuario, clave, idEmpresa);
                if (user != null)
                {
                    SesionActual.IdEmpresa = user.IdEmpresa;
                    SesionActual.IdUsuario = user.Id;
                    SesionActual.UsuarioNombre = user.UsuarioNombre ?? "";
                    SesionActual.IdRol = user.IdRol;
                    new MenuForm().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
