using System.ComponentModel.DataAnnotations;

namespace CoAutoWeb.Models;

public class EntregaViewModel
{
    [Key]
    public uint Id { get; set; }

    [Display(Name = "Data e Hora")]
    [DataType(DataType.DateTime, ErrorMessage = "Data e Hora válida requerida")]
    [Required(ErrorMessage = "Data e Hora são obrigatórias")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime DataHora { get; set; }

    public byte[]? Foto1 { get; set; }

    public byte[]? Foto2 { get; set; }

    public byte[]? Foto3 { get; set; }

    public byte[]? Foto4 { get; set; }

    public byte[]? Foto5 { get; set; }
}
