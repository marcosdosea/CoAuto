using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Service;
/// <summary>
/// Implementa serviços para manter dados da marca
/// </summary>
public class MarcaService : IMarcaService
{
    private readonly CoAutoContext _context;
    public MarcaService(CoAutoContext context)
    {
        this._context = context;
    }
    /// <summary>
    /// Criar um novo marca na base de dados
    /// </summary>
    /// <param name="marca">dados do marca</param>
    /// <returns>id do Marca</returns>
    public uint Create(Marca marca)
    {
        _context.Add(marca);
        _context.SaveChanges();
        return (uint)marca.Id;
    }
    /// <summary>
    /// Editar dados de marca na base de dados
    /// </summary>
    /// <param name="marca"></param>
    public void Edit(Marca marca)
    {
        _context.Update(marca);
        _context.SaveChanges();
    }
    /// <summary>
    /// Remover o banco da base de dados
    /// </summary>
    /// <param name="id">id do banco</param>
    public void Delete(uint id)
    {
        var Marca = _context.Marcas.Find(id);
        _context.Remove(Marca);
        _context.SaveChanges();
    }
    /// <summary>
    /// Buscar um banco na base de dados
    /// </summary>
    /// <param name="id">id do banco</param>
    /// <returns>dados do banco</returns>
    public Marca Get(uint id)
    {
        return _context.Marcas.Find(id);
    }
    /// <summary>
    /// Buscar todos os bancos cadastrados
    /// </summary>
    /// <returns>lista de banco</returns>
    public IEnumerable<Marca> GetAll()
    {
        return _context.Marcas.AsNoTracking();
    }
    public IEnumerable<MarcaDTO> GetByNome(string nome)
    {
        var query = from marca in _context.Marcas
                    where marca.Nome.StartsWith(nome)
                    orderby marca.Nome
                    select new Core.DTO.MarcaDTO
                    {
                        Id = marca.Id,
                        Nome = marca.Nome
                    };
        return query;
    }
}