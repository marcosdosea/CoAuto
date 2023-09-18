namespace Core.Service;

public interface IMarcaService
{
    Task<uint> Create(Marca marca);
    Task Edit(Marca marca);
    Task Delete(uint idMarca);
    Task<Marca> Get(uint idMarca);
    Task<IEnumerable<Marca>> GetAll();
}
