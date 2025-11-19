using System;
using System.Collections.Generic;

namespace Service.Models;

public partial class DetalleCompra
{
    public int Id { get; set; }

    public int ProductoId { get; set; }

    public decimal PrecioUnitario { get; set; }

    public int Cantidad { get; set; }

    public int CompraId { get; set; }
    public Compra? Compra { get; set; }

    public Producto? Producto { get; set; }

    public decimal Subtotal => Cantidad * PrecioUnitario;

    public bool Eliminado { get; set; } = false;

}
