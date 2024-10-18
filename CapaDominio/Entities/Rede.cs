using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaInfraestructura.CapaDominio.Entities;

public partial class Rede
{
    [Key]
    public int IdRed { get; set; }

    public string NombreRed { get; set; } = null!;

    public string DescripcionRed { get; set; } = null!;

    [InverseProperty("RedIdRedNavigation")]
    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
