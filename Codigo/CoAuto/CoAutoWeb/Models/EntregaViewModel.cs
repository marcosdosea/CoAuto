using System.ComponentModel.DataAnnotations;

namespace CoAutoWeb.Models;

public class EntregaViewModel
{
    [Key]
    public int Id { get; set; }

    public DateTime DataHora { get; set; }

    public byte[]? Foto1 { get; set; }

    public byte[]? Foto2 { get; set; }

    public byte[]? Foto3 { get; set; }

    public byte[]? Foto4 { get; set; }

    public byte[]? Foto5 { get; set; }
}
