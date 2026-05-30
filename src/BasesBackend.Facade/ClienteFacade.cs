using BasesBackend.Dto;
using BasesBackend.DomainService;
using BasesBackend.Domain.Entities;

namespace BasesBackend.Facade;

public class ClienteFacade : IClienteFacade
{
    private readonly IClienteService _service;

    public ClienteFacade(IClienteService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<ClienteDto>> GetAllAsync()
    {
        var entities = await _service.GetAllAsync();
        return entities.Select(e => new ClienteDto
        {
            IdCliente = e.IdCliente,
            Nombre = e.Nombre,
            Telefono = e.Telefono,
            Correo = e.Correo,
            Direccion = e.Direccion,
            RolCliente = e.RolCliente
        });
    }

    public async Task<ClienteDto?> GetByIdAsync(int id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null) return null;
        return new ClienteDto
        {
            IdCliente = entity.IdCliente,
            Nombre = entity.Nombre,
            Telefono = entity.Telefono,
            Correo = entity.Correo,
            Direccion = entity.Direccion,
            RolCliente = entity.RolCliente
        };
    }

    public async Task AddAsync(ClienteDto dto)
    {
        var entity = new Cliente
        {
            Nombre = dto.Nombre,
            Telefono = dto.Telefono,
            Correo = dto.Correo,
            Direccion = dto.Direccion,
            RolCliente = dto.RolCliente
        };
        await _service.AddAsync(entity);
    }

    public async Task UpdateAsync(ClienteDto dto)
    {
        var entity = new Cliente
        {
            IdCliente = dto.IdCliente,
            Nombre = dto.Nombre,
            Telefono = dto.Telefono,
            Correo = dto.Correo,
            Direccion = dto.Direccion,
            RolCliente = dto.RolCliente
        };
        await _service.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _service.DeleteAsync(id);
    }
}