namespace BasesBackend.Api.Models.Requests;

public class UpdateRecepcionRequest
{
    public int IdRecepcion { get; set; }
    public int IdCliente { get; set; }
    public string NumeroLote { get; set; } = string.Empty;
    public DateTime FechaRecepcion { get; set; }
    public string UsuarioAtendio { get; set; } = string.Empty;
}