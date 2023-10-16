using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service;

public class EntregaService : IEntregaService
{
    private readonly CoAutoContext _context;

    public EntregaService(CoAutoContext context)
    {
        _context = context;
    }

    // <summary>
    /// Insere uma nova entrega
    /// </summary>
    /// <param name="entrega">dados da entrega</param>
    /// <returns></returns>
    public  uint Create(Entrega entrega)
    {
        _context.Add(entrega);
        _context.SaveChanges();
        return (uint)entrega.Id;
    }

    // <summary>
    /// Deleta uma entrega
    /// </summary>
    /// <param name="id da entrega ">deleta a entrega </param>
    /// <returns></returns>
    public void Delete(uint id)
    {
        var entrega = _context.Entregas.Find(id);

        if (entrega == null) return;

        _context.Remove(entrega);
        _context.SaveChanges();
    }

    // <summary>
    /// Edita uma entrega
    /// </summary>
    /// <param name="entrega"></param>
    /// <exception cref="ServiceException"></exception>
    public void Edit(Entrega entrega)
    {
        _context.Update(entrega);
        _context.SaveChanges();
    }

    // <summary>
    /// busca uma entrega 
    /// </summary>
    /// <param name="id da entrega ">dados da entrega</param>
    /// <returns></returns>
    public Entrega Get(uint idEntrega)
    {
        return _context.Entregas.Find(idEntrega);
    }

    /// <summary>
    /// Obtém todas as entregas
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Entrega> GetAll()
    {
        string sql = "SELECT * FROM coauto.entrega;";
        var entregas = _context.Entregas.FromSqlRaw(sql).ToList();
        return entregas;
    }
}
