using Core;
using Core.Service;

namespace Service;

/// <summary>
/// Manter dados de disponibilidades do veiculo no banco de dados
/// </summary>

public class DisponibilidadeService : IDisponibilidadeService
{

    private readonly CoAutoContext _context;

    public DisponibilidadeService(CoAutoContext context)
    {
        _context = context;
    }


    // <summary>
    /// Insere uma nova disponibilidade
    /// </summary>
    /// <param name="disponibilidade">dados da disponibilidade</param>
    /// <returns></returns>
    public int Create(Disponibilidade disponibilidade)
    {
        _context.Add(disponibilidade);
        _context.SaveChanges();
        return (int)disponibilidade.Id;
    }

    // <summary>
    /// Deleta uma disponibilidade
    /// </summary>
    /// <param name="id da disponibilidade ">deleta a disponibilidade </param>
    /// <returns></returns>
    public void Delete(int iddisponibilidade)
    {
        var _disponibilidade = _context.Disponibilidades.Find(iddisponibilidade);
        _context.Remove(_disponibilidade);
        _context.SaveChanges();
    }


    // <summary>
    /// Editar uma disponibilidade
    /// </summary>
    /// <param name="disponibilidade"></param>
    /// <exception cref="ServiceException"></exception>
    public void Edit(Disponibilidade disponibilidade)
    {
        _context.Update(disponibilidade);
        _context.SaveChanges();
    }

    // <summary>
    /// busca uma disponibilidade 
    /// </summary>
    /// <param name="id da disponibilidade ">dados da disponibilidade</param>
    /// <returns></returns>
    public Disponibilidade Get(int id)
    {
        return _context.Disponibilidades.Find(id);
    }
    /// <summary>
    /// Obtém todas disponibilidades
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Disponibilidade> GetAll()
    {
        return _context.Disponibilidades;
    }
}
