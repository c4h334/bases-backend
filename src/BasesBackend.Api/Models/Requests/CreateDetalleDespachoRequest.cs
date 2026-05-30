namespace BasesBackend.Api.Models.Requests;

public class CreateDetalleDespachoRequest
{
    public int IdDespacho { get; set; }
    public int IdProducto { get; set; }
    public int Cantidad { get; set; }
}