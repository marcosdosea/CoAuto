using System.ComponentModel.DataAnnotations;

namespace CoAutoWeb.Models
{
    public class PessoaModel
    {
        [Required(ErrorMessage = "Campo requerido")]
        public uint Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, ErrorMessage = "Nome deve ter no máximo 50 caracteres")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, ErrorMessage = "Email deve ter no máximo 50 caracteres")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, ErrorMessage = "CNH deve ter no máximo 45 caracteres")]
        public string Cnh { get; set; } = null!;

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(11, ErrorMessage = "CPF deve ter no máximo 11 caracteres")]
        public string Cpf { get; set; } = null!;

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, ErrorMessage = "Senha deve ter no máximo 50 caracteres")]
        public string Senha { get; set; } = null!;

        public byte[]? Fotocnh { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(10, ErrorMessage = "Data de Nascimento deve ter no máximo 10 caracteres")]
        public string DataNascimento { get; set; } = null!;

        [StringLength(23, ErrorMessage = "Telefone deve ter no máximo 23 caracteres")]
        public string Telefone { get; set; } = null!;

        public byte[]? Fotoperfil { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(8, ErrorMessage = "CEP deve ter no máximo 8 caracteres")]
        public string Cep { get; set; } = null!;

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, ErrorMessage = "Estado deve ter no máximo 50 caracteres")]
        public string Estado { get; set; } = null!;

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, ErrorMessage = "Cidade deve ter no máximo 50 caracteres")]
        public string Cidade { get; set; } = null!;

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, ErrorMessage = "Bairro deve ter no máximo 50 caracteres")]
        public string Bairro { get; set; } = null!;

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, ErrorMessage = "Rua deve ter no máximo 50 caracteres")]
        public string Rua { get; set; } = null!;

        [Display(Name = "Número")]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(10, ErrorMessage = "Número deve ter no máximo 10 caracteres")]
        public string Numero { get; set; } = null!;

        [StringLength(10, ErrorMessage = "Agência deve ter no máximo 10 caracteres")]
        public string? Agencia { get; set; }

        [Display(Name = "Conta Corrente")]
        [StringLength(10, ErrorMessage = "Conta Corrente deve ter no máximo 10 caracteres")]
        public string? ContaCorrente { get; set; }

        [Display(Name = "Chave Pix")]
        [StringLength(32, ErrorMessage = "Chave Pix deve ter no máximo 32 caracteres")]
        public string? Chavepix { get; set; }

        [Display(Name = "Data Autorização")] public DateTime DataAutorizacao { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public sbyte Autorizado { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string Tipo { get; set; } = null!;

        public uint IdBanco { get; set; }
    }
}