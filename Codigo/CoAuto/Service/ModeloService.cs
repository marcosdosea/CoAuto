using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;
namespace Service;
/// <summary>
/// Implementa serviços para manter dados do banco
/// </summary>
public class ModeloService : IModeloService
{
    private readonly CoAutoContext _context;
    public ModeloService(CoAutoContext context)
    {
        this._context = context;
    }
    /// <summary>
    /// Criar um novo Modelo na base de dados
    /// </summary>
    /// <param name="modelo">dados do Modelo</param>
    /// <returns>id do Modelo</returns>
    public uint Create(Modelo modelo)
    {
        _context.Add(modelo);
        _context.SaveChanges();
        return (uint)modelo.Id;
    }
    /// <summary>
    /// Editar dados do modelo na base de dados
    /// </summary>
    /// <param name="modelo"></param>
    public void Edit(Modelo modelo)
    {
        _context.Update(modelo);
        _context.SaveChanges();
    }
    /// <summary>
    /// Remover o modelo da base de dados
    /// </summary>
    /// <param name="id">id do modelo</param>
    public void Delete(uint id)
    {
        var modelo = _context.Modelos.Find(id);
        _context.Remove(modelo);
        _context.SaveChanges();
    }
    /// <summary>
    /// Buscar um modelo na base de dados
    /// </summary>
    /// <param name="id">id do modelo</param>
    /// <returns>dados do modelo</returns>
    public Modelo Get(uint id)
    {
        return _context.Modelos.Find(id);
    }
    /// <summary>
    /// Buscar todos os Modelos cadastrados
    /// </summary>
    /// <returns>lista de Modelo</returns>
    public IEnumerable<Modelo> GetAll()
    {
        return _context.Modelos.AsNoTracking();
    }
    public IEnumerable<ModeloDTO> GetByNome(string nome)
    {
        var query = from modelo in _context.Modelos
                    where modelo.Nome.StartsWith(nome)
                    orderby modelo.Nome
                    select new Core.DTO.ModeloDTO
                    {
                        Id = modelo.Id,
                        IdMarca = modelo.IdMarca,
                        Nome = modelo.Nome
                    };
        return query;
    }
}