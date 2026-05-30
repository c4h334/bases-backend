namespace BasesBackend.Api.Models.Requests;

public class UpdateDetalleRecepcionRequest
{
    public int IdDetalleRecepcion { get; set; }
    public int IdRecepcion { get; set; }
    public int IdProducto { get; set; }
    public int Cantidad { get; set; }
}