using Microsoft.Data.SqlClient;
using WinFormsWenSoftAdmin.Entidades;

namespace WinFormsWenSoftAdmin.Datos
{
    public class DatosEmpresa
    {
        public static List<Empresa> GetEmpresas()
        {
            var lista = new List<Empresa>();
            string query = "SELECT Id, Nombre FROM Empresas";

            using (SqlConnection cn = DatosConexion.ObtenerConexion())
            {
                cn.Open();
                using (var dr = DatosConexion.EjecutarReader(query, new Dictionary<string, object>(), cn))
                {
                    while (dr.Read())
                    {
                        lista.Add(new Empresa
                        {
                            Id = (int)dr["Id"],
                            Nombre = dr["Nombre"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public static List<Empresa> GetPorUsuario(int idUsuario)
        {
            var lista = new List<Empresa>();
            string query = @"
                SELECT E.* FROM Empresas E
                INNER JOIN Usuarios U ON U.IdEmpresa = E.Id
                WHERE U.Id = @id";

            var parametros = new Dictionary<string, object>
            {
                { "@id", idUsuario }
            };

            using (SqlConnection cn = DatosConexion.ObtenerConexion())
            {
                cn.Open();
                using (var dr = DatosConexion.EjecutarReader(query, parametros, cn))
                {
                    while (dr.Read())
                    {
                        lista.Add(new Empresa
                        {
                            Id = (int)dr["Id"],
                            Nombre = dr["Nombre"].ToString()!
                        });
                    }
                }
            }

            return lista;
        }

        public static void Guardar(Empresa e)
        {
            string query = @"
                IF EXISTS (SELECT 1 FROM Empresas WHERE Id = @id)
                    UPDATE Empresas SET Nombre = @nombre WHERE Id = @id
                ELSE
                    INSERT INTO Empresas (Nombre)
                    VALUES (@nombre)";

            var parametros = new Dictionary<string, object>
            {
                { "@id", e.Id },
                { "@nombre", e.Nombre! }
            };

            DatosConexion.EjecutarNonQuery(query, parametros);
        }

        public static void Eliminar(int id)
        {
            string query = "DELETE FROM Empresas WHERE Id = @id";
            var parametros = new Dictionary<string, object>
            {
                { "@id", id }
            };

            DatosConexion.EjecutarNonQuery(query, parametros);
        }

        public static string EmpresaTieneDependencias(int idEmpresa)
        {
            using (SqlConnection cn = DatosConexion.ObtenerConexion())
            {
                cn.Open();
                var dependencias = new List<string>();
                string query;
                Dictionary<string, object> parametros = new() { { "@id", idEmpresa } };

                // Categorias
                query = "SELECT COUNT(*) FROM Categorias WHERE IdEmpresa = @id";
                if (Convert.ToInt32(DatosConexion.EjecutarScalar(query, parametros)) > 0)
                    dependencias.Add("categorias");

                // Movimientos
                query = "SELECT COUNT(*) FROM Movimientos WHERE IdEmpresa = @id";
                if (Convert.ToInt32(DatosConexion.EjecutarScalar(query, parametros)) > 0)
                    dependencias.Add("movimientos");

                // Usuarios
                query = "SELECT COUNT(*) FROM Usuarios WHERE IdEmpresa = @id";
                if (Convert.ToInt32(DatosConexion.EjecutarScalar(query, parametros)) > 0)
                    dependencias.Add("usuarios");

                return dependencias.Any()
                    ? $"La empresa tiene {string.Join(", ", dependencias)} asociados."
                    : "";
            }
        }
    }
}
