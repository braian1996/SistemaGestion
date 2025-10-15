using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsWenSoftAdmin.Datos;

namespace WinFormsWenSoftAdmin.Negocio
{
    public static class NegocioDetallesMovimiento
    {
        public static DetalleMovimiento ObtenerRenglonDetalleById(SqlConnection cn,int idDetalleMovimiento)
        {
            return DatosDetalleMovimiento.ObtenerDetallePorId(cn, idDetalleMovimiento);
        }
        public static void EliminarRenglonDetalle(SqlConnection cn, int idDetalleMovimiento)
        {
            DatosDetalleMovimiento.EliminarRenglonDetalle(cn, idDetalleMovimiento);

            //var detalleMovimiento_Historicoproducto = ObtenerRenglonDetalleById(cn, idDetalleMovimiento);
            //NegocioHistoricoProducto.GuardarHistorico(detalleMovimiento_Historicoproducto.IdProducto, "D", SesionActual.IdUsuario, "Eliminacion del producto y aumenta el Stock");
        }
    }
}
