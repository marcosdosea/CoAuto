using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service;

public class ModeloService : IModeloService
{
    private readonly CoAutoContext _context;

    public ModeloService(CoAutoContext context)
    {
        _context = context;
    }

    // <summary>
    /// Insere um novo modelo
    /// </summary>
    /// <param name="modelo">dados do modelo</param>
    /// <returns></returns>
    public uint Create(Modelo modelo)
    {
        _context.Add(modelo);
        _context.SaveChanges();
        return modelo.Id;
    }

    // <summary>
    /// Deleta um modelo
    /// </summary>
    /// <param name="id da modelo ">deleta o modelo </param>
    /// <returns></returns>
    public void Delete(uint idModelo)
    {
        var modelo = _context.Modelos.Find(idModelo);

        if (modelo == null) return;

        _context.Remove(modelo);
        _context.SaveChanges();

    }

    // <summary>
    /// Edita um modelo
    /// </summary>
    /// <param name="modelo"></param>
    /// <exception cref="ServiceException"></exception>
    public void Edit(Modelo modelo)
    {
        _context.Update(modelo);
        _context.SaveChanges();
    }

    // <summary>
    /// busca um modelo 
    /// </summary>
    /// <param name="id do modelo">dados do modelo</param>
    /// <returns></returns>
    public Modelo Get(uint idModelo)
    {
        return _context.Modelos.Find(idModelo);
    }

    /// <summary>
    /// Obtém todos modelos
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Modelo> GetAll()
    {
        return _context.Modelos.ToList();
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