namespace Core.Service;

public interface IEntregaService
{
    Task<uint> Create(Entrega entrega);
    Task Edit(Entrega entrega);
    Task Delete(uint idEntrega);
    Task<Entrega> Get(uint idEntrega);
    Task<IEnumerable<Entrega>> GetAll();
}
