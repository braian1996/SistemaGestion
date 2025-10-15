using Microsoft.Data.SqlClient;
using WinFormsWenSoftAdmin.Entidades;

namespace WinFormsWenSoftAdmin.Datos
{
    public static class DatosCategoria
    {
        public static List<Categoria> ObtenerCategoriasPorEmpresa(int idEmpresa)
        {
            var lista = new List<Categoria>();

            string query = "SELECT Id, Nombre, IdEmpresa FROM Categorias WHERE IdEmpresa = @id";
            var parametros = new Dictionary<string, object>
            {
                { "@id", idEmpresa }
            };

            using (SqlConnection cn = DatosConexion.ObtenerConexion())
            {
                cn.Open();
                using (var dr = DatosConexion.EjecutarReader(query, parametros, cn))
                {
                    while (dr.Read())
                    {
                        lista.Add(new Categoria
                        {
                            Id = (int)dr["Id"],
                            Nombre = dr["Nombre"].ToString()!,
                            IdEmpresa = (int)dr["IdEmpresa"]
                        });
                    }
                }
            }

            return lista;
        }

        public static void GuardarCategoria(Categoria c)
        {
            string query;
            var parametros = new Dictionary<string, object>
            {
                { "@nombre", c.Nombre },
                { "@idEmpresa", c.IdEmpresa }
            };

            if (c.Id == 0)
            {
                query = "INSERT INTO Categorias (Nombre, IdEmpresa) VALUES (@nombre, @idEmpresa)";
            }
            else
            {
                query = "UPDATE Categorias SET Nombre = @nombre WHERE Id = @id";
                parametros.Add("@id", c.Id);
            }

            DatosConexion.EjecutarNonQuery(query, parametros);
        }

        public static void EliminarCategoriaYProductosAsociados(int idCategoria)
        {
            using (SqlConnection cn = DatosConexion.ObtenerConexion())
            {
                cn.Open();

                string queryCheck = @"
                    SELECT COUNT(*)
                    FROM DetalleMovimiento dm
                    INNER JOIN Productos p ON dm.IdProducto = p.Id
                    WHERE p.IdCategoria = @id";

                var parametrosCheck = new Dictionary<string, object>
                {
                    { "@id", idCategoria }
                };

                var count = Convert.ToInt32(DatosConexion.EjecutarScalar(queryCheck, parametrosCheck));
                if (count > 0)
                {
                    throw new InvalidOperationException("No se puede eliminar la categoría porque existen movimientos asociados a sus productos.");
                }

                string queryDeleteProductos = "DELETE FROM Productos WHERE IdCategoria = @id";
                DatosConexion.EjecutarNonQuery(queryDeleteProductos, parametrosCheck);

                string queryDeleteCategoria = "DELETE FROM Categorias WHERE Id = @id";
                DatosConexion.EjecutarNonQuery(queryDeleteCategoria, parametrosCheck);
            }
        }
    }
}
