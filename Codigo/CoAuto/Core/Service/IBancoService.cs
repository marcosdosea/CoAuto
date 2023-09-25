namespace Core.Service;

public interface IBancoService
{
    Task<uint> Create(Banco banco);
    Task Edit(Banco banco);
    Task Delete(uint idBanco);
    Task<Banco> Get(uint idBanco);
    Task<IEnumerable<Banco>> GetAll();
}
