namespace Core.DTO
{
    public class AluguelDTO
    {

        public string DataHoraAluguel { get; set; } = null!;

        public string Status { get; set; } = null!;

        public byte? QtdEstrelasAvaliacaoProprietario { get; set; }

        public virtual Veiculo Valor { get; set; } = null!;

        public virtual Veiculo Estado { get; set; } = null!;

        public virtual Veiculo Cidade { get; set; } = null!;

        public virtual Veiculo Bairro { get; set; } = null!;

        public virtual Veiculo Rua { get; set; } = null!;

        public virtual Veiculo Numero { get; set; } = null!;

        public virtual Veiculo Combustivel { get; set; } = null!;

        public virtual Veiculo Cambio { get; set; } = null!;

        public virtual Veiculo Carroceria { get; set; } = null!;

        public virtual Veiculo Cilindradas { get; set; } = null!;

        public virtual Veiculo Passageiro { get; set; } = null!;

        public virtual Modelo NomeModeloNavigation { get; set; } = null!;

        public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
    }
}
