namespace BasesBackend.Api.Models.Requests;

public class CreateRecepcionRequest
{
    public int IdCliente { get; set; }
    public string NumeroLote { get; set; } = string.Empty;
    public DateTime FechaRecepcion { get; set; }
    public string UsuarioAtendio { get; set; } = string.Empty;
}