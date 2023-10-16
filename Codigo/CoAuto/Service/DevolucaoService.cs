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
    public uint Create(Devolucao devolucao)
    {
        _context.Add(devolucao);
        _context.SaveChanges();
        return (uint)devolucao.Id;
    }

    // <summary>
    /// Deleta uma devolucao
    /// </summary>
    /// <param name="id da devolucao ">deleta a devolucao </param>
    /// <returns></returns>
    public void Delete(uint id)
    {
        var devolucao = _context.Devolucaos.Find(id);

        if (devolucao == null) return;

        _context.Remove(devolucao);
        _context.SaveChanges();
    }

    // <summary>
    /// Edita uma devolucao
    /// </summary>
    /// <param name="devolucao"></param>
    /// <exception cref="ServiceException"></exception>
    public void Edit(Devolucao devolucao)
    {
        _context.Update(devolucao);
        _context.SaveChanges();
    }

    // <summary>
    /// busca uma devolucao 
    /// </summary>
    /// <param name="id da devolucao ">dados da devolucao</param>
    /// <returns></returns>
    public Devolucao Get(uint idDevolucao)
    {
        return _context.Devolucaos.Find(idDevolucao);
    }

    /// <summary>
    /// Obtém todas as devoluções
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Devolucao> GetAll()
    {
        return _context.Devolucaos.ToList();
    }
}