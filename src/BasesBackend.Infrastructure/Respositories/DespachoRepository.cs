using BasesBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasesBackend.Infrastructure.Respositories;

public class DespachoRepository : IDespachoRepository
{
    private readonly AppDbContext _context;

    public DespachoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Despacho>> GetAllAsync()
    {
        return await _context.Despachos.AsNoTracking().ToListAsync();
    }

    public async Task<Despacho?> GetByIdAsync(int id)
    {
        return await _context.Despachos.FirstOrDefaultAsync(x => x.IdDespacho == id);
    }

    public async Task AddAsync(Despacho entity)
    {
        await _context.Despachos.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Despacho entity)
    {
        _context.Despachos.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Despachos.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}