using System;
using System.Collections.Generic;

namespace Core;

public partial class Disponibilidade
{
    public uint Id { get; set; }

    public DateTime DataHoraInicio { get; set; }

    public DateTime DataHoraFim { get; set; }

    public uint IdVeiculo { get; set; }

    public virtual Veiculo IdVeiculoNavigation { get; set; } = null!;
}
