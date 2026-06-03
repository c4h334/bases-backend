using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasesBackend.Domain.Entities
{
    [Table("DESPACHO")]
    public class Despacho
    {
        [Key]
        public int IdDespacho { get; set; }

        public int IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Cliente? Cliente { get; set; }

        public DateTime FechaDespacho { get; set; }
        public string Estado { get; set; }
        public string Operario { get; set; }
    }
}
