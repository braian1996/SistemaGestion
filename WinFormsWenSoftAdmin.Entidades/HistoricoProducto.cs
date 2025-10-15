using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsWenSoftAdmin.Entidades
{
    public class HistoricoProducto
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoMovimiento { get; set; } = "";
        public int IdUsuario { get; set; }
        public string Descripcion { get; set; } = "";
    }
}
