namespace BasesBackend.Api.Models.Responses;

public class RecepcionResponse
{
    public int IdRecepcion { get; set; }
    public int IdCliente { get; set; }
    public string NumeroLote { get; set; } = string.Empty;
    public DateTime FechaRecepcion { get; set; }
    public string UsuarioAtendio { get; set; } = string.Empty;
}