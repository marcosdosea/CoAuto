namespace Core.DTO;

public class AluguelDTO
{
    public int Id { get; set; }
    public DateTime DataHoraAluguel { get; set; }
    public string Status { get; set; } = null!;
}
