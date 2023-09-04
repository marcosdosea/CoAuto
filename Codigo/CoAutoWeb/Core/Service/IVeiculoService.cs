using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IVeiculoService
    {
        int create(Veiculo veiculo);
        void edit(Veiculo veiculo);
        void delete(Veiculo veiculo);
        Veiculo get(int idVeiculo);

        IEnumerable<Veiculo> getAll();
        
        
       
    }
}
