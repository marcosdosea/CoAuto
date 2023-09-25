using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
namespace Service;
/// <summary>
/// Implementa serviços para manter dados do aluguel
/// </summary>
public class AluguelService : IAluguelService
{
    private readonly CoAutoContext _context;
    public AluguelService(CoAutoContext context)
    {
        this._context = context;
    }
    /// <summary>
    /// Criar um novo aluguel na base de dados
    /// </summary>
    /// <param name="aluguel">dados do aluguel</param>
    /// <returns>id do aluguel</returns>
    public uint Create(Aluguel aluguel)
    {
        _context.Add(aluguel);
        _context.SaveChanges();
        return (uint)aluguel.Id;
    }
    /// <summary>
    /// Editar dados do aluguel na base de dados
    /// </summary>
    /// <param name="aluguel"></param>
    public void Edit(Aluguel aluguel)
    {
        _context.Update(aluguel);
        _context.SaveChanges();
    }
    /// <summary>
    /// Remover o aluguel da base de dados
    /// </summary>
    /// <param name="id">id do aluguel</param>
    public void Delete(uint id)
    {
        var aluguel = _context.Aluguels.Find(id);
        _context.Remove(aluguel);
        _context.SaveChanges();
    }
    /// <summary>
    /// Buscar um aluguel na base de dados
    /// </summary>
    /// <param name="id">id do aluguel</param>
    /// <returns>dados do aluguel</returns>
    public Aluguel Get(uint id)
    {
        return _context.Aluguels.Find(id);
    }
    /// <summary>
    /// Buscar todos os aluguels cadastrados
    /// </summary>
    /// <returns>lista de aluguel</returns>
    public IEnumerable<Aluguel> GetAll()
    {
        return _context.Aluguels.AsNoTracking();
    }
}