using BasesBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasesBackend.Infrastructure.Respositories;

public class DetalleRecepcionRepository : IDetalleRecepcionRepository
{
    private readonly AppDbContext _context;

    public DetalleRecepcionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DetalleRecepcion>> GetAllAsync()
    {
        return await _context.DetallesRecepcion.AsNoTracking().ToListAsync();
    }

    public async Task<DetalleRecepcion?> GetByIdAsync(int id)
    {
        return await _context.DetallesRecepcion.FirstOrDefaultAsync(x => x.IdDetalleRecepcion == id);
    }

    public async Task AddAsync(DetalleRecepcion entity)
    {
        await _context.DetallesRecepcion.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(DetalleRecepcion entity)
    {
        _context.DetallesRecepcion.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.DetallesRecepcion.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}