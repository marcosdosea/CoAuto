namespace Core.Service;

public interface IAluguelService
{
    uint Create(Aluguel aluguel);
    void Delete(uint id);
    void Edit(Aluguel aluguel);
    Aluguel Get(uint id);
    IEnumerable<Aluguel> GetAll();
}

