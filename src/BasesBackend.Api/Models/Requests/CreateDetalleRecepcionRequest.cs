namespace BasesBackend.Api.Models.Requests;

public class CreateDetalleRecepcionRequest
{
    public int IdRecepcion { get; set; }
    public int IdProducto { get; set; }
    public int Cantidad { get; set; }
}