namespace Core.DTO
{
    public class VeiculoDTO
    {
        public string Tipo { get; set; } = null!;

        public string Ano { get; set; } = null!;

        public int? Cilindradas { get; set; }

        public float Valor { get; set; }

        public string Estado { get; set; } = null!;

        public string Cidade { get; set; } = null!;

        public string? Portas { get; set; }

        public int NomeModelo { get; set; }

        public string Combustivel { get; set; } = null!;

        public string Cambio { get; set; } = null!;

        public string? Passageiro { get; set; }

        public string? Carroceria { get; set; }

        public uint NomePessoa { get; set; }

        public virtual ICollection<Disponibilidade> Disponibilidades { get; set; } = new List<Disponibilidade>();

        public virtual Modelo NomeModeloNavigation { get; set; } = null!;

        public virtual Pessoa NomePessoaNavigation { get; set; } = null!;
    }
}
