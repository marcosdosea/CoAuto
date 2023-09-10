namespace Core.Service;

public interface IMarcaService
{
    Task<int> Create(Marca marca);
    Task Edit(Marca marca);
    Task Delete(int idMarca);
    Task<Marca> Get(int idMarca);
    Task<IEnumerable<Marca>> GetAll();
}
