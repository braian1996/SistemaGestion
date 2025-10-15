using Microsoft.Data.SqlClient;
using System.Data;
using WinFormsWenSoftAdmin.Entidades;

namespace WinFormsWenSoftAdmin.Datos
{
    public static class DatosDetalleMovimiento
    {
        public static DetalleMovimiento ObtenerDetallePorId(SqlConnection cn, int idDetalleMovimiento)
        {
            var query = @"
            SELECT Id, IdMovimiento, IdProducto, Cantidad, PrecioUnitario
            FROM DetalleMovimiento
            WHERE Id = @Id";

            var parametros = new Dictionary<string, object>
            {
                { "@Id", idDetalleMovimiento }
            };

            using var reader = DatosConexion.EjecutarReader(query, parametros, cn);
            if (reader.Read())
            {
                return new DetalleMovimiento
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    IdMovimiento = Convert.ToInt32(reader["IdMovimiento"]),
                    IdProducto = Convert.ToInt32(reader["IdProducto"]),
                    Cantidad = Convert.ToInt32(reader["Cantidad"]),
                    PrecioUnitario = Convert.ToDecimal(reader["PrecioUnitario"])
                };
            }

            return null!;
        }

        public static void InsertarDetalle(SqlConnection cn, DetalleMovimiento det)
        {
            var query = @"
                INSERT INTO DetalleMovimiento (IdMovimiento, IdProducto, Cantidad, PrecioUnitario)
                VALUES (@IdMovimiento, @IdProducto, @Cantidad, @PrecioUnitario);";

            var parametros = new Dictionary<string, object>
            {
                { "@IdMovimiento", det.IdMovimiento },
                { "@IdProducto", det.IdProducto },
                { "@Cantidad", det.Cantidad },
                { "@PrecioUnitario", det.PrecioUnitario }
            };

            DatosConexion.EjecutarNonQuery(query, parametros, cn);
        }

        public static void EliminarDetalles(SqlConnection cn, int idMovimiento)
        {
            var query = "DELETE FROM DetalleMovimiento WHERE IdMovimiento = @id";

            var parametros = new Dictionary<string, object>
            {
                { "@id", idMovimiento }
            };

            DatosConexion.EjecutarNonQuery(query, parametros, cn);
        }

        public static void EliminarRenglonDetalle(SqlConnection cn, int idDetalleMovimiento)
        {
            var detalleMovimiento = ObtenerDetallePorId(cn, idDetalleMovimiento);
            DatosProducto.ActualizarStock(cn, detalleMovimiento.IdProducto, detalleMovimiento.Cantidad);

            var query = "DELETE FROM DetalleMovimiento WHERE Id = @id";
            var parametros = new Dictionary<string, object>
            {
                { "@id", detalleMovimiento.Id }
            };

            DatosConexion.EjecutarNonQuery(query, parametros, cn);
        }
    }
}
