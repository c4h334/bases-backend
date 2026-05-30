using BasesBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasesBackend.Infrastructure.Respositories;

public class CarritoDespachoRepository : ICarritoDespachoRepository
{
    private readonly AppDbContext _context;

    public CarritoDespachoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CarritoDespacho>> GetAllAsync()
    {
        return await _context.CarritosDespacho.AsNoTracking().ToListAsync();
    }

    public async Task<CarritoDespacho?> GetByIdAsync(int id)
    {
        return await _context.CarritosDespacho.FirstOrDefaultAsync(x => x.IdCarrito == id);
    }

    public async Task AddAsync(CarritoDespacho entity)
    {
        await _context.CarritosDespacho.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CarritoDespacho entity)
    {
        _context.CarritosDespacho.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.CarritosDespacho.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}