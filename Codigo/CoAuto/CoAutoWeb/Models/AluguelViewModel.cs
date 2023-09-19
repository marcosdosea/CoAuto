using System.ComponentModel.DataAnnotations;

namespace CoAutoWeb.Models;

public class AluguelViewModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    public DateTime DataHoraAluguel { get; set; }

    public uint IdPessoa { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    public string Status { get; set; } = null!;

    public uint IdVeiculo { get; set; }

    public DateTime? DataHoraAvaliacaoProprietario { get; set; }

    public byte? QtdEstrelasAvaliacaoProprietario { get; set; }

    public DateTime? DataHoraAvaliacaoCliente { get; set; }

    public sbyte? QtdEstrelasAvaliacaoCliente { get; set; }

    public string? DescricaoAvaliacaoProprietario { get; set; }

    public string? DescricaoAvaliacaoCliente { get; set; }

    public uint? IdEntrega { get; set; }

    public uint? IdDevolucao { get; set; }
}

