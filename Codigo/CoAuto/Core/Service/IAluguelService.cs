namespace Core.Service
{
    public interface IAluguelService
    {
        int Create(Aluguel aluguel);
        Aluguel Delete(int idAluguel);
        void Edit(Aluguel aluguel);
        Aluguel Get(int idAluguel);
        IEnumerable<Aluguel> GetAll();
    }
}