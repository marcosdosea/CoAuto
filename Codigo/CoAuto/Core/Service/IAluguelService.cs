namespace Core.Service
{
    public interface IAluguelService
    {
        int Create(Aluguel aluguel);
        void Delete(int idaluguel);
        Aluguel Get(int id);
        IEnumerable<Aluguel> GetAll();
    }
}