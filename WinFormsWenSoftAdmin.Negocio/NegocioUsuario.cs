using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsWenSoftAdmin.Datos;
using WinFormsWenSoftAdmin.Entidades;

namespace WinFormsWenSoftAdmin.Negocio
{
    public class NegocioUsuario
    {
        public static Usuario? ValidarUsuario(string usuario, string clavePlano, int idEmpresa)
        {
            string claveHash = Seguridad.ObtenerHashSha256(clavePlano);
            return DatosUsuario.Login(usuario, claveHash, idEmpresa);
        }
        public static List<Usuario> ObtenerUsuarios()
        {
            return DatosUsuario.ObtenerUsuarios(SesionActual.IdEmpresa, SesionActual.IdRol);
        }
        public static void GuardarUsuario(Usuario usuario)
        {
            if (DatosUsuario.ExisteUsuarioDuplicado(usuario))
                throw new Exception("Ya existe un usuario con ese nombre, contraseña y empresa.");

            DatosUsuario.GuardarUsuario(usuario);
        }
    }
}
