namespace Core.Service;

public interface IVeiculoService
{
    Task<int> Create(Veiculo veiculo);
    Task Edit(Veiculo veiculo);
    Task Delete(int idVeiculo);
    Task<Veiculo> Get(int idVeiculo);
    Task<IEnumerable<Veiculo>> GetAll();
}
