namespace Core.Service;

public interface IAluguelService
{
    Task<int> Create(Aluguel aluguel);
    Task Edit(Aluguel aluguel);
    Task Delete(int idAluguel);
    Task<Aluguel> Get(int idAluguel);
    Task<IEnumerable<Aluguel>> GetAll();
}

