using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IAluguelService
    {
        int Create(Aluguel aluguel);
        void Edit(Aluguel aluguel);
        void Delete(int idAluguel);
        Aluguel Get(int idAluguel);

        IEnumerable<Aluguel> GetAll();



    }
}
