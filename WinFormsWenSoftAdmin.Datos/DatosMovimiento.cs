using Microsoft.Data.SqlClient;

namespace WinFormsWenSoftAdmin.Datos
{
    public static class DatosMovimiento
    {
        public static int InsertarMovimiento(SqlConnection cn, Movimiento mov)
        {
            string query = @"
                INSERT INTO Movimientos (Fecha, Tipo, IdEmpresa, Total)
                VALUES (@Fecha, @Tipo, @IdEmpresa, @Total);
                SELECT SCOPE_IDENTITY();";

            var parametros = new Dictionary<string, object>
            {
                ["@Fecha"] = mov.Fecha,
                ["@Tipo"] = mov.Tipo,
                ["@IdEmpresa"] = mov.IdEmpresa,
                ["@Total"] = mov.Total
            };

            return Convert.ToInt32(DatosConexion.EjecutarScalar(query, parametros, cn));
        }

        public static List<Movimiento> ObtenerMovimientosPorEmpresa(int idEmpresa)
        {
            var lista = new List<Movimiento>();
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                string query = "SELECT Id, Fecha, Tipo, Total FROM Movimientos WHERE IdEmpresa = @id ORDER BY Fecha DESC";
                var parametros = new Dictionary<string, object> { ["@id"] = idEmpresa };
                cn.Open();

                using (var dr = DatosConexion.EjecutarReader(query, parametros, cn))
                {
                    while (dr.Read())
                    {
                        lista.Add(new Movimiento
                        {
                            Id = (int)dr["Id"],
                            Fecha = (DateTime)dr["Fecha"],
                            Tipo = dr["Tipo"].ToString() ?? string.Empty,
                            Total = (decimal)dr["Total"]
                        });
                    }
                }
            }
            return lista;
        }

        public static Movimiento? ObtenerMovimientoPorId(int idMovimiento)
        {
            using (var cn = Conexion.ObtenerConexion())
            {
                cn.Open();
                Movimiento? mov = null;

                var parametros = new Dictionary<string, object> { ["@id"] = idMovimiento };

                using (var dr = DatosConexion.EjecutarReader("SELECT * FROM Movimientos WHERE Id = @id", parametros, cn))
                {
                    if (dr.Read())
                    {
                        mov = new Movimiento
                        {
                            Id = (int)dr["Id"],
                            Fecha = (DateTime)dr["Fecha"],
                            Tipo = dr["Tipo"].ToString()!,
                            Total = (decimal)dr["Total"],
                            IdEmpresa = (int)dr["IdEmpresa"],
                            Detalles = new List<DetalleMovimiento>()
                        };
                    }
                }

                if (mov != null)
                {
                    using (var dr = DatosConexion.EjecutarReader("SELECT * FROM DetalleMovimiento WHERE IdMovimiento = @id", parametros, cn))
                    {
                        while (dr.Read())
                        {
                            mov.Detalles.Add(new DetalleMovimiento
                            {
                                Id = (int)dr["Id"],
                                IdMovimiento = idMovimiento,
                                IdProducto = (int)dr["IdProducto"],
                                Cantidad = (int)dr["Cantidad"],
                                PrecioUnitario = (decimal)dr["PrecioUnitario"]
                            });
                        }
                    }
                }

                return mov;
            }
        }

        public static void ActualizarMovimiento(Movimiento mov)
        {
            using (var cn = Conexion.ObtenerConexion())
            {
                cn.Open();

                var parametros = new Dictionary<string, object>
                {
                    ["@fecha"] = mov.Fecha,
                    ["@tipo"] = mov.Tipo,
                    ["@total"] = mov.Total,
                    ["@id"] = mov.Id
                };

                string query = @"
                    UPDATE Movimientos SET Fecha = @fecha, Tipo = @tipo, Total = @total
                    WHERE Id = @id";

                DatosConexion.EjecutarNonQuery(query, parametros, cn);

                foreach (var det in mov.Detalles)
                {
                    if (det.Id > 0)
                    {
                        var paramDet = new Dictionary<string, object>
                        {
                            ["@IdDetMov"] = det.Id,
                            ["@IdMovimiento"] = det.IdMovimiento,
                            ["@idProd"] = det.IdProducto,
                            ["@cant"] = det.Cantidad,
                            ["@precio"] = det.PrecioUnitario
                        };

                        string queryDet = @"
                            UPDATE DetalleMovimiento SET IdProducto=@idProd, Cantidad=@cant, PrecioUnitario=@precio, IdMovimiento=@IdMovimiento
                            WHERE IdMovimiento=@IdMovimiento AND Id=@IdDetMov";

                        DatosConexion.EjecutarNonQuery(queryDet, paramDet, cn);
                    }
                    else
                    {
                        det.IdMovimiento = mov.Id;
                        DatosDetalleMovimiento.InsertarDetalle(cn, det);
                    }

                    int delta = mov.Tipo == "Compra" ? det.Cantidad : -det.Cantidad;
                    DatosProducto.ActualizarStock(cn, det.IdProducto, delta);
                }
            }
        }

        public static List<Movimiento> FiltrarMovimientos(int idEmpresa, DateTime? desde, DateTime? hasta, string? tipo)
        {
            var lista = new List<Movimiento>();

            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                var query = @"SELECT Id, Fecha, Tipo, Total FROM Movimientos WHERE IdEmpresa = @empresa";
                var parametros = new Dictionary<string, object> { ["@empresa"] = idEmpresa };

                if (desde.HasValue)
                {
                    query += " AND Fecha >= @desde";
                    parametros["@desde"] = desde.Value.Date;
                }
                if (hasta.HasValue)
                {
                    query += " AND Fecha <= @hasta";
                    parametros["@hasta"] = hasta.Value.Date;
                }
                if (!string.IsNullOrEmpty(tipo) && tipo != "Todos")
                {
                    query += " AND Tipo = @tipo";
                    parametros["@tipo"] = tipo;
                }

                query += " ORDER BY Fecha DESC";

                cn.Open();
                using (var dr = DatosConexion.EjecutarReader(query, parametros, cn))
                {
                    while (dr.Read())
                    {
                        lista.Add(new Movimiento
                        {
                            Id = (int)dr["Id"],
                            Fecha = (DateTime)dr["Fecha"],
                            Tipo = dr["Tipo"].ToString()!,
                            Total = (decimal)dr["Total"]
                        });
                    }
                }
            }

            return lista;
        }

        public static void EliminarMovimiento(int idMovimiento)
        {
            using (var cn = Conexion.ObtenerConexion())
            {
                cn.Open();

                try
                {
                    var detalles = new List<(int IdProducto, int Cantidad)>();
                    var parametros = new Dictionary<string, object> { ["@id"] = idMovimiento };

                    using (var dr = DatosConexion.EjecutarReader("SELECT IdProducto, Cantidad FROM DetalleMovimiento WHERE IdMovimiento = @id", parametros, cn))
                    {
                        while (dr.Read())
                        {
                            detalles.Add(((int)dr["IdProducto"], (int)dr["Cantidad"]));
                        }
                    }

                    foreach (var detalle in detalles)
                    {
                        DatosProducto.ActualizarStock(cn, detalle.IdProducto, detalle.Cantidad);
                    }

                    DatosDetalleMovimiento.EliminarDetalles(cn, idMovimiento);
                    DatosConexion.EjecutarNonQuery("DELETE FROM Movimientos WHERE Id = @id", parametros, cn);
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
