namespace Core.Service;
public interface IModeloService
{
    Task<uint> Create(Modelo modelo);
    Task Edit(Modelo modelo);
    Task Delete(uint idModelo);
    Task<Modelo> Get(uint idModelo);
    Task<IEnumerable<Modelo>> GetAll();
}
