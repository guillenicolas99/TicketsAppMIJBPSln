using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaInfraestructura.CapaDominio.Entities;

public partial class Ticket
{
    [Key]
    public int IdTicket { get; set; }
    [Required(ErrorMessage = "El número de ticket es requerido"), MinLength(3, ErrorMessage = "El nombre debe contener al menos 3 caracteres")]
    public string NumeroTicket { get; set; }

    public double? AbonoTicket { get; set; }

    [Required(ErrorMessage = "El precio es requerido")]
    public double PrecioOriginal { get; set; }

    public double? DescuentoAplicado { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaDescuento { get; set; }

    public int EventoIdEvento { get; set; }

    public int EstadoTicketIdEstadoTicket { get; set; }

    public int CategoriaTicketIdCategoriaTicket { get; set; }

    public int PersonaIdPersona { get; set; }

    [ForeignKey("CategoriaTicketIdCategoriaTicket")]
    [InverseProperty("Tickets")]
    public virtual CategoriasTicket CategoriaTicketIdCategoriaTicketNavigation { get; set; } = null!;

    [ForeignKey("EstadoTicketIdEstadoTicket")]
    [InverseProperty("Tickets")]
    public virtual EstadosTicket EstadoTicketIdEstadoTicketNavigation { get; set; } = null!;

    [ForeignKey("EventoIdEvento")]
    [InverseProperty("Tickets")]
    public virtual Evento EventoIdEventoNavigation { get; set; } = null!;

    [ForeignKey("PersonaIdPersona")]
    [InverseProperty("Tickets")]
    public virtual Persona PersonaIdPersonaNavigation { get; set; } = null!;
}
