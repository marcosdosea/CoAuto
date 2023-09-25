using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service;

public class BancoService : IBancoService
{
    private readonly CoAutoContext _context;

    public BancoService(CoAutoContext context)
    {
        _context = context;
    }

    // <summary>
    /// Insere um novo banco 
    /// </summary>
    /// <param name="banco">dados do banco</param>
    /// <returns></returns>
    public async Task<uint> Create(Banco banco)
    {
        await _context.AddAsync(banco);
        await _context.SaveChangesAsync();
        return banco.Id;
    }

    // <summary>
    /// Deleta um banco
    /// </summary>
    /// <param name="id do banco ">deleta o banco </param>
    /// <returns></returns>
    public async Task Delete(uint idBanco)
    {
        var banco = await _context.Bancos.
        FindAsync(idBanco);

        if (banco == null) return;

        _context.Remove(banco);
        await _context.SaveChangesAsync();

    }

    // <summary>
    /// Edita um banco
    /// </summary>
    /// <param name="banco"></param>
    /// <exception cref="ServiceException"></exception>
    public async Task Edit(Banco banco)
    {
        _context.Update(banco);

        await _context.SaveChangesAsync();
    }

    // <summary>
    /// busca um banco 
    /// </summary>
    /// <param name="id do banco ">dados do banco</param>
    /// <returns></returns>
    public async Task<Banco> Get(uint idBanco)
    {
        return await _context.Bancos.FindAsync(idBanco);
    }

    /// <summary>
    /// Obtém todas os bancos
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Banco>> GetAll()
    {
        return await _context.Bancos.ToListAsync();
    }
}
