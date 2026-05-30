using BasesBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasesBackend.Infrastructure.Respositories;

public class DetalleDespachoRepository : IDetalleDespachoRepository
{
    private readonly AppDbContext _context;

    public DetalleDespachoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DetalleDespacho>> GetAllAsync()
    {
        return await _context.DetallesDespacho.AsNoTracking().ToListAsync();
    }

    public async Task<DetalleDespacho?> GetByIdAsync(int id)
    {
        return await _context.DetallesDespacho.FirstOrDefaultAsync(x => x.IdDetalle == id);
    }

    public async Task AddAsync(DetalleDespacho entity)
    {
        await _context.DetallesDespacho.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(DetalleDespacho entity)
    {
        _context.DetallesDespacho.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.DetallesDespacho.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}