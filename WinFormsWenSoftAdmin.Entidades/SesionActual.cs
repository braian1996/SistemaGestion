using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsWenSoftAdmin.Datos
{
    public static class SesionActual
    {
        public static int IdEmpresa { get; set; }
        public static int IdUsuario { get; set; }
        public static string UsuarioNombre { get; set; } = "";
        public static int IdRol { get; set; }
        public static bool SuperAdmin => IdRol == 3;
        public static bool Admin => IdRol == 2;
        public static bool Operador => IdRol == 1;
    }
}
