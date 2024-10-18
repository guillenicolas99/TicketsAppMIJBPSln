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

    public string NombreEstadoTicket { get; set; } = null!;

    public string DescripcionEstadoTicket { get; set; } = null!;

    [InverseProperty("EstadoTicketIdEstadoTicketNavigation")]
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
