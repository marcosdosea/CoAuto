using Core;
using Core.Service;

namespace Service

/// <summary>
/// Manter dados de pagamento no banco de dados
/// </summary>
{
    public class PagamentoService : IPagamentoService
    {
        private readonly CoAutoContext _context;

        public PagamentoService(CoAutoContext context)
        {
            _context = context;
        }
        // <summary>
        /// Insere um novo pagamento
        /// </summary>
        /// <param name="pagamento">dados de pagamento</param>
        /// <returns></returns>

        public int Create(Pagamento pagamento)
        {
            _context.Add(pagamento);
            _context.SaveChanges();
            return (int)pagamento.Id;
        }
        // <summary>
        /// Deleta um pagamento
        /// </summary>
        /// <param name="id do pagamento ">deleta o pagamento </param>
        /// <returns></returns>

        public void Delete(int idPagamento)
        {
            var _pagamento = _context.Pagamentos.Find(idPagamento);
            _context.Remove(_pagamento);
            _context.SaveChanges();
        }

        // <summary>
        /// Editar um pagamento
        /// </summary>
        /// <param name="pagamento"></param>
        /// <exception cref="ServiceException"></exception>

        public void Edit(Pagamento pagamento)
        {
            _context.Update(pagamento);
            _context.SaveChanges();
        }

        // <summary>
        /// busca um pagamento
        /// </summary>
        /// <param name="id do pagamento ">dados do pagamento</param>
        /// <returns></returns>

        public Pagamento Get(int idPagamento)
        {
            return _context.Pagamentos.Find(idPagamento);
        }

        /// <summary>
        /// Obtém todos pagamentos
        /// </summary>
        /// <returns></returns>

        public IEnumerable<Pagamento> GetAll()
        {
            return _context.Pagamentos;
        }
    }
}
