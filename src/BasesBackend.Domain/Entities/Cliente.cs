using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BasesBackend.Domain.Entities;

[Table("CLIENTE")]
public class Cliente
{
    [Key]
    [Column("IdCliente")]
    public int IdCliente { get; set; }

    [Column("Nombre")]
    public string Nombre { get; set; } = string.Empty;

    [Column("Telefono")]
    public string? Telefono { get; set; }

    [Column("Correo")]
    public string? Correo { get; set; }

    [Column("Direccion")]
    public string? Direccion { get; set; }

    [Column("RolCliente")]
    public string RolCliente { get; set; } = string.Empty;
}
