namespace Core;

public partial class Modelo
{
    public uint Id { get; set; }

    public uint IdMarca { get; set; }

    public string Nome { get; set; } = null!;

    public virtual Marca IdMarcaNavigation { get; set; } = null!;

    public virtual Veiculo? Veiculo { get; set; }
}
