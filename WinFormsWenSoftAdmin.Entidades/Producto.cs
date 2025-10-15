using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsWenSoftAdmin.Datos
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioBase { get; set; }
        public int Stock { get; set; }
        public bool Activo { get; set; }
        public int IdCategoria { get; set; }

        public string NombreCategoria { get; set; }
        public bool Seleccionado { get; set; }
        public decimal PorcentajeGanancia { get; set; }

        public decimal CalcularPrecioVenta()
        {
            return Math.Round(PrecioBase + (PrecioBase * (PorcentajeGanancia / 100)), 2);
        }
    }
}
