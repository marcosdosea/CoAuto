namespace Core;

public partial class Entrega
{
    public uint Id { get; set; }

    public byte[]? Foto1 { get; set; }

    public byte[]? Foto2 { get; set; }

    public byte[]? Foto3 { get; set; }

    public byte[]? Foto4 { get; set; }

    public byte[]? Foto5 { get; set; }

    public DateTime DataHora { get; set; }

    public virtual ICollection<Aluguel> Aluguels { get; set; } = new List<Aluguel>();
}
