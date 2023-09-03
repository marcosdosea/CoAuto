using System;
using System.Collections.Generic;

namespace Core;

public partial class Veiculo
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public string Ano { get; set; } = null!;

    public string Placa { get; set; } = null!;

    public string Crlv { get; set; } = null!;

    public int? Cilindradas { get; set; }

    public float Valor { get; set; }

    public string Cep { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public string Bairro { get; set; } = null!;

    public string Rua { get; set; } = null!;

    public int Numero { get; set; }

    public DateTime DataAutorizacao { get; set; }

    public string? Portas { get; set; }

    public sbyte Autorizado { get; set; }

    public int IdModelo { get; set; }

    public string Combustivel { get; set; } = null!;

    public string Cambio { get; set; } = null!;

    public string? Passageiro { get; set; }

    public string? Carroceria { get; set; }

    public uint IdPessoa { get; set; }

    public virtual ICollection<Aluguel> Aluguels { get; set; } = new List<Aluguel>();

    public virtual ICollection<Disponibilidade> Disponibilidades { get; set; } = new List<Disponibilidade>();

    public virtual Modelo IdModeloNavigation { get; set; } = null!;

    public virtual Pessoa IdPessoaNavigation { get; set; } = null!;
}
