using Core;
using Core.DTO;
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
    public uint Create(Veiculo veiculo)
    {
        _context.Add(veiculo);
        _context.SaveChanges();
        return veiculo.Id;
    }

    // <summary>
    /// Deleta um veículo
    /// </summary>
    /// <param name="id da veículo ">deleta o veículo </param>
    /// <returns></returns>
    public void Delete(uint idVeiculo)
    {
        var veiculo = _context.Veiculos.Find(idVeiculo);

        if (veiculo == null) return;

        _context.Remove(veiculo);
        _context.SaveChanges();

    }

    // <summary>
    /// Edita um veículo
    /// </summary>
    /// <param name="veículo"></param>
    /// <exception cref="ServiceException"></exception>
    public void Edit(Veiculo veiculo)
    {
        _context.Update(veiculo);
        _context.SaveChanges();
    }

    // <summary>
    /// busca um veículo 
    /// </summary>
    /// <param name="id do veículo ">dados do veículo</param>
    /// <returns></returns>
    public Veiculo Get(uint idVeiculo)
    {
        return _context.Veiculos.Find(idVeiculo);
    }

    /// <summary>
    /// Obtém todos veículo
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Veiculo> GetAll()
    {
        return _context.Veiculos
            .Include(v => v.IdModeloNavigation)
            .ToList();
    }

    public IEnumerable<VeiculosSimplesDTO> GetAllSimpleVeiculos()
    {
        var veiculos = _context.Veiculos
            .Select(v => new VeiculosSimplesDTO {
                Id = v.Id,
                NomeModelo = v.IdModeloNavigation.Nome,
                ImageUrl=v.ImageUrl,
                Ano = v.Ano,
                Placa = v.Placa,
                Valor = v.Valor,
                Estado = v.Estado,
                Cidade = v.Cidade,
                Bairro = v.Bairro,
                NomeMarca = v.IdModeloNavigation.IdMarcaNavigation.Nome
            })
            .ToList();


        return veiculos;
    }
}
