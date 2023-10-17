using System.ComponentModel.DataAnnotations;

namespace CoAutoAPI.Models;

public class PagamentoViewModel
{
    [Key]
    public uint Id { get; set; }

    public float Valor { get; set; }

    [Required(ErrorMessage = "A Forma de pagamento é obrigatória")]
    public string FormaPagamento { get; set; } = null!;

    public uint IdAluguel { get; set; }

}
