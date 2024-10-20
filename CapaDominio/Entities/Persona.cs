using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaInfraestructura.CapaDominio.Entities;

public partial class Persona
{
    [Key]
    public int IdPersona { get; set; }

    [Required(ErrorMessage = "El nombre es requerido"), MinLength(3, ErrorMessage = "El nombre debe contener al menos 3 caracteres")]
    public string NombrePersona { get; set; }

    [Required(ErrorMessage = "El correo es requerido"), MinLength(3, ErrorMessage = "El correo debe contener al menos 3 caracteres")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "El Telefono es requerido"), MinLength(8, ErrorMessage = "El Telefono debe contener al menos 8 caracteres")]
    public string? Telefono { get; set; } = null!;

    [Required(ErrorMessage = "El nivel de liderazgo es requerido")]
    public int NivelLiderazgoIdNivelLiderazgo { get; set; }

    public int? RedIdRed { get; set; }

    [ForeignKey("NivelLiderazgoIdNivelLiderazgo")]
    [InverseProperty("Personas")]
    public virtual NivelesLiderazgo? NivelLiderazgoIdNivelLiderazgoNavigation { get; set; }

    [ForeignKey("RedIdRed")]
    [InverseProperty("Personas")]
    public virtual Rede? RedIdRedNavigation { get; set; }

    [InverseProperty("PersonaIdPersonaNavigation")]
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
