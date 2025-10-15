using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsWenSoftAdmin.Datos;
using WinFormsWenSoftAdmin.Entidades;

namespace WinFormsWenSoftAdmin.Negocio
{
    public static class NegocioMovimiento
    {
        public static List<Movimiento> GetMovimientosPorEmpresa(int idEmpresa)
        {
            return DatosMovimiento.ObtenerMovimientosPorEmpresa(idEmpresa);
        }
        public static Movimiento? ObtenerMovimientoPorId(int idMovimiento)
        {
            return DatosMovimiento.ObtenerMovimientoPorId(idMovimiento);
        }
        public static void ActualizarMovimiento(Movimiento mov)
        {
            DatosMovimiento.ActualizarMovimiento(mov);
        }
        public static List<Movimiento> FiltrarMovimientos(int idEmpresa, DateTime? desde, DateTime? hasta, string? tipo)
        {
            return DatosMovimiento.FiltrarMovimientos(idEmpresa, desde, hasta, tipo);
        }
        public static void EliminarMovimiento(int idMovimiento)
        {           
            DatosMovimiento.EliminarMovimiento(idMovimiento);
        }
    }
}
