using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Core;

namespace CoAutoWeb.Models
{
    public class AluguelViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public String DataHoraAluguel { get; set; } = null!;

        public uint IdPessoa { get; set; }

        public uint? IdAvaliacaoCliente { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
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
    }
}

