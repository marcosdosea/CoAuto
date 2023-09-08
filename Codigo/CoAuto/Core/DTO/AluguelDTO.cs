namespace Core.DTO;

public class AluguelDTO
{
    public int Id { get; set; }

    public string DataHoraAluguel { get; set; } = null!;

    public uint IdPessoa { get; set; }

    public int IdVeiculo { get; set; }

    public string Status { get; set; } = null!;
}
