using Microsoft.Data.SqlClient;
using WinFormsWenSoftAdmin.Entidades;

namespace WinFormsWenSoftAdmin.Datos
{
    public static class DatosHistoricoProducto
    {
        public static void RegistrarMovimiento(HistoricoProducto historico)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();

                string query = @"
                    INSERT INTO HistoricoProducto (IdProducto, Fecha, TipoMovimiento, IdUsuario, Descripcion)
                    VALUES (@idProducto, @fecha, @tipo, @idUsuario, @descripcion)";

                var parametros = new Dictionary<string, object>
                {
                    { "@idProducto", historico.IdProducto },
                    { "@fecha", historico.Fecha },
                    { "@tipo", historico.TipoMovimiento },
                    { "@idUsuario", historico.IdUsuario },
                    { "@descripcion", historico.Descripcion }
                };

                DatosConexion.EjecutarNonQuery(query, parametros, cn);
            }
        }
    }
}

