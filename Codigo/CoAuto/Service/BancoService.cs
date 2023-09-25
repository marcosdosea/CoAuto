using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
namespace Service;
/// <summary>
/// Implementa serviços para manter dados do banco
/// </summary>
public class BancoService : IBancoService
{
    private readonly CoAutoContext _context;
    public BancoService(CoAutoContext context)
    {
        this._context = context;
    }
    /// <summary>
    /// Criar um novo banco na base de dados
    /// </summary>
    /// <param name="banco">dados do banco</param>
    /// <returns>id do banco</returns>
    public uint Create(Banco banco)
    {
        _context.Add(banco);
        _context.SaveChanges();
        return (uint)banco.Id;
    }
    /// <summary>
    /// Editar dados do banco na base de dados
    /// </summary>
    /// <param name="banco"></param>
    public void Edit(Banco banco)
    {
        _context.Update(banco);
        _context.SaveChanges();
    }
    /// <summary>
    /// Remover o banco da base de dados
    /// </summary>
    /// <param name="id">id do banco</param>
    public void Delete(uint id)
    {
        var banco = _context.Bancos.Find(id);
        _context.Remove(banco);
        _context.SaveChanges();
    }
    /// <summary>
    /// Buscar um banco na base de dados
    /// </summary>
    /// <param name="id">id do banco</param>
    /// <returns>dados do banco</returns>
    public Banco Get(uint id)
    {
        return _context.Bancos.Find(id);
    }
    /// <summary>
    /// Buscar todos os bancos cadastrados
    /// </summary>
    /// <returns>lista de banco</returns>
    public IEnumerable<Banco> GetAll()
    {
        return _context.Bancos.AsNoTracking();
    }
}