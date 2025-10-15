using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using WinFormsWenSoftAdmin.Datos;
using WinFormsWenSoftAdmin.Entidades;

namespace WinFormsWenSoftAdmin.Negocio
{
    public class NegocioEmpresa
    {
        public static List<Empresa> GetEmpresas()
        {
            return DatosEmpresa.GetEmpresas();
        }
        public static List<Empresa> GetEmpresasByLogin()
        {
            return SesionActual.SuperAdmin
                ? DatosEmpresa.GetEmpresas()
                : DatosEmpresa.GetPorUsuario(SesionActual.IdUsuario);
        }

        public static void Guardar(Empresa e)
        {
            DatosEmpresa.Guardar(e);
        }

        public static void Eliminar(int id)
        {
            var validaEmpresaBorrar = DatosEmpresa.EmpresaTieneDependencias(id);
            if (!string.IsNullOrEmpty(validaEmpresaBorrar))
            {
                throw new Exception(validaEmpresaBorrar);
            }
            DatosEmpresa.Eliminar(id);
        }
    }
}
