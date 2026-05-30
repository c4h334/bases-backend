using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BasesBackend.Domain.Entities;

[Table("AUDITORIA_PRODUCTO")]
public class AuditoriaProducto
{
    [Key]
    [Column("IdAuditoria")]
    public int IdAuditoria { get; set; }

    [Column("IdProducto")]
    public int IdProducto { get; set; }

    [Column("FechaMovimiento")]
    public DateTime FechaMovimiento { get; set; }

    [Column("CantidadAnterior")]
    public int CantidadAnterior { get; set; }

    [Column("CantidadNueva")]
    public int CantidadNueva { get; set; }

    [Column("UsuarioModificacion")]
    public string UsuarioModificacion { get; set; } = string.Empty;

    [ForeignKey("IdProducto")]
    public Producto? Producto { get; set; }
}