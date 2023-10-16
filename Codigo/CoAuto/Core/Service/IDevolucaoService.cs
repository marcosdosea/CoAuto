namespace Core.Service;

public interface IDevolucaoService
{
    uint Create(Devolucao devolucao);
    void Edit(Devolucao devolucao);
    void Delete(uint idDevolucao);
    Devolucao Get(uint idDevolucao);
    IEnumerable<Devolucao> GetAll();
}
