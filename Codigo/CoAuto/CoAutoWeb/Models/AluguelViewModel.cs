using System.ComponentModel.DataAnnotations;

namespace CoAutoWeb.Models;

public class AluguelViewModel
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Data e Hora")]
    [DataType(DataType.DateTime, ErrorMessage = "Data e Hora válida requerida")]
    [Required(ErrorMessage = "Data e Hora são obrigatórias")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
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

