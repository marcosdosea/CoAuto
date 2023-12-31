﻿using System;
using System.Collections.Generic;

namespace Core;

public partial class Pessoa
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Cnh { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public byte[]? Fotocnh { get; set; }

    public DateTime DataNascimento { get; set; }

    public string Telefone { get; set; } = null!;

    public byte[]? Fotoperfil { get; set; }

    public string Cep { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public string Bairro { get; set; } = null!;

    public string Rua { get; set; } = null!;

    public string Numero { get; set; } = null!;

    public string? Agencia { get; set; }

    public string? ContaCorrente { get; set; }

    public string? Chavepix { get; set; }

    public DateTime? DataAutorizacao { get; set; }

    public sbyte Autorizado { get; set; }

    public string Tipo { get; set; } = null!;

    public uint? IdBanco { get; set; }

    public virtual Aluguel? Aluguel { get; set; }

    public virtual Banco? IdBancoNavigation { get; set; }

    public virtual Veiculo? Veiculo { get; set; }
}
