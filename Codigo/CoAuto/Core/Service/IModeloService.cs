using Core.DTO;

namespace Core.Service;
public interface IModeloService
{
    uint Create(Modelo modelo);
    void Delete(uint id);
    void Edit(Modelo modelo);
    Modelo Get(uint id);
    IEnumerable<Modelo> GetAll();
    IEnumerable<ModeloDTO> GetByNome(string nome);

}
