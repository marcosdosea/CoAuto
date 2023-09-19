namespace Core;

public partial class Marca
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual Modelo? Modelo { get; set; }
}
