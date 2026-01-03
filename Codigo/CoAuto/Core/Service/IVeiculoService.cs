using Core.DTO;

namespace Core.Service;

public interface IVeiculoService
{
    uint Create(Veiculo veiculo);
    void Edit(Veiculo veiculo);
    void Delete(uint idVeiculo);
    Veiculo Get(uint idVeiculo);
    IEnumerable<Veiculo> GetAll();
    IEnumerable<VeiculosSimplesDTO> GetAllSimpleVeiculos();
}
