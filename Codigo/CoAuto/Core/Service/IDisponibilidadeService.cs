using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IDisponibilidadeService
    {
        int Create(Disponibilidade disponibilidade);

        void Editar(Disponibilidade disponibilidade);

        void Delete(int iddisponibilidade);

        Disponibilidade Get(int id);

        IEnumerable<Disponibilidade> GetAll();


    }
}
