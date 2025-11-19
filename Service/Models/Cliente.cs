using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Service.Models;

public partial class Cliente
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El campo Dni es obligatorio.")]
    public string Dni { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "El campo Dirección es obligatorio.")]
    public string Direccion { get; set; } = string.Empty;

    public string Telefono { get; set; } = string.Empty;

    [Required(ErrorMessage = "Debe seleccionar una localidad.")]
    public int? LocalidadId { get; set; }

    public virtual Localidad? Localidad { get; set; }

    public bool Eliminado { get; set; } = false;
    
    public override string ToString()
    {
        return Nombre;
    }

}
