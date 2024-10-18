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

    public string NombreEstadoEvento { get; set; } = null!;

    public string DescripcionEstadoEvento { get; set; } = null!;

    [InverseProperty("EstadoEventoIdEstadoEventoNavigation")]
    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}
