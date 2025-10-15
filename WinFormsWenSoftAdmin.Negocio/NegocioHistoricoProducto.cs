using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsWenSoftAdmin.Datos;
using WinFormsWenSoftAdmin.Entidades;

namespace WinFormsWenSoftAdmin.Negocio
{
    public static class NegocioHistoricoProducto
    {
        public static void GuardarHistorico(int idProducto, string tipoMovimiento, int idUsuario, string descripcion)
        {
            var historico = new HistoricoProducto
            {
                IdProducto = idProducto,
                Fecha = DateTime.Now,
                TipoMovimiento = tipoMovimiento,
                IdUsuario = idUsuario,
                Descripcion = descripcion
            };

            DatosHistoricoProducto.RegistrarMovimiento(historico);
        }
    }
}
