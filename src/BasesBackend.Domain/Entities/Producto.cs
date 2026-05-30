using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BasesBackend.Domain.Entities;

[Table("PRODUCTO")]
    public class Producto
    {
        [Key]
        [Column("IdProducto")]
        public int IdProducto { get; set; }

        [Column("Codigo")]
        public string Codigo { get; set; } = string.Empty;

        [Column("Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Column("Detalle")]
        public string? Detalle { get; set; }

        [Column("CantidadActual")]
        public int CantidadActual { get; set; }

        [Column("StockCritico")]
        public int StockCritico { get; set; }

        [Column("Bodega")]
        public string Bodega { get; set; } = string.Empty;

        [Column("Pasillo")]
        public string Pasillo { get; set; } = string.Empty;

        [Column("Estante")]
        public string Estante { get; set; } = string.Empty;
    }