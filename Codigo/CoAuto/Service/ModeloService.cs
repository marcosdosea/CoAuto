using Core;
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
    public async Task<uint> Create(Modelo modelo)
    {
        await _context.AddAsync(modelo);
        await _context.SaveChangesAsync();
        return modelo.Id;
    }

    // <summary>
    /// Deleta um modelo
    /// </summary>
    /// <param name="id da modelo ">deleta o modelo </param>
    /// <returns></returns>
    public async Task Delete(uint idModelo)
    {
        var modelo = await _context.Modelos.
            FindAsync(idModelo);

        if (modelo == null) return;

        _context.Remove(modelo);
        await _context.SaveChangesAsync();

    }

    // <summary>
    /// Edita um modelo
    /// </summary>
    /// <param name="modelo"></param>
    /// <exception cref="ServiceException"></exception>
    public async Task Edit(Modelo modelo)
    {
        _context.Update(modelo);

        await _context.SaveChangesAsync();
    }

    // <summary>
    /// busca um modelo 
    /// </summary>
    /// <param name="id do modelo">dados do modelo</param>
    /// <returns></returns>
    public async Task<Modelo> Get(uint idModelo)
    {
        return await _context.Modelos.FindAsync(idModelo);
    }

    /// <summary>
    /// Obtém todos modelos
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Modelo>> GetAll()
    {
        return await _context.Modelos.ToListAsync();
    }
}
