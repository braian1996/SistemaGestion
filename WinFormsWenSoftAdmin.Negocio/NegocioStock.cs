using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsWenSoftAdmin.Datos;

namespace WinFormsWenSoftAdmin.Negocio
{
    public static class NegocioStock
    {
        public static void RegistrarMovimiento(Movimiento mov)
        {
            using (var cn = Conexion.ObtenerConexion())
            {
                cn.Open();
                try
                {
                    int idMovimiento = DatosMovimiento.InsertarMovimiento(cn, mov);

                    foreach (var det in mov.Detalles)
                    {
                        det.IdMovimiento = idMovimiento;
                        DatosDetalleMovimiento.InsertarDetalle(cn, det);

                        int delta = mov.Tipo == "Compra" ? det.Cantidad : -det.Cantidad;
                        DatosProducto.ActualizarStock(cn, det.IdProducto, delta);
                    }

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
