using System;
using System.Collections.Generic;

namespace Core;

public partial class Modelo
{
    public int Id { get; set; }

    public int IdMarca { get; set; }

    public string Nome { get; set; } = null!;

    public virtual Marca IdMarcaNavigation { get; set; } = null!;
}
