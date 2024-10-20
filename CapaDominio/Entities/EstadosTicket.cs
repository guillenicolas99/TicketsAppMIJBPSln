using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaInfraestructura.CapaDominio.Entities;

[Table("EstadosTicket")]
public partial class EstadosTicket
{
    [Key]
    public int IdEstadoTicket { get; set; }

    [Required(ErrorMessage = "El nombre del estado de la ticket es requerida"), MinLength(3, ErrorMessage = "El nombre debe contener al menos 3 caracteres")]
    public string NombreEstadoTicket { get; set; } = null!;

    [Required(ErrorMessage = "La descripción del estado es requerida"), MinLength(3, ErrorMessage = "La descripción debe contener al menos 3 caracteres")]
    public string DescripcionEstadoTicket { get; set; } = null!;

    [InverseProperty("EstadoTicketIdEstadoTicketNavigation")]
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
