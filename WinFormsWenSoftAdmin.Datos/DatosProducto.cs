using Microsoft.Data.SqlClient;
using WinFormsWenSoftAdmin.Entidades;

namespace WinFormsWenSoftAdmin.Datos
{
    public static class DatosProducto
    {
        public static void ActualizarStock(SqlConnection cn, int idProducto, int delta)
        {
            string query = @"
                UPDATE Productos
                SET Stock = Stock + @DeltaStock
                WHERE Id = @IdProducto";

            var parametros = new Dictionary<string, object>
            {
                { "@DeltaStock", delta },
                { "@IdProducto", idProducto }
            };

            DatosConexion.EjecutarNonQuery(query, parametros, cn); // Usa sobrecarga con conexión abierta
        }

        public static List<Producto> ObtenerPorEmpresa(int idEmpresa)
        {
            var lista = new List<Producto>();

            string query = @"
                SELECT p.Id, p.Nombre, p.PrecioVenta, p.PrecioBase, p.Stock, 
                       p.Activo, p.IdCategoria, c.Nombre AS NombreCategoria
                FROM Productos p
                INNER JOIN Categorias c ON p.IdCategoria = c.Id
                WHERE c.IdEmpresa = @id";

            var parametros = new Dictionary<string, object>
            {
                { "@id", idEmpresa }
            };

            using (var cn = DatosConexion.ObtenerConexion())
            {
                cn.Open();
                using (var dr = DatosConexion.EjecutarReader(query, parametros, cn))
                {
                    while (dr.Read())
                    {
                        lista.Add(new Producto
                        {
                            Id = (int)dr["Id"],
                            Nombre = dr["Nombre"].ToString()!,
                            PrecioBase = (decimal)dr["PrecioBase"],
                            PrecioVenta = (decimal)dr["PrecioVenta"],
                            Stock = (int)dr["Stock"],
                            Activo = Convert.ToBoolean(dr["Activo"]),
                            IdCategoria = (int)dr["IdCategoria"],
                            NombreCategoria = dr["NombreCategoria"].ToString()!
                        });
                    }
                }
            }

            return lista;
        }

        public static void ActualizarProducto(Producto p)
        {
            string query = @"
                UPDATE Productos
                SET Nombre = @nombre,
                    PrecioBase = @precioBase,
                    PrecioVenta = @precioVenta,
                    Stock = @stock,
                    Activo = @activo,
                    IdCategoria = @idCategoria
                WHERE Id = @id";

            var parametros = new Dictionary<string, object>
            {
                { "@nombre", p.Nombre },
                { "@precioBase", p.PrecioBase },
                { "@precioVenta", p.PrecioVenta },
                { "@stock", p.Stock },
                { "@activo", p.Activo },
                { "@id", p.Id },
                { "@idCategoria", p.IdCategoria }
            };

            DatosConexion.EjecutarNonQuery(query, parametros);
        }

        public static void InsertarProducto(Producto p)
        {
            string query = @"
                INSERT INTO Productos (Nombre, PrecioBase, PrecioVenta, Stock, Activo, IdCategoria)
                VALUES (@nombre, @precioBase, @precioVenta, @stock, @activo, @idCategoria);";

            var parametros = new Dictionary<string, object>
            {
                { "@nombre", p.Nombre },
                { "@precioBase", p.PrecioBase },
                { "@precioVenta", p.PrecioVenta },
                { "@stock", p.Stock },
                { "@activo", p.Activo },
                { "@idCategoria", p.IdCategoria }
            };

            DatosConexion.EjecutarNonQuery(query, parametros);
        }

        public static void EliminarProducto(int idProducto)
        {
            string query = "DELETE FROM Productos WHERE Id = @id";
            var parametros = new Dictionary<string, object>
            {
                { "@id", idProducto }
            };

            DatosConexion.EjecutarNonQuery(query, parametros);
        }

        public static bool ProductoTieneMovimientos(int idProducto)
        {
            string query1 = "SELECT COUNT(*) FROM DetalleMovimiento WHERE IdProducto = @id";
            string query2 = "SELECT COUNT(*) FROM HistoricoProducto WHERE IdProducto = @id";

            var parametros = new Dictionary<string, object>
            {
                { "@id", idProducto }
            };

            using (var cn = DatosConexion.ObtenerConexion())
            {
                cn.Open();
                int count1 = Convert.ToInt32(DatosConexion.EjecutarScalar(query1, parametros, cn));
                int count2 = Convert.ToInt32(DatosConexion.EjecutarScalar(query2, parametros, cn));

                return (count1 + count2) > 0;
            }
        }

        public static List<Producto> ObtenerPorCategoria(int idEmpresa, int idCategoria)
        {
            var lista = new List<Producto>();

            string query = @"
                SELECT Id, Nombre, PrecioBase, PrecioVenta, Stock, Activo
                FROM Productos
                WHERE IdCategoria = @categoria AND IdCategoria IN (
                    SELECT Id FROM Categorias WHERE IdEmpresa = @empresa
                )";

            var parametros = new Dictionary<string, object>
            {
                { "@categoria", idCategoria },
                { "@empresa", idEmpresa }
            };

            using (var cn = DatosConexion.ObtenerConexion())
            {
                cn.Open();
                using (var dr = DatosConexion.EjecutarReader(query, parametros, cn))
                {
                    while (dr.Read())
                    {
                        lista.Add(new Producto
                        {
                            Id = (int)dr["Id"],
                            Nombre = dr["Nombre"].ToString()!,
                            PrecioBase = (decimal)dr["PrecioBase"],
                            PrecioVenta = (decimal)dr["PrecioVenta"],
                            Stock = (int)dr["Stock"],
                            Activo = (bool)dr["Activo"],
                            IdCategoria = idCategoria
                        });
                    }
                }
            }

            return lista;
        }
    }
}
