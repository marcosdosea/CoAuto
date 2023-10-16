namespace Core.Service;

public interface IEntregaService
{
    uint Create(Entrega entrega);
    void Edit(Entrega entrega);
    void Delete(uint idEntrega);
    Entrega Get(uint idEntrega);
    IEnumerable<Entrega> GetAll();
}
