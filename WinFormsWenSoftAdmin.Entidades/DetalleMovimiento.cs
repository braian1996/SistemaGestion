using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsWenSoftAdmin.Datos
{
    public class DetalleMovimiento
    {
        public int Id { get; set; }
        public int IdMovimiento { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
