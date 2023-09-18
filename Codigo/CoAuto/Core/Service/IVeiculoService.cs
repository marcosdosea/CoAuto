namespace Core.Service;

public interface IVeiculoService
{
    Task<uint> Create(Veiculo veiculo);
    Task Edit(Veiculo veiculo);
    Task Delete(uint idVeiculo);
    Task<Veiculo> Get(uint idVeiculo);
    Task<IEnumerable<Veiculo>> GetAll();
}
