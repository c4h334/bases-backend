using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasesBackend.Domain.Entities;

[Table("DESPACHO")]
public class Despacho
{
    [Key]
    [Column("IdDespacho")]
    public int IdDespacho { get; set; }

    [Column("IdCliente")]
    public int IdCliente { get; set; }

    [Column("FechaDespacho")]
    public DateTime FechaDespacho { get; set; }

    [Column("Estado")]
    public string Estado { get; set; } = string.Empty;

    [Column("Operario")]
    public string Operario { get; set; } = string.Empty;

    [ForeignKey("IdCliente")]
    public Cliente? Cliente { get; set; }
}