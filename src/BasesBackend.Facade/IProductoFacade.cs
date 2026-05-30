using BasesBackend.Dto;

namespace BasesBackend.Facade;

public interface IProductoFacade
{
    Task<IEnumerable<ProductoDto>> GetAllAsync();
    Task<ProductoDto?> GetByIdAsync(int id);
    Task AddAsync(ProductoDto dto);
    Task UpdateAsync(ProductoDto dto);
    Task DeleteAsync(int id);
}