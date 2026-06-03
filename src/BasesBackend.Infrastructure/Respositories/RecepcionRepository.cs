using BasesBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BasesBackend.Infrastructure.Respositories;

public class RecepcionRepository : IRecepcionRepository
{
    private readonly AppDbContext _context;

    public RecepcionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Recepcion>> GetAllAsync()
    {
        return await _context.Recepciones.AsNoTracking().ToListAsync();
    }

    public async Task<Recepcion?> GetByIdAsync(int id)
    {
        return await _context.Recepciones.FirstOrDefaultAsync(x => x.IdRecepcion == id);
    }

    public async Task AddAsync(Recepcion entity)
    {
        await _context.Recepciones.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Recepcion entity)
    {
        _context.Recepciones.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Recepciones.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<string> RegistrarRecepcionAsync(string numeroLote, string usuarioAtendio, int idCliente, int idProducto, int cantidad)
    {
        using var command = _context.Database.GetDbConnection().CreateCommand();
        command.CommandText = "sp_RegistrarRecepcion";
        command.CommandType = CommandType.StoredProcedure; // <-- Aquí está la magia

        command.Parameters.Add(new MySqlParameter("p_NumeroLote", numeroLote));
        command.Parameters.Add(new MySqlParameter("p_UsuarioAtendio", usuarioAtendio));
        command.Parameters.Add(new MySqlParameter("p_IdCliente", idCliente));
        command.Parameters.Add(new MySqlParameter("p_IdProducto", idProducto));
        command.Parameters.Add(new MySqlParameter("p_Cantidad", cantidad));

        var pResultado = new MySqlParameter("p_Resultado", MySqlDbType.VarChar, 255)
        {
            Direction = ParameterDirection.Output
        };
        command.Parameters.Add(pResultado);

        if (command.Connection.State != ConnectionState.Open)
            await command.Connection.OpenAsync();

        await command.ExecuteNonQueryAsync();

        return (pResultado.Value?.ToString() ?? "Error") ?? "Recepción procesada con éxito.";
    }
}
