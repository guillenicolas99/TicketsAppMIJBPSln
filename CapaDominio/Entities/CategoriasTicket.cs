using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaInfraestructura.CapaDominio.Entities;

[Table("CategoriasTicket")]
public partial class CategoriasTicket
{
    [Key]
    public int IdCategoriaTicket { get; set; }

    [Required(ErrorMessage = "El nombre de la categoría es requerida"), MinLength(3, ErrorMessage = "El nombre debe contener al menos 3 caracteres")]
    public string NombreCategoriaTicket { get; set; } = null!;

    [Required(ErrorMessage = "El nombre de la categoría es requerida")]
    public string DescripcionCategoriaTicket { get; set; } = null!;

    public double? DescuentoAplicable { get; set; }

    [InverseProperty("CategoriaTicketIdCategoriaTicketNavigation")]
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
