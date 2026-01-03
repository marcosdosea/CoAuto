using System.ComponentModel.DataAnnotations;
namespace CoAutoWeb.Models
{
    public class AluguelCardListViewModel
    {
        public string Status { get; set; }

        public DateTime DataHoraAluguel { get; set; }

        public PagamentoCardListViewModel Pagamento { get; set; }

        public VeiculoCardListViewModel Veiculo { get; set; }

        public ModeloCardListViewModel Modelo { get; set; }

        
    }
}
