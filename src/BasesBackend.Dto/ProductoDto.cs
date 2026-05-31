namespace BasesBackend.Dto;

public class ProductoDto
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

    // Propiedades nuevas exigidas por la rúbrica
    public DateTime? UltimoIngreso { get; set; }
    public DateTime? UltimoDespacho { get; set; }
    public string EstadoAlerta { get; set; } = string.Empty;
}