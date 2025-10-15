using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsWenSoftAdmin.Datos;

public static class NegocioProducto
{
    public static List<Producto> GetProductosPorEmpresa(int idEmpresa)
    {
        return DatosProducto.ObtenerPorEmpresa(idEmpresa);
    }
    public static void GuardarProducto(Producto p)
    {
        if (p.Id == 0)
        {
            DatosProducto.InsertarProducto(p);
        }
        else
        {
            DatosProducto.ActualizarProducto(p);
        }
    }

    public static List<Producto> GetProductosPorCategoria(int idEmpresa, int idCategoria)
    {
        return DatosProducto.ObtenerPorCategoria(idEmpresa, idCategoria);
    }

    public static void AplicarPorcentajeAGrilla(List<Producto> productos, decimal porcentaje)
    {
        foreach (var p in productos)
        {
            p.PorcentajeGanancia = porcentaje;
            p.PrecioVenta = p.PrecioVenta == 0 ? p.PrecioVenta = p.PrecioBase : p.PrecioVenta = p.CalcularPrecioVenta();
        }
    }
    public static void EliminarProducto(int idProducto)
    {
        if (DatosProducto.ProductoTieneMovimientos(idProducto))
            throw new Exception("No se puede eliminar el producto. Tiene movimientos asociados.");
        DatosProducto.EliminarProducto(idProducto);
    }
}
