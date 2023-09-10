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
        Marca marca1 = new Marca { Id = 1, Nome = "Fiat" };
        Marca marca2 = new Marca { Id = 2, Nome = "Tesla" };
        Marca marca3 = new Marca { Id = 3, Nome = "Toyota" };
        Marca marca4 = new Marca { Id = 4, Nome = "Honda" };
        Marca marca5 = new Marca { Id = 5, Nome = "Mercedes-Benz" };
        Marca marca6 = new Marca { Id = 6, Nome = "BMW" };
        Marca marca7 = new Marca { Id = 7, Nome = "Audi" };
        Marca marca8 = new Marca { Id = 8, Nome = "Ford" };
        Marca marca9 = new Marca { Id = 9, Nome = "Chevrolet" };
        Marca marca10 = new Marca { Id = 10, Nome = "Porsche" };
        Marca marca11 = new Marca { Id = 11, Nome = "Volkswagen" };
        Marca marca12 = new Marca { Id = 12, Nome = "Hyundai" };
        Marca marca13 = new Marca { Id = 13, Nome = "Lexus" };
        Marca marca14 = new Marca { Id = 14, Nome = "Volvo" };
        Marca marca15 = new Marca { Id = 15, Nome = "Jeep" };
        Marca marca16 = new Marca { Id = 16, Nome = "Subaru" };
        Marca marca17 = new Marca { Id = 17, Nome = "Kia" };
        Marca marca18 = new Marca { Id = 18, Nome = "Nissan" };
        Marca marca19 = new Marca { Id = 19, Nome = "Mazda" };
        Marca marca20 = new Marca { Id = 20, Nome = "Ferrari" };
        // Add mais marcas
        _coAutoContext.AddRange(marca1, marca2, marca3, marca4, marca5, marca6, marca7, marca8, marca9, marca10, marca11, marca12, marca13, marca14, marca15, marca16, marca17, marca18, marca19, marca20);
        _coAutoContext.SaveChanges();

        if (_coAutoContext.Modelos.Any())
            return;
        Modelo modelo1 = new Modelo { Id = 1, Nome = "Toro", IdMarca = 1, IdMarcaNavigation = marca1 };
        _coAutoContext.AddRange(modelo1);
        _coAutoContext.SaveChanges();
        // Add mais modelos

        if (_coAutoContext.Bancos.Any())
            return;
        Banco banco1 = new Banco { Id = 1, Nome = "Banco" };
        _coAutoContext.AddRange(banco1);
        _coAutoContext.SaveChanges();
        // Add mais bancos

        if (_coAutoContext.Pessoas.Any())
            return;
        Pessoa pessoa1 = new Pessoa
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
            IdBancoNavigation = banco1,
            IdBanco = 1
        };
        _coAutoContext.AddRange(pessoa1);
        _coAutoContext.SaveChanges();
        // Add mais pessoas

        if (_coAutoContext.Veiculos.Any())
            return;
        Veiculo veiculo1 = new Veiculo
        {
            Id = 2,
            Tipo = "Carro",
            Valor = 150,
            Crlv = "crlv",
            Placa = "abc123",
            Ano = "2020",
            Autorizado = 1,
            Cep = "12345678",
            Estado = "SE",
            Cidade = "Itabaiana",
            Bairro = "Serrano",
            Rua = "Av Manoel Francisco Teles",
            Numero = 319,
            IdModeloNavigation = modelo1,
            IdModelo = 1,
            IdPessoaNavigation = pessoa1,
            IdPessoa = 1,
            Combustivel = "Gasolina",
            Cambio = "Manual"   
        };
        _coAutoContext.AddRange(veiculo1);
        _coAutoContext.SaveChanges();
        // Add mais pessoas

        if (_coAutoContext.Disponibilidades.Any())
            return;
        Disponibilidade disponibilidade1 = new Disponibilidade
        {
            Id = 1,
            DataInicio = DateTime.Now,
            DataFim = DateTime.Now,
            HoraInicio = TimeSpan.MinValue,
            HoraFim = TimeSpan.MaxValue,
            IdVeiculoNavigation = veiculo1,
            IdVeiculo = 2 
        };
        _coAutoContext.AddRange(disponibilidade1);
        _coAutoContext.SaveChanges();
        // Add mais disponiblidades

        if (_coAutoContext.Entregas.Any())
            return;
        Entrega entrega1 = new Entrega 
        { 
            Id = 1,
            DataHora = DateTime.Now
        };
        _coAutoContext.AddRange(entrega1);
        _coAutoContext.SaveChanges();
        // Add mais entregas

        if (_coAutoContext.Devolucaos.Any())
            return;
        Devolucao devolucao1 = new Devolucao
        {
            Id = 1,
            DataHora = DateTime.Now
        };
        _coAutoContext.AddRange(devolucao1);
        _coAutoContext.SaveChanges();
        // Add mais devoluções

        if (_coAutoContext.Aluguels.Any())
            return;
        Aluguel aluguel1 = new Aluguel
        {
            Id = 2,
            Status = "Alugado",
            DataAvaliacaoCliente = DateTime.Now,
            DataAvaliacaoProprietario = DateTime.Now,
            DataHoraAluguel = "2001/01/02 00:00",
            IdVeiculoNavigation = veiculo1,
            IdVeiculo = 2,
            IdPessoaNavigation = pessoa1,
            IdPessoa = 1,
            IdDevolucaoNavigation = devolucao1,
            IdDevolucao = 1,
            IdEntregaNavigation = entrega1,
            IdEntrega = 1,
            IdAvaliacaoCliente = 2
        };
        _coAutoContext.AddRange(aluguel1);
        _coAutoContext.SaveChanges();
        //Add mais alugueis

        if (_coAutoContext.Pagamentos.Any())
            return;
        Pagamento pagamento1 = new Pagamento
        {
            Id = 1,
            FormaPagamento = "Pix",
            Valor = 150,
            IdAluguelNavigation = aluguel1,
            IdAluguel = 2
        };
    }
}
