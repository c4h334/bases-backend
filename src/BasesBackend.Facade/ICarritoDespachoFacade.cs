using BasesBackend.Dto;

namespace BasesBackend.Facade;

public interface ICarritoDespachoFacade
{
    Task<IEnumerable<CarritoDespachoDto>> GetAllAsync();
    Task<CarritoDespachoDto?> GetByIdAsync(int id);
    Task AddAsync(CarritoDespachoDto dto);
    Task UpdateAsync(CarritoDespachoDto dto);
    Task DeleteAsync(int id);
}