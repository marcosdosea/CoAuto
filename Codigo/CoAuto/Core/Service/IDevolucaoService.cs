namespace Core.Service;

public interface IDevolucaoService
{
    Task<uint> Create(Devolucao devolucao);
    Task Edit(Devolucao devolucao);
    Task Delete(uint idDevolucao);
    Task<Devolucao> Get(uint idDevolucao);
    Task<IEnumerable<Devolucao>> GetAll();
}
