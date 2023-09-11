using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service;

/// <summary>
/// Implementa serviços para manter dados da pessoa
/// </summary>
public class PessoaService : IPessoaService
{
    private readonly CoAutoContext _context;

    public PessoaService(CoAutoContext context)
    {
        this._context = context;
    }

    /// <summary>
    /// Criar uma novo pessoa na base de dados
    /// </summary>
    /// <param name="pessoa">dados da pessoa</param>
    /// <returns>id do pessoa</returns>
    public uint Create(Pessoa pessoa)
    {
        _context.Add(pessoa);
        _context.SaveChanges();
        return (uint)pessoa.Id;
    }

    /// <summary>
    /// Editar dados da pessoa na base de dados
    /// </summary>
    /// <param name="pessoa"></param>
    public void Edit(Pessoa pessoa)
    {
        _context.Update(pessoa);
        _context.SaveChanges();
    }

    /// <summary>
    /// Remover a pessoa da base de dados
    /// </summary>
    /// <param name="id">id da pessoa</param>
    public void Delete(uint id)
    {
        var pessoa = _context.Pessoas.Find(id);
        _context.Remove(pessoa);
        _context.SaveChanges();
    }


    /// <summary>
    /// Buscar uma pessoa na base de dados
    /// </summary>
    /// <param name="id">id da pessoa</param>
    /// <returns>dados da pessoa</returns>
    public Pessoa Get(uint id)
    {
        return _context.Pessoas.Find(id);
    }

    /// <summary>
    /// Buscar todos as pessoas cadastrados
    /// </summary>
    /// <returns>lista de pessoas</returns>
    public IEnumerable<Pessoa> GetAll()
    {
        return _context.Pessoas.AsNoTracking();
    }
}