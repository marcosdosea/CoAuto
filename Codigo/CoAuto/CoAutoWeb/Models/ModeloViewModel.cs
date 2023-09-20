using System.ComponentModel.DataAnnotations;

namespace CoAutoWeb.Models;


public class ModeloViewModel
{

    [Key]
    public uint Id { get; set; }

    public uint IdMarca { get; set; }

    [Required(ErrorMessage = "Campo requerido")]
    [Display(Name = "Nome do modelo *")]
    public string Nome { get; set; } = null!;
}
