namespace BasesBackend.Api.Models.Requests;

public class CreateDespachoRequest
{
    public int IdCliente { get; set; }
    public DateTime FechaDespacho { get; set; }
    public string Estado { get; set; } = string.Empty;
    public string Operario { get; set; } = string.Empty;
}