namespace Core.Service;

public interface IPessoaService
{
    int Create(Pessoa pessoa);
    void Edit(Pessoa pessoa);
    void Delete(int id);
    Pessoa Get(int id);
    IEnumerable<Pessoa> GetAll();
}