using BasesBackend.Dto;

namespace BasesBackend.Facade;

public interface IDespachoFacade
{
    Task<IEnumerable<DespachoDto>> GetAllAsync();
    Task<DespachoDto?> GetByIdAsync(int id);
    Task AddAsync(DespachoDto dto);
    Task UpdateAsync(DespachoDto dto);
    Task DeleteAsync(int id);
}