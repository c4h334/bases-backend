using BasesBackend.Api.Models.Requests;
using BasesBackend.Api.Models.Responses;
using BasesBackend.Dto;

namespace BasesBackend.Api.Mappers;

public class DetalleRecepcionMapper
{
    public static DetalleRecepcionDto ToDto(CreateDetalleRecepcionRequest model)
    {
        return new DetalleRecepcionDto
        {
            IdRecepcion = model.IdRecepcion,
            IdProducto = model.IdProducto,
            Cantidad = model.Cantidad
        };
    }

    public static DetalleRecepcionDto ToDto(UpdateDetalleRecepcionRequest model)
    {
        return new DetalleRecepcionDto
        {
            IdDetalleRecepcion = model.IdDetalleRecepcion,
            IdRecepcion = model.IdRecepcion,
            IdProducto = model.IdProducto,
            Cantidad = model.Cantidad
        };
    }

    public static List<DetalleRecepcionResponse> ToResponse(List<DetalleRecepcionDto> detalles)
    {
        return detalles.Select(d => ToResponse(d)).ToList();
    }

    public static DetalleRecepcionResponse ToResponse(DetalleRecepcionDto detalle)
    {
        return new DetalleRecepcionResponse
        {
            IdDetalleRecepcion = detalle.IdDetalleRecepcion,
            IdRecepcion = detalle.IdRecepcion,
            IdProducto = detalle.IdProducto,
            Cantidad = detalle.Cantidad
        };
    }
}