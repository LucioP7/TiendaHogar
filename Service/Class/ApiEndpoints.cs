using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Class
{
    public static class ApiEndpoints
    {
        public static string Cliente { get; set; } = "clientes";
        public static string Compra { get; set; } = "compras";
        public static string DetalleCompra { get; set; } = "detallescompras";
        public static string DetalleVenta { get; set; } = "detallesventas";
        public static string Localidad { get; set; } = "localidades";
        public static string Producto { get; set; } = "productos";
        public static string Proveedor { get; set; } = "proveedores";
        public static string Venta { get; set; } = "ventas";
        public static string Categoria { get; set; } = "categorias";
        public static string Marca { get; set; } = "marcas";



        public static string GetEndpoint(string name)
        {
            return name switch
            {
                nameof(Cliente) => Cliente,
                nameof(Compra) => Compra,
                nameof(DetalleCompra) => DetalleCompra,
                nameof(DetalleVenta) => DetalleVenta,
                nameof(Localidad) => Localidad,
                nameof(Producto) => Producto,
                nameof(Proveedor) => Proveedor,
                nameof(Venta) => Venta,
                nameof(Categoria) => Categoria,
                nameof(Marca) => Marca,
                _ => throw new ArgumentException($"Endpoint '{name}' no está definido.")
            };
        }
    }
}
