using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsWenSoftAdmin.Datos
{
    public class Movimiento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; } // Compra o Venta
        public int IdEmpresa { get; set; }
        public decimal Total { get; set; }
        public List<DetalleMovimiento> Detalles { get; set; } = new();
    }
}
