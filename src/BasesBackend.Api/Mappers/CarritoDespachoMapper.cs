using BasesBackend.Api.Models.Requests;
using BasesBackend.Api.Models.Responses;
using BasesBackend.Dto;

namespace BasesBackend.Api.Mappers;

public class CarritoDespachoMapper
{
    public static CarritoDespachoDto ToDto(CreateCarritoDespachoRequest model)
    {
        return new CarritoDespachoDto
        {
            IdDespacho = model.IdDespacho,
            IdProducto = model.IdProducto,
            Cantidad = model.Cantidad
        };
    }

    public static CarritoDespachoDto ToDto(UpdateCarritoDespachoRequest model)
    {
        return new CarritoDespachoDto
        {
            IdCarrito = model.IdCarrito,
            IdDespacho = model.IdDespacho,
            IdProducto = model.IdProducto,
            Cantidad = model.Cantidad
        };
    }

    public static List<CarritoDespachoResponse> ToResponse(List<CarritoDespachoDto> carritos)
    {
        return carritos.Select(c => ToResponse(c)).ToList();
    }

    public static CarritoDespachoResponse ToResponse(CarritoDespachoDto carrito)
    {
        return new CarritoDespachoResponse
        {
            IdCarrito = carrito.IdCarrito,
            IdDespacho = carrito.IdDespacho,
            IdProducto = carrito.IdProducto,
            Cantidad = carrito.Cantidad
        };
    }
}