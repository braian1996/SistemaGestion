using System;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace WinFormsWenSoftAdmin.Datos
{
    public class Conexion
    {
        public static SqlConnection ObtenerConexion()
        {
            try
            {
                string cadena = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                return new SqlConnection(cadena);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la cadena de conexión.", ex);
            }
        }
    }
}