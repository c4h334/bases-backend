namespace BasesBackend.Api.Models.Responses;

public class ClienteResponse
{
    public int IdCliente { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Telefono { get; set; }
    public string? Correo { get; set; }
    public string? Direccion { get; set; }
    public string RolCliente { get; set; } = string.Empty;
}