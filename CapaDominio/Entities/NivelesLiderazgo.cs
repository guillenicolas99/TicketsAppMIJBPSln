using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaInfraestructura.CapaDominio.Entities;

[Table("NivelesLiderazgo")]
public partial class NivelesLiderazgo
{
    [Key]
    public int IdNivelLiderazgo { get; set; }

    [Required(ErrorMessage = "El nombre es requerido"), MinLength(3, ErrorMessage = "El nombre debe contener al menos 3 caracteres")]
    public string NombreNivel { get; set; } = null!;

    [Required(ErrorMessage = "La descripción es requerida"), MinLength(3, ErrorMessage = "La descripción debe contener al menos 3 caracteres")]
    public string DescripcionNivel { get; set; } = null!;

    [InverseProperty("NivelLiderazgoIdNivelLiderazgoNavigation")]
    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
