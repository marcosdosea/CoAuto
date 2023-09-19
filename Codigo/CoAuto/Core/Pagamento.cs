namespace Core;

public partial class Pagamento
{
    public uint Id { get; set; }

    public float Valor { get; set; }

    public string FormaPagamento { get; set; } = null!;

    public uint IdAluguel { get; set; }

    public virtual Aluguel IdAluguelNavigation { get; set; } = null!;
}
