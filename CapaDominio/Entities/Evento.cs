using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaInfraestructura.CapaDominio.Entities;

public partial class Evento
{
    [Key]
    public int IdEvento { get; set; }

    [Required(ErrorMessage = "El nombre del Evento  es requerido"), MinLength(3, ErrorMessage = "El nombre debe contener al menos 3 caracteres")]
    public string NombreEvento { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaEvento { get; set; }

    public int? CantidadTotalTickets { get; set; }

    public string? DescripcionEvento { get; set; }

    [Required(ErrorMessage = "El nombre del estado de la ticket es requerida")]
    public int EstadoEventoIdEstadoEvento { get; set; }

    [ForeignKey("EstadoEventoIdEstadoEvento")]
    [InverseProperty("Eventos")]
    public virtual EstadosEvento? EstadoEventoIdEstadoEventoNavigation { get; set; }

    [InverseProperty("EventoIdEventoNavigation")]
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
