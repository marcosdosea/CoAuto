using System;
using System.Collections.Generic;

namespace Core;

public partial class Disponibilidade
{
    public uint Id { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime DataFim { get; set; }

    public TimeSpan HoraInicio { get; set; }

    public TimeSpan HoraFim { get; set; }

    public int IdVeiculo { get; set; }

    public virtual Veiculo IdVeiculoNavigation { get; set; } = null!;
}
