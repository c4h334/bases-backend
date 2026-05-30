using BasesBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasesBackend.Infrastructure.Respositories;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _context.Clientes.AsNoTracking().ToListAsync();
    }

    public async Task<Cliente?> GetByIdAsync(int id)
    {
        return await _context.Clientes.FirstOrDefaultAsync(x => x.IdCliente == id);
    }

    public async Task AddAsync(Cliente entity)
    {
        await _context.Clientes.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Cliente entity)
    {
        _context.Clientes.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Clientes.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}