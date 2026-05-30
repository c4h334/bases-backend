namespace BasesBackend.Api.Models.Requests;

public class UpdateDetalleDespachoRequest
{
    public int IdDetalle { get; set; }
    public int IdDespacho { get; set; }
    public int IdProducto { get; set; }
    public int Cantidad { get; set; }
}