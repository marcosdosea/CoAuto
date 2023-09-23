namespace Core.Service;

public interface IDisponibilidadeService
{
    uint Create(Disponibilidade disponibilidade);
    void Edit(Disponibilidade disponibilidade);
    void Delete(uint iddisponibilidade);
    Disponibilidade Get(uint id);
    IEnumerable<Disponibilidade> GetAll();
}
