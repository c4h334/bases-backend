using BasesBackend.Dto;
using BasesBackend.DomainService;
using BasesBackend.Domain.Entities;

namespace BasesBackend.Facade;

public class ProductoFacade : IProductoFacade
{
    private readonly IProductoService _service;

    public ProductoFacade(IProductoService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<ProductoDto>> GetAllAsync()
    {
        var entities = await _service.GetAllAsync();
        return entities.Select(e => new ProductoDto
        {
            IdProducto = e.IdProducto,
            Codigo = e.Codigo,
            Nombre = e.Nombre,
            Detalle = e.Detalle,
            CantidadActual = e.CantidadActual,
            StockCritico = e.StockCritico,
            Bodega = e.Bodega,
            Pasillo = e.Pasillo,
            Estante = e.Estante
        });
    }

    public async Task<ProductoDto?> GetByIdAsync(int id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return null;
        return new ProductoDto
        {
            IdProducto = entity.IdProducto,
            Codigo = entity.Codigo,
            Nombre = entity.Nombre,
            Detalle = entity.Detalle,
            CantidadActual = entity.CantidadActual,
            StockCritico = entity.StockCritico,
            Bodega = entity.Bodega,
            Pasillo = entity.Pasillo,
            Estante = entity.Estante
        };
    }

    public async Task AddAsync(ProductoDto dto)
    {
        var entity = new Producto
        {
            Codigo = dto.Codigo,
            Nombre = dto.Nombre,
            Detalle = dto.Detalle,
            CantidadActual = dto.CantidadActual,
            StockCritico = dto.StockCritico,
            Bodega = dto.Bodega,
            Pasillo = dto.Pasillo,
            Estante = dto.Estante
        };
        await _service.AddAsync(entity);
    }

    public async Task UpdateAsync(ProductoDto dto)
    {
        var entity = new Producto
        {
            IdProducto = dto.IdProducto,
            Codigo = dto.Codigo,
            Nombre = dto.Nombre,
            Detalle = dto.Detalle,
            CantidadActual = dto.CantidadActual,
            StockCritico = dto.StockCritico,
            Bodega = dto.Bodega,
            Pasillo = dto.Pasillo,
            Estante = dto.Estante
        };
        await _service.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _service.DeleteAsync(id);
    }
}