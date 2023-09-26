namespace Core.Service;
public interface IPagamentoService
{
    uint Create(Pagamento pagamento);
    void Edit(Pagamento pagamento);
    void Delete(uint idPagamento);
    Pagamento Get(uint id);
    IEnumerable<Pagamento> GetAll();
}
