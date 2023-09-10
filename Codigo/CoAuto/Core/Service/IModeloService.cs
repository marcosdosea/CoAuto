namespace Core.Service;

public interface IModeloService
{
    Task<int> Create(Modelo modelo);
    Task Edit(Modelo modelo);
    Task Delete(int idModelo);
    Task<Modelo> Get(int idModelo);
    Task<IEnumerable<Modelo>> GetAll();
}
