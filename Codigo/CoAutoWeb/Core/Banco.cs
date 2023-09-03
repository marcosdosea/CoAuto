using System;
using System.Collections.Generic;

namespace Core;

public partial class Banco
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Pessoa> Pessoas { get; set; } = new List<Pessoa>();
}
