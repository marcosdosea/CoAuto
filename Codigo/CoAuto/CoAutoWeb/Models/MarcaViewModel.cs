using System.ComponentModel.DataAnnotations;

namespace CoAutoWeb.Models
{
    public class MarcaViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Nome *")]
        public string Nome { get; set; } = null!;
    }
}
