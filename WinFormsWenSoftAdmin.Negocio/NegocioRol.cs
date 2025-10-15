using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsWenSoftAdmin.Datos;
using WinFormsWenSoftAdmin.Entidades;

namespace WinFormsWenSoftAdmin.Negocio
{
    public static class NegocioRol
    {
        public static List<Rol> ObtenerRoles()
        {
            return DatosRol.ObtenerRoles();
        }
    }
}
