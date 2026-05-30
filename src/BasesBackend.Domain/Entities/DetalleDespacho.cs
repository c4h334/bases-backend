using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BasesBackend.Domain.Entities;

[Table("DETALLE_DESPACHO")]
    public class DetalleDespacho
    {
        [Key]
        [Column("IdDetalle")]
        public int IdDetalle { get; set; }

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