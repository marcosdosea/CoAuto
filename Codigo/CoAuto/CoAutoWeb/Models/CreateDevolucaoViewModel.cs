using System.ComponentModel.DataAnnotations;

namespace CoAutoWeb.Models;

public class CreateDevolucaoViewModel
{
    [Key]
    public uint Id { get; set; }

    [Display(Name = "Data e Hora")]
    [DataType(DataType.DateTime, ErrorMessage = "Data e Hora válida requerida")]
    [Required(ErrorMessage = "Data e Hora são obrigatórias")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime DataHora { get; set; }

    public IFormFile? Foto1 { get; set; }

    public IFormFile? Foto2 { get; set; }

    public IFormFile? Foto3 { get; set; }

    public IFormFile? Foto4 { get; set; }

    public IFormFile? Foto5 { get; set; }
}
