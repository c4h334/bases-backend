namespace BasesBackend.Api.Models.Requests;

public class UpdateCarritoDespachoRequest
{
    public int IdCarrito { get; set; }
    public int IdDespacho { get; set; }
    public int IdProducto { get; set; }
    public int Cantidad { get; set; }
}