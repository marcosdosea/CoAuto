namespace Core;

public class SeedingService
{
    private readonly CoAutoContext _coAutoContext;

    public SeedingService(CoAutoContext coAutoContext)
    {
        _coAutoContext = coAutoContext;
    }

    public void Seed()
    {
        if (_coAutoContext.Marcas.Any())
            return;
        Marca m1 = new Marca { Id = 1, Nome = "Fiat" };
        Marca m2 = new Marca { Id = 2, Nome = "Tesla" };
        Marca m3 = new Marca { Id = 3, Nome = "Toyota" };
        Marca m4 = new Marca { Id = 4, Nome = "Honda" };
        Marca m5 = new Marca { Id = 5, Nome = "Mercedes-Benz" };
        Marca m6 = new Marca { Id = 6, Nome = "BMW" };
        Marca m7 = new Marca { Id = 7, Nome = "Audi" };
        Marca m8 = new Marca { Id = 8, Nome = "Ford" };
        Marca m9 = new Marca { Id = 9, Nome = "Chevrolet" };
        Marca m10 = new Marca { Id = 10, Nome = "Porsche" };
        Marca m11 = new Marca { Id = 11, Nome = "Volkswagen" };
        Marca m12 = new Marca { Id = 12, Nome = "Hyundai" };
        Marca m13 = new Marca { Id = 13, Nome = "Lexus" };
        Marca m14 = new Marca { Id = 14, Nome = "Volvo" };
        Marca m15 = new Marca { Id = 15, Nome = "Jeep" };
        Marca m16 = new Marca { Id = 16, Nome = "Subaru" };
        Marca m17 = new Marca { Id = 17, Nome = "Kia" };
        Marca m18 = new Marca { Id = 18, Nome = "Nissan" };
        Marca m19 = new Marca { Id = 19, Nome = "Mazda" };
        Marca m20 = new Marca { Id = 20, Nome = "Ferrari" };
        // Add mais marcas
        _coAutoContext.AddRange(m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16, m17, m18, m19, m20);
        _coAutoContext.SaveChanges();

        if (_coAutoContext.Modelos.Any())
            return;
        Modelo mo1 = new Modelo { Id = 1, Nome = "Toro", IdMarca = 1, IdMarcaNavigation = m1 };
        _coAutoContext.AddRange(mo1);
        _coAutoContext.SaveChanges();
        // Add mais modelos

        if (_coAutoContext.Bancos.Any())
            return;
        Banco b1 = new Banco { Id = 1, Nome = "Banco" };
        _coAutoContext.AddRange(b1);
        _coAutoContext.SaveChanges();
        // Add mais bancos

        if (_coAutoContext.Pessoas.Any())
            return;
        Pessoa p1 = new Pessoa
        {
            Id = 1,
            Nome = "Jordan",
            Email = "email@exemplo.com",
            Cnh = "123456789",
            Cpf = "12345678900",
            Senha = "senhaSecreta",
            DataNascimento = "01/01/1980",
            Telefone = "(11) 12345-6789",
            Cep = "12345678",
            Estado = "SP",
            Cidade = "São Paulo",
            Bairro = "Centro",
            Rua = "Rua Exemplo",
            Numero = "100",
            Agencia = "1234",
            ContaCorrente = "123456-7",
            Chavepix = "chave.pix@exemplo.com",
            DataAutorizacao = DateTime.Now,
            Autorizado = 1,
            Tipo = "cliente",
            IdBancoNavigation = b1,
            IdBanco = 1
        };
        _coAutoContext.AddRange(p1);
        _coAutoContext.SaveChanges();
        // Add mais pessoas

    }
}
