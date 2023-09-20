namespace Core.Service;

public interface IDisponibilidadeService
{
    int Create(Disponibilidade disponibilidade);
    void Edit(Disponibilidade disponibilidade);
    void Delete(int iddisponibilidade);
    Disponibilidade Get(int id);
    IEnumerable<Disponibilidade> GetAll();
}
