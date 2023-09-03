using System;
using System.Collections.Generic;

namespace Core;

public partial class Aluguel
{
    public int Id { get; set; }

    public string DataHoraAluguel { get; set; } = null!;

    public uint IdPessoa { get; set; }

    public uint? IdAvaliacaoCliente { get; set; }

    public string Status { get; set; } = null!;

    public int IdVeiculo { get; set; }

    public DateTime? DataAvaliacaoProprietario { get; set; }

    public byte? QtdEstrelasAvaliacaoProprietario { get; set; }

    public DateTime? DataAvaliacaoCliente { get; set; }

    public sbyte? QtdEstrelasAvaliacaoCliente { get; set; }

    public string? DescricaoAvaliacaoProprietario { get; set; }

    public string? DescricaoAvaliacaoCliente { get; set; }

    public uint? IdEntrega { get; set; }

    public uint? IdDevolucao { get; set; }

    public virtual Devolucao? IdDevolucaoNavigation { get; set; }

    public virtual Entrega? IdEntregaNavigation { get; set; }

    public virtual Pessoa IdPessoaNavigation { get; set; } = null!;

    public virtual Veiculo IdVeiculoNavigation { get; set; } = null!;

    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
}
