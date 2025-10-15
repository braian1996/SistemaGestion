using Microsoft.Data.SqlClient;
using WinFormsWenSoftAdmin.Entidades;

namespace WinFormsWenSoftAdmin.Datos
{
    public class DatosUsuario
    {
        public static Usuario? Login(string usuario, string claveHash, int idEmpresa)
        {
            string query = @"SELECT u.Id, u.Usuario, u.IdEmpresa, u.IdRol, r.Nombre AS RolNombre
                             FROM Usuarios u
                             JOIN Roles r ON u.IdRol = r.Id
                             WHERE u.Usuario = @usuario AND u.Clave = @clave AND u.IdEmpresa = @idEmpresa";

            var parametros = new Dictionary<string, object>
            {
                { "@usuario", usuario },
                { "@clave", claveHash },
                { "@idEmpresa", idEmpresa }
            };

            using (SqlConnection cn = DatosConexion.ObtenerConexion())
            {
                cn.Open();
                using (var dr = DatosConexion.EjecutarReader(query, parametros, cn))
                {
                    if (dr.Read())
                    {
                        return new Usuario
                        {
                            Id = (int)dr["Id"],
                            UsuarioNombre = dr["Usuario"].ToString(),
                            IdEmpresa = (int)dr["IdEmpresa"],
                            IdRol = (int)dr["IdRol"],
                            RolNombre = dr["RolNombre"].ToString()
                        };
                    }
                }
            }

            return null;
        }

        public static List<Usuario> ObtenerUsuarios(int idEmpresa, int idRol)
        {
            var lista = new List<Usuario>();

            string query = @"SELECT u.Id, u.Usuario, u.Clave, u.IdEmpresa, e.Nombre AS EmpresaNombre, 
                                    u.IdRol, r.Nombre AS RolNombre
                             FROM Usuarios u
                             JOIN Roles r ON u.IdRol = r.Id
                             JOIN Empresas e ON u.IdEmpresa = e.Id";

            var parametros = new Dictionary<string, object>();
            if (idRol != 3)
            {
                query += " WHERE u.IdEmpresa = @idEmpresa";
                parametros.Add("@idEmpresa", idEmpresa);
            }

            using (SqlConnection cn = DatosConexion.ObtenerConexion())
            {
                cn.Open();
                using (var dr = DatosConexion.EjecutarReader(query, parametros, cn))
                {
                    while (dr.Read())
                    {
                        lista.Add(new Usuario
                        {
                            Id = (int)dr["Id"],
                            UsuarioNombre = dr["Usuario"].ToString()!,
                            Clave = dr["Clave"].ToString()!,
                            IdEmpresa = (int)dr["IdEmpresa"],
                            EmpresaNombre = dr["EmpresaNombre"].ToString()!,
                            IdRol = (int)dr["IdRol"],
                            RolNombre = dr["RolNombre"].ToString()!
                        });
                    }
                }
            }

            return lista;
        }

        public static void GuardarUsuario(Usuario usuario)
        {
            string query;
            var parametros = new Dictionary<string, object>
            {
                { "@usuario", usuario.UsuarioNombre! },
                { "@clave", usuario.Clave! },
                { "@empresa", usuario.IdEmpresa },
                { "@rol", usuario.IdRol }
            };

            if (usuario.Id > 0)
            {
                query = @"UPDATE Usuarios
                          SET Usuario = @usuario,
                              Clave = @clave,
                              IdEmpresa = @empresa,
                              IdRol = @rol
                          WHERE Id = @id";
                parametros.Add("@id", usuario.Id);
            }
            else
            {
                query = @"INSERT INTO Usuarios (Usuario, Clave, IdEmpresa, IdRol)
                          VALUES (@usuario, @clave, @empresa, @rol)";
            }

            DatosConexion.EjecutarNonQuery(query, parametros);
        }

        public static bool ExisteUsuarioDuplicado(Usuario usuario)
        {
            string query = @"SELECT COUNT(*) FROM Usuarios
                             WHERE Usuario = @usuario AND Clave = @clave AND IdEmpresa = @empresa";

            var parametros = new Dictionary<string, object>
            {
                { "@usuario", usuario.UsuarioNombre! },
                { "@clave", usuario.Clave! },
                { "@empresa", usuario.IdEmpresa }
            };

            if (usuario.Id > 0)
            {
                query += " AND Id <> @id";
                parametros.Add("@id", usuario.Id);
            }

            var resultado = DatosConexion.EjecutarScalar(query, parametros);
            return Convert.ToInt32(resultado) > 0;
        }
    }
}

