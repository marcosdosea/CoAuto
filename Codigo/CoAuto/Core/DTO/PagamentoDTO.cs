using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class PagamentoDTO
    {
        public uint Id { get; set; }

        public float Valor { get; set; }

        public int IdAluguel { get; set; }

        public virtual Aluguel IdAluguelNavigation { get; set; } = null!;
    }
}
