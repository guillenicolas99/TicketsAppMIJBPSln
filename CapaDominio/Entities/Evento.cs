using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaInfraestructura.CapaDominio.Entities;

public partial class Evento
{
    [Key]
    public int IdEvento { get; set; }

    public string NombreEvento { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaEvento { get; set; }

    public int CantidadTotalTickets { get; set; }

    public string DescripcionEvento { get; set; }

    public int EstadoEventoIdEstadoEvento { get; set; }

    [ForeignKey("EstadoEventoIdEstadoEvento")]
    [InverseProperty("Eventos")]
    public virtual EstadosEvento? EstadoEventoIdEstadoEventoNavigation { get; set; }

    [InverseProperty("EventoIdEventoNavigation")]
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
