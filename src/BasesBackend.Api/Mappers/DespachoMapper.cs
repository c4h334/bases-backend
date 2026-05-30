using BasesBackend.Api.Models.Requests;
using BasesBackend.Api.Models.Responses;
using BasesBackend.Dto;

namespace BasesBackend.Api.Mappers;

public class DespachoMapper
{
    public static DespachoDto ToDto(CreateDespachoRequest model)
    {
        return new DespachoDto
        {
            IdCliente = model.IdCliente,
            FechaDespacho = model.FechaDespacho,
            Estado = model.Estado,
            Operario = model.Operario
        };
    }

    public static DespachoDto ToDto(UpdateDespachoRequest model)
    {
        return new DespachoDto
        {
            IdDespacho = model.IdDespacho,
            IdCliente = model.IdCliente,
            FechaDespacho = model.FechaDespacho,
            Estado = model.Estado,
            Operario = model.Operario
        };
    }

    public static List<DespachoResponse> ToResponse(List<DespachoDto> despachos)
    {
        return despachos.Select(d => ToResponse(d)).ToList();
    }

    public static DespachoResponse ToResponse(DespachoDto despacho)
    {
        return new DespachoResponse
        {
            IdDespacho = despacho.IdDespacho,
            IdCliente = despacho.IdCliente,
            FechaDespacho = despacho.FechaDespacho,
            Estado = despacho.Estado,
            Operario = despacho.Operario
        };
    }
}