using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service;

public class DevolucaoService : IDevolucaoService
{
    private readonly CoAutoContext _context;

    public DevolucaoService(CoAutoContext context)
    {
        _context = context;
    }

    // <summary>
    /// Insere uma nova entrega
    /// </summary>
    /// <param name="entrega">dados da entrega</param>
    /// <returns></returns>
    public async Task<uint> Create(Devolucao devolucao)
    {
        await _context.AddAsync(devolucao);
        await _context.SaveChangesAsync();
        return (uint)devolucao.Id;
    }

    // <summary>
    /// Deleta uma devolucao
    /// </summary>
    /// <param name="id da devolucao ">deleta a devolucao </param>
    /// <returns></returns>
    public async Task Delete(uint id)
    {
        var devolucao = await _context.Devolucaos.
        FindAsync(id);

        if (devolucao == null) return;

        _context.Remove(devolucao);
        await _context.SaveChangesAsync();
    }

    // <summary>
    /// Edita uma devolucao
    /// </summary>
    /// <param name="devolucao"></param>
    /// <exception cref="ServiceException"></exception>
    public async Task Edit(Devolucao devolucao)
    {
        _context.Update(devolucao);

        await _context.SaveChangesAsync();
    }

    // <summary>
    /// busca uma devolucao 
    /// </summary>
    /// <param name="id da devolucao ">dados da devolucao</param>
    /// <returns></returns>
    public async Task<Devolucao> Get(uint idDevolucao)
    {
        return await _context.Devolucaos.FindAsync(idDevolucao);
    }

    /// <summary>
    /// Obtém todas as devoluções
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Devolucao>> GetAll()
    {
        return await _context.Devolucaos.ToListAsync();
    }
}