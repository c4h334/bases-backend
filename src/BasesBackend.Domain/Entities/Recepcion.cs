
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BasesBackend.Domain.Entities;

[Table("RECEPCION")]
    public class Recepcion
    {
        [Key]
        [Column("IdRecepcion")]
        public int IdRecepcion { get; set; }

        [Column("IdCliente")]
        public int IdCliente { get; set; }

        [Column("NumeroLote")]
        public string NumeroLote { get; set; } = string.Empty;

        [Column("FechaRecepcion")]
        public DateTime FechaRecepcion { get; set; }

        [Column("UsuarioAtendio")]
        public string UsuarioAtendio { get; set; } = string.Empty;

        [ForeignKey("IdCliente")]
        public Cliente? Cliente { get; set; }
    }