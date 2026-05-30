namespace BasesBackend.Api.Models.Responses;

public class ProductoResponse
{
    public int IdProducto { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string? Detalle { get; set; }
    public int CantidadActual { get; set; }
    public int StockCritico { get; set; }
    public string Bodega { get; set; } = string.Empty;
    public string Pasillo { get; set; } = string.Empty;
    public string Estante { get; set; } = string.Empty;
}