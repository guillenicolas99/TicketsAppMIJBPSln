using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaInfraestructura.CapaDominio.Entities;

public partial class Persona
{
    [Key]
    public int IdPersona { get; set; }

    public string NombrePersona { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public int NivelLiderazgoIdNivelLiderazgo { get; set; }

    public int RedIdRed { get; set; }

    [ForeignKey("NivelLiderazgoIdNivelLiderazgo")]
    [InverseProperty("Personas")]
    public virtual NivelesLiderazgo NivelLiderazgoIdNivelLiderazgoNavigation { get; set; } = null!;

    [ForeignKey("RedIdRed")]
    [InverseProperty("Personas")]
    public virtual Rede RedIdRedNavigation { get; set; } = null!;

    [InverseProperty("PersonaIdPersonaNavigation")]
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
