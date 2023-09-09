using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Service
{
    public interface IPagamentoService
    {
        int Create(Pagamento pagamento);
        void Edit(Pagamento pagamento);
        void Delete(int idPagamento);
        Pagamento Get(int id);

        IEnumerable<Pagamento> GetAll(); 
    }
}
