using BasesBackend.Api.Models.Responses;
using BasesBackend.Dto;

namespace BasesBackend.Api.Mappers;

public class AuditoriaProductoMapper
{
    public static List<AuditoriaProductoResponse> ToResponse(List<AuditoriaProductoDto> auditorias)
    {
        return auditorias.Select(a => ToResponse(a)).ToList();
    }

    public static AuditoriaProductoResponse ToResponse(AuditoriaProductoDto auditoria)
    {
        return new AuditoriaProductoResponse
        {
            IdAuditoria = auditoria.IdAuditoria,
            IdProducto = auditoria.IdProducto,
            FechaMovimiento = auditoria.FechaMovimiento,
            CantidadAnterior = auditoria.CantidadAnterior,
            CantidadNueva = auditoria.CantidadNueva,
            UsuarioModificacion = auditoria.UsuarioModificacion
        };
    }
}