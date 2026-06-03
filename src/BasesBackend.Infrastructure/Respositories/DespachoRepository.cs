using BasesBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

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

    public async Task<string> ProcesarDespachoAsync(int idDespacho, int idCliente)
    {
        using var command = _context.Database.GetDbConnection().CreateCommand();
        command.CommandText = "sp_ProcesarDespacho";
        command.CommandType = CommandType.StoredProcedure; // <-- Aquí está la magia

        command.Parameters.Add(new MySqlParameter("p_IdDespacho", idDespacho));
        command.Parameters.Add(new MySqlParameter("p_IdCliente", idCliente));

        var pResultado = new MySqlParameter("p_Resultado", MySqlDbType.VarChar, 255)
        {
            Direction = ParameterDirection.Output
        };
        command.Parameters.Add(pResultado);

        if (command.Connection.State != ConnectionState.Open)
            await command.Connection.OpenAsync();

        await command.ExecuteNonQueryAsync();

        return (pResultado.Value?.ToString() ?? "Error") ?? "Despacho procesado con éxito.";
    }
}
