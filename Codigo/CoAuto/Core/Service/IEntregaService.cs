namespace Core.Service;

public interface IEntregaService
{
    Task<int> Create(Entrega entrega);
    Task Edit(Entrega entrega);
    Task Delete(int idEntrega);
    Task<Entrega> Get(int idEntrega);
    Task<IEnumerable<Entrega>> GetAll();
}
