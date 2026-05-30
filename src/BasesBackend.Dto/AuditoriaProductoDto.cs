namespace BasesBackend.Dto;

public class AuditoriaProductoDto
{
    public int IdAuditoria { get; set; }
    public int IdProducto { get; set; }
    public DateTime FechaMovimiento { get; set; }
    public int CantidadAnterior { get; set; }
    public int CantidadNueva { get; set; }
    public string UsuarioModificacion { get; set; } = string.Empty;
}