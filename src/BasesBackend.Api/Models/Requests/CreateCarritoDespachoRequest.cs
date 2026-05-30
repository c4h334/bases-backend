namespace BasesBackend.Api.Models.Requests;

public class CreateCarritoDespachoRequest
{
    public int IdDespacho { get; set; }
    public int IdProducto { get; set; }
    public int Cantidad { get; set; }
}