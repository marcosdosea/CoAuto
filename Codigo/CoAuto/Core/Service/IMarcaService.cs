using Core.DTO;

namespace Core.Service;
public interface IMarcaService
{
    uint Create(Marca marca);
    void Delete(uint id);
    void Edit(Marca marca);
    Marca Get(uint id);
    IEnumerable<Marca> GetAll();
    IEnumerable<MarcaDTO> GetByNome(string nome);

}