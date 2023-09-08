using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IVeiculoService
    {
        int Create(Veiculo veiculo);
        void Edit(Veiculo veiculo);
        void Delete(int idVeiculo);
        Veiculo Get(int idVeiculo);

        IEnumerable<Veiculo> GetAll();
        
        
       
    }
}
