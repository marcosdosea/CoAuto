using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service;

public class VeiculoService : IVeiculoService
{
    private readonly CoAutoContext _context;

    public VeiculoService(CoAutoContext context)
    {
        _context = context;
    }

    // <summary>
    /// Insere um novo veículo
    /// </summary>
    /// <param name="veiculo">dados do veiculo</param>
    /// <returns></returns>
    public async Task<uint> Create(Veiculo veiculo)
    {
        await _context.AddAsync(veiculo);
        await _context.SaveChangesAsync();
        return veiculo.Id;
    }

    // <summary>
    /// Deleta um veículo
    /// </summary>
    /// <param name="id da veículo ">deleta o veículo </param>
    /// <returns></returns>
    public async Task Delete(uint idVeiculo)
    {
        var veiculo = await _context.Veiculos.
            FindAsync(idVeiculo);

        if (veiculo == null) return;

        _context.Remove(veiculo);
        await _context.SaveChangesAsync();

    }

    // <summary>
    /// Edita um veículo
    /// </summary>
    /// <param name="veículo"></param>
    /// <exception cref="ServiceException"></exception>
    public async Task Edit(Veiculo veiculo)
    {
        _context.Update(veiculo);

        await _context.SaveChangesAsync();
    }

    // <summary>
    /// busca um veículo 
    /// </summary>
    /// <param name="id do veículo ">dados do veículo</param>
    /// <returns></returns>
    public async Task<Veiculo> Get(uint idVeiculo)
    {
        return await _context.Veiculos.FindAsync(idVeiculo);
    }

    /// <summary>
    /// Obtém todos veículo
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Veiculo>> GetAll()
    {
        return await _context.Veiculos.ToListAsync();
    }
}
