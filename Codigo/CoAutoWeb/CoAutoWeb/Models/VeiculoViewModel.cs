using Core;
using System.ComponentModel.DataAnnotations;

namespace CoAutoWeb.Models
{

    public class VeiculoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public String Tipo { get; set; } = null!;
        
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Ano")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "O número do ano deve ter 4 numeros.")]
        public string Ano { get; set; } = null!;
        
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Placa")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "O número da placa deve ter 7 caracteres.")]
        public string Placa { get; set; } = null!;

        [Required(ErrorMessage = "Campo requerido")]
        public string Crlv { get; set; } = null!;

        [Required(ErrorMessage = "Campo requerido")]
        public int? Cilindradas { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Valor Diaria")]
        [DataType(DataType.Currency, ErrorMessage = "Digite um valor válido")]
        public float Valor { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "CEP")]
        [DataType(DataType.PostalCode)]
        public string Cep { get; set; } = null!;

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Estado *")]
        [StringLength(2)]
        public string Estado { get; set; } = null!;

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Cidade *")]
        [StringLength(100, ErrorMessage = "Nome da cidade tem entre 3 e 100 letras", MinimumLength = 3)]
        public string Cidade { get; set; } = null!;

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Bairro *")]
        [StringLength(100, ErrorMessage = "Nome do bairro tem entre 3 e 100 letras", MinimumLength = 3)]
        public string Bairro { get; set; } = null!;

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Rua *")]
        [StringLength(100, ErrorMessage = "Nome da rua tem entre 3 e 100 letras", MinimumLength = 3)]
        public string Rua { get; set; } = null!;

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Número *")]
        [StringLength(6, ErrorMessage = "Numero da casa tem entre 1 e 6 digitos", MinimumLength = 1)]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int IdModelo { get; set; }

        public sbyte Autorizado { get; set; }

        public String? Portas { get; set; }

        public String Combustivel { get; set; } = null!;

        public String Cambio { get; set; } = null!;

        public String? Passageiro { get; set; }

        public String? Carroceria { get; set; }

        public uint IdPessoa { get; set; }

    }
}
