namespace BasesBackend.Api.Models.Responses;

public class DespachoResponse
{
    public int IdDespacho { get; set; }
    public int IdCliente { get; set; }
    public DateTime FechaDespacho { get; set; }
    public string Estado { get; set; } = string.Empty;
    public string Operario { get; set; } = string.Empty;
}