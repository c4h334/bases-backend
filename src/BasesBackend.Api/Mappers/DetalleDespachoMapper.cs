using BasesBackend.Api.Models.Requests;
using BasesBackend.Api.Models.Responses;
using BasesBackend.Dto;

namespace BasesBackend.Api.Mappers;

public class DetalleDespachoMapper
{
    public static DetalleDespachoDto ToDto(CreateDetalleDespachoRequest model)
    {
        return new DetalleDespachoDto
        {
            IdDespacho = model.IdDespacho,
            IdProducto = model.IdProducto,
            Cantidad = model.Cantidad
        };
    }

    public static DetalleDespachoDto ToDto(UpdateDetalleDespachoRequest model)
    {
        return new DetalleDespachoDto
        {
            IdDetalle = model.IdDetalle,
            IdDespacho = model.IdDespacho,
            IdProducto = model.IdProducto,
            Cantidad = model.Cantidad
        };
    }

    public static List<DetalleDespachoResponse> ToResponse(List<DetalleDespachoDto> detalles)
    {
        return detalles.Select(d => ToResponse(d)).ToList();
    }

    public static DetalleDespachoResponse ToResponse(DetalleDespachoDto detalle)
    {
        return new DetalleDespachoResponse
        {
            IdDetalle = detalle.IdDetalle,
            IdDespacho = detalle.IdDespacho,
            IdProducto = detalle.IdProducto,
            Cantidad = detalle.Cantidad
        };
    }
}