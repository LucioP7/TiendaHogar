using Service.Enums;
using System;
using System.Collections.Generic;

namespace Service.Models;

public partial class Proveedor
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string Direccion { get; set; } = string.Empty;

    public string Telefonos { get; set; } = string.Empty;

    public string Cuit { get; set; } = string.Empty;

    public CondicionIvaEnum CondicionIva { get; set; }

    public int? LocalidadId { get; set; }

    public virtual Localidad? Localidad { get; set; }
    public bool Eliminado { get; set; } = false;

    public string toString()
    {
        return Nombre;
    }

}
