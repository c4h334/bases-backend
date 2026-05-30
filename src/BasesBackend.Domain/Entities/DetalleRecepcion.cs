using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasesBackend.Domain.Entities;

[Table("DETALLE_RECEPCION")]
    public class DetalleRecepcion
    {
        [Key]
        [Column("IdDetalleRecepcion")]
        public int IdDetalleRecepcion { get; set; }

        [Column("IdRecepcion")]
        public int IdRecepcion { get; set; }

        [Column("IdProducto")]
        public int IdProducto { get; set; }

        [Column("Cantidad")]
        public int Cantidad { get; set; }

        [ForeignKey("IdRecepcion")]
        public Recepcion? Recepcion { get; set; }

        [ForeignKey("IdProducto")]
        public Producto? Producto { get; set; }
    }