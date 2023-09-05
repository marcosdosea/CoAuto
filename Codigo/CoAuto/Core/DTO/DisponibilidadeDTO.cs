using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class DisponibilidadeDTO
    {
        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public TimeSpan HoraInicio { get; set; }

        public TimeSpan HoraFim { get; set; }

        public int IdVeiculo { get; set; }
    }
}
