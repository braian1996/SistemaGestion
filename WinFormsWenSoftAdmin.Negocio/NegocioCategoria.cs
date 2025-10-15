using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsWenSoftAdmin.Datos;
using WinFormsWenSoftAdmin.Entidades;

namespace WinFormsWenSoftAdmin.Negocio
{
    public static class NegocioCategoria
    {
        public static List<Categoria> ObtenerCategoriasPorEmpresa(int idEmpresa)
        {
            return DatosCategoria.ObtenerCategoriasPorEmpresa(idEmpresa);
        }

        public static void GuardarCategoria(Categoria c)
        {
            DatosCategoria.GuardarCategoria(c);
        }

        public static void EliminarCategoria(int id)
        {
            DatosCategoria.EliminarCategoriaYProductosAsociados(id);
        }
    }
}
