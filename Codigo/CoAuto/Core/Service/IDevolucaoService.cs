namespace Core.Service;

public interface IDevolucaoService
{
    Task<int> Create(Devolucao devolucao);
    Task Edit(Devolucao devolucao);
    Task Delete(int idDevolucao);
    Task<Devolucao> Get(int idDevolucao);
    Task<IEnumerable<Devolucao>> GetAll();
}
