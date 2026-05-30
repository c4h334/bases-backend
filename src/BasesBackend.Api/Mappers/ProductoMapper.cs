using BasesBackend.Api.Models.Requests;
using BasesBackend.Api.Models.Responses;
using BasesBackend.Dto;

namespace BasesBackend.Api.Mappers;

public class ProductoMapper
{
    public static ProductoDto ToDto(CreateProductoRequest model)
    {
        return new ProductoDto
        {
            Codigo = model.Codigo,
            Nombre = model.Nombre,
            Detalle = model.Detalle,
            CantidadActual = model.CantidadActual,
            StockCritico = model.StockCritico,
            Bodega = model.Bodega,
            Pasillo = model.Pasillo,
            Estante = model.Estante
        };
    }

    public static ProductoDto ToDto(UpdateProductoRequest model)
    {
        return new ProductoDto
        {
            IdProducto = model.IdProducto,
            Codigo = model.Codigo,
            Nombre = model.Nombre,
            Detalle = model.Detalle,
            CantidadActual = model.CantidadActual,
            StockCritico = model.StockCritico,
            Bodega = model.Bodega,
            Pasillo = model.Pasillo,
            Estante = model.Estante
        };
    }

    public static List<ProductoResponse> ToResponse(List<ProductoDto> productos)
    {
        return productos.Select(p => ToResponse(p)).ToList();
    }

    public static ProductoResponse ToResponse(ProductoDto producto)
    {
        return new ProductoResponse
        {
            IdProducto = producto.IdProducto,
            Codigo = producto.Codigo,
            Nombre = producto.Nombre,
            Detalle = producto.Detalle,
            CantidadActual = producto.CantidadActual,
            StockCritico = producto.StockCritico,
            Bodega = producto.Bodega,
            Pasillo = producto.Pasillo,
            Estante = producto.Estante
        };
    }
}