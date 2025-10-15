using Microsoft.Data.SqlClient;

namespace WinFormsWenSoftAdmin.Datos
{
    public static class DatosConexion
    {
        public static SqlConnection ObtenerConexion()
        {
            return Conexion.ObtenerConexion();
        }

        public static int EjecutarNonQuery(string query, Dictionary<string, object> parametros, SqlConnection cn)
        {
            using (var cmd = new SqlCommand(query, cn))
            {
                AgregarParametros(cmd, parametros);
                return cmd.ExecuteNonQuery();
            }
        }

        public static int EjecutarNonQuery(string query, Dictionary<string, object> parametros)
        {
            using (var cn = ObtenerConexion())
            {
                cn.Open();
                return EjecutarNonQuery(query, parametros, cn);
            }
        }

        public static object? EjecutarScalar(string query, Dictionary<string, object> parametros, SqlConnection cn)
        {
            using (var cmd = new SqlCommand(query, cn))
            {
                AgregarParametros(cmd, parametros);
                return cmd.ExecuteScalar();
            }
        }

        public static object? EjecutarScalar(string query, Dictionary<string, object> parametros)
        {
            using (var cn = ObtenerConexion())
            {
                cn.Open();
                return EjecutarScalar(query, parametros, cn);
            }
        }

        public static SqlDataReader EjecutarReader(string query, Dictionary<string, object> parametros, SqlConnection cn)
        {
            var cmd = new SqlCommand(query, cn);
            AgregarParametros(cmd, parametros);
            return cmd.ExecuteReader(); // El lector y la conexión deben cerrarse por quien lo use
        }

        public static SqlDataReader EjecutarReader(string query, Dictionary<string, object> parametros)
        {
            var cn = ObtenerConexion();
            cn.Open();
            var cmd = new SqlCommand(query, cn);
            AgregarParametros(cmd, parametros);
            return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }

        private static void AgregarParametros(SqlCommand cmd, Dictionary<string, object> parametros)
        {
            if (parametros == null) return;

            foreach (var param in parametros)
            {
                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
            }
        }
    }
}
