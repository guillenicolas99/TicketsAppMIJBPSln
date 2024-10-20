using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaInfraestructura.CapaDominio.Entities;

public partial class Rede
{
    [Key]
    public int IdRed { get; set; }

    [Required(ErrorMessage = "El nombre es requerido"), MinLength(3, ErrorMessage = "El nombre debe contener al menos 3 caracteres")]
    public string NombreRed { get; set; }

    [Required(ErrorMessage = "La descripción es requerida"), MinLength(3, ErrorMessage = "La descripción debe contener al menos 3 caracteres")]
    public string DescripcionRed { get; set; }

    [InverseProperty("RedIdRedNavigation")]
    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
