    using System;
using System.Collections.Generic;

namespace Core;

public partial class Aluguel
{
    public uint Id { get; set; }

    public DateTime DataHoraAluguel { get; set; }

    public uint IdPessoa { get; set; }

    public string Status { get; set; } = null!;

    public uint IdVeiculo { get; set; }

    public DateTime? DataHoraAvaliacaoProprietario { get; set; }

    public byte? QtdEstrelasAvaliacaoProprietario { get; set; }

    public DateTime? DataHoraAvaliacaoCliente { get; set; }

    public byte? QtdEstrelasAvaliacaoCliente { get; set; }

    public string? DescricaoAvaliacaoProprietario { get; set; }

    public string? DescricaoAvaliacaoCliente { get; set; }

    public uint? IdEntrega { get; set; }

    public uint? IdDevolucao { get; set; }

    public virtual Devolucao? IdDevolucaoNavigation { get; set; }

    public virtual Entrega? IdEntregaNavigation { get; set; }

    public virtual Pessoa IdPessoaNavigation { get; set; } = null!;

    public virtual Veiculo IdVeiculoNavigation { get; set; } = null!;

    public virtual Pagamento? Pagamento { get; set; }
}
