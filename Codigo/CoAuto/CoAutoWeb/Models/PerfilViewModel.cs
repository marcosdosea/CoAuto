namespace CoAutoWeb.Models
{
    public class PerfilViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Cnh { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Cep { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string Bairro { get; set; } = null!;
        public string Rua { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public bool possuiCadastro { get; set; }
        public List<AluguelCardListViewModel> Alugueis { get; set; } = new List<AluguelCardListViewModel>();
    }
}
