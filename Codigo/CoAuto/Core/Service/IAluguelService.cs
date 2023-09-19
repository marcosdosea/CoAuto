namespace Core.Service;

public interface IAluguelService
{
    Task<uint> Create(Aluguel aluguel);
    Task Edit(Aluguel aluguel);
    Task Delete(uint idAluguel);
    Task<Aluguel> Get(uint idAluguel);
    Task<IEnumerable<Aluguel>> GetAll();
}

