namespace Core.Service
{
    public interface IAluguelService
    {
        int Create(Aluguel aluguel);
        void Edit(Aluguel aluguel);
        void Delete(int idAluguel);
        Aluguel Get(int idAluguel);

        IEnumerable<Aluguel> GetAll();



    }
}
