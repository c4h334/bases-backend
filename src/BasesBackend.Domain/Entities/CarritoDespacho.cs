using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BasesBackend.Domain.Entities;

[Table("CARRITO_DESPACHO")]
public class CarritoDespacho
{
    [Key]
    [Column("IdCarrito")]
    public int IdCarrito { get; set; }

    [Column("IdDespacho")]
    public int IdDespacho { get; set; }

    [Column("IdProducto")]
    public int IdProducto { get; set; }

    [Column("Cantidad")]
    public int Cantidad { get; set; }

    [ForeignKey("IdDespacho")]
    public Despacho? Despacho { get; set; }

    [ForeignKey("IdProducto")]
    public Producto? Producto { get; set; }
}