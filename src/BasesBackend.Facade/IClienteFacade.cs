using BasesBackend.Dto;

namespace BasesBackend.Facade;

public interface IClienteFacade
{
    Task<IEnumerable<ClienteDto>> GetAllAsync();
    Task<ClienteDto?> GetByIdAsync(int id);
    Task AddAsync(ClienteDto dto);
    Task UpdateAsync(ClienteDto dto);
    Task DeleteAsync(int id);
}