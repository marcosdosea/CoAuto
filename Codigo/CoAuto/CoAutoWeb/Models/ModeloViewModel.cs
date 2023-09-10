using System.ComponentModel.DataAnnotations;

namespace CoAutoWeb.Models
{

    public class ModeloViewModel
    {

        [Key]
        public int Id { get; set; }

        public int IdMarca { get; set; }

        public string? Marca { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Nome do modelo *")]
        public string Nome { get; set; } = null!;
    }
}
