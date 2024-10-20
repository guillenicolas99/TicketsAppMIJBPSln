using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaInfraestructura.CapaDominio.Entities;

[Table("EstadosEvento")]
public partial class EstadosEvento
{
    [Key]
    public int IdEstadoEvento { get; set; }
    
    [Required(ErrorMessage = "El nombre del evento es requerida"), MinLength(3, ErrorMessage = "El nombre del evento debe contener al menos 3 caracteres")]
    public string NombreEstadoEvento { get; set; }

    [Required(ErrorMessage = "La descripción del evento es requerida"), MinLength(3, ErrorMessage = "descripción del evento debe contener al menos 3 caracteres")]
    public string DescripcionEstadoEvento { get; set; }

    [InverseProperty("EstadoEventoIdEstadoEventoNavigation")]
    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}
