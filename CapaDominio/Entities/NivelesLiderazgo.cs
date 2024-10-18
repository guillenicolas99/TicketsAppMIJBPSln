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

    public string NombreNivel { get; set; } = null!;

    public string DescripcionNivel { get; set; } = null!;

    [InverseProperty("NivelLiderazgoIdNivelLiderazgoNavigation")]
    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
