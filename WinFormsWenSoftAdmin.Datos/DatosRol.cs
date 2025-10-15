using Microsoft.Data.SqlClient;
using WinFormsWenSoftAdmin.Entidades;

namespace WinFormsWenSoftAdmin.Datos
{
    public static class DatosRol
    {
        public static List<Rol> ObtenerRoles()
        {
            var lista = new List<Rol>();
            string query = "SELECT Id, Nombre FROM Roles";

            using (SqlConnection cn = DatosConexion.ObtenerConexion())
            {
                cn.Open();
                using (var dr = DatosConexion.EjecutarReader(query, new Dictionary<string, object>(), cn))
                {
                    while (dr.Read())
                    {
                        lista.Add(new Rol
                        {
                            Id = (int)dr["Id"],
                            Nombre = dr["Nombre"].ToString()!
                        });
                    }
                }
            }

            return lista;
        }
    }
}
