using System.ComponentModel.DataAnnotations;

namespace CoAutoWeb.Models;

public class PessoaViewModel
{
    [Key]
    public uint Id { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [StringLength(50, ErrorMessage = "Nome deve ter no máximo 50 caracteres")]
    public string Nome { get; set; } = null!;

    [Required(ErrorMessage = "Campo requerido")]
    [StringLength(50, ErrorMessage = "Email deve ter no máximo 50 caracteres")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Campo requerido")]
    [StringLength(9, ErrorMessage = "CNH deve ter no máximo 9 caracteres")]
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
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [StringLength(14, ErrorMessage = "Telefone deve ter no máximo 14 caracteres")]
    public string Telefone { get; set; } = null!;

    public byte[]? Fotoperfil { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [StringLength(8, ErrorMessage = "CEP deve ter no máximo 8 caracteres")]
    public string Cep { get; set; } = null!;

    [Required(ErrorMessage = "Campo requerido")]
    [StringLength(2, ErrorMessage = "Estado deve ter no máximo 2 caracteres")]
    public string Estado { get; set; } = null!;

    [Required(ErrorMessage = "Campo requerido")]
    [StringLength(20, ErrorMessage = "Cidade deve ter no máximo 20 caracteres")]
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

    [Display(Name = "Data Autorização")]
    public DateTime? DataAutorizacao { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    public sbyte Autorizado { get; set; } = 0;

    [Required(ErrorMessage = "Campo requerido")]
    public string Tipo { get; set; } = "cliente";

    [Required(ErrorMessage = "Campo requerido")]
    public uint IdBanco { get; set; }
}