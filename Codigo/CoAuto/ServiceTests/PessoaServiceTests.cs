using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization;
using System.Security.Cryptography;

namespace Service.Tests
{
    [TestClass()]
    public class PessoaServiceTests
    {
        private CoAutoContext _context;
        private IPessoaService _pessoaService;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<CoAutoContext>();
            builder.UseInMemoryDatabase("coauto");
            var options = builder.Options;

            _context = new CoAutoContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var pessoas = new List<Pessoa>
                {
                    new Pessoa
                    {
                        Id = 1,
                        Nome = "Alice Johnson",
                        Email = "alice.johnson@example.com",
                        Cnh = "987654321",
                        Cpf = "12345678901",
                        Senha = "senhaAleatoria",
                        DataNascimento = new DateTime(1995, 07, 12),
                        Telefone = "(11)987654321",
                        Cep = "04567-890",
                        Estado = "SP",
                        Cidade = "São Paulo",
                        Bairro = "Vila Exemplo",
                        Rua = "Rua da Amostra",
                        Numero = "123",
                        Agencia = "5678",
                        ContaCorrente = "987654-3",
                        Chavepix = "alice.pix@example.com",
                        DataAutorizacao = new DateTime(2021, 09, 2, 3, 30, 0),
                        Autorizado = 1,
                        Tipo = "cliente",
                        IdBanco = 1
                    },
                    new Pessoa
                    {
                        Id = 2,
                        Nome = "João Silva",
                        Email = "joao.silva@example.com",
                        Cnh = "123456789",
                        Cpf = "98765432109",
                        Senha = "outraSenha",
                        DataNascimento = new DateTime(1980, 03, 15),
                        Telefone = "(11)98765-1234",
                        Cep = "09876543",
                        Estado = "RJ",
                        Cidade = "Rio de Janeiro",
                        Bairro = "Copacabana",
                        Rua = "Avenida Principal",
                        Numero = "456",
                        Agencia = "7890",
                        ContaCorrente = "543210-1",
                        Chavepix = "joao.pix@example.com",
                        DataAutorizacao = new DateTime(2022, 05, 4, 21, 30, 0),
                        Autorizado = 1,
                        Tipo = "cliente",
                        IdBanco = 1
                    },
                    new Pessoa
                    {
                        Id = 3,
                        Nome = "Maria Santos",
                        Email = "maria.santos@example.com",
                        Cnh = "543210987",
                        Cpf = "98765432112",
                        Senha = "outraSenha2",
                        DataNascimento = new DateTime(1990, 08, 25),
                        Telefone = "(21)98765-5678",
                        Cep = "03210654",
                        Estado = "RJ",
                        Cidade = "Rio de Janeiro",
                        Bairro = "Ipanema",
                        Rua = "Rua da Praia",
                        Numero = "789",
                        Agencia = "4567",
                        ContaCorrente = "321987-0",
                        Chavepix = "maria.pix@example.com",
                        DataAutorizacao = new DateTime(2023, 02, 1, 13, 00, 0),
                        Autorizado = 1,
                        Tipo = "cliente",
                        IdBanco = 1
                    },
                };

            _context.AddRange(pessoas);
            _context.SaveChanges();

            _pessoaService = new PessoaService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
             _pessoaService.Create(new Pessoa()
            {
                Id = 4,
                Nome = "Carlos",
                Email = "carlos@example.com",
                Cnh = "123456789",
                Cpf = "98765432109",
                Senha = "outraSenhaAleatoria",
                DataNascimento = new DateTime(1988, 05, 20),
                Telefone = "(11)98765-6789",
                Cep = "01234567",
                Estado = "SP",
                Cidade = "São Paulo",
                Bairro = "Vila Novidade",
                Rua = "Avenida das Ideias",
                Numero = "456",
                Agencia = "1234",
                ContaCorrente = "123456-7",
                Chavepix = "carlos.pix@example.com",
                DataAutorizacao = new DateTime(2023, 02, 1, 23, 30, 0),
                Autorizado = 1,
                Tipo = "cliente",
                IdBanco = 1
            });
            // Assert
            Assert.AreEqual(4, _pessoaService.GetAll().Count());
            var pessoa = _pessoaService.Get(4);
            Assert.AreEqual("Carlos", pessoa.Nome);
            Assert.AreEqual(DateTime.Parse("1988-05-20"), pessoa.DataNascimento);
            Assert.AreEqual("carlos@example.com", pessoa.Email);
            Assert.AreEqual("123456789", pessoa.Cnh);
            Assert.AreEqual("98765432109", pessoa.Cpf);
            Assert.AreEqual("outraSenhaAleatoria", pessoa.Senha);
            Assert.AreEqual("(11)98765-6789", pessoa.Telefone);
            Assert.AreEqual("01234567", pessoa.Cep);
            Assert.AreEqual("SP", pessoa.Estado);
            Assert.AreEqual("São Paulo", pessoa.Cidade);
            Assert.AreEqual("Vila Novidade", pessoa.Bairro);
            Assert.AreEqual("Avenida das Ideias", pessoa.Rua);
            Assert.AreEqual("456", pessoa.Numero);
            Assert.AreEqual("1234", pessoa.Agencia);
            Assert.AreEqual("123456-7", pessoa.ContaCorrente);
            Assert.AreEqual("carlos.pix@example.com", pessoa.Chavepix);
            Assert.AreEqual(DateTime.Parse("2023-02-01 23:30:00"), pessoa.DataAutorizacao);
            Assert.AreEqual(1, pessoa.Autorizado);
            Assert.AreEqual("cliente", pessoa.Tipo);
            Assert.AreEqual((uint)1, pessoa.IdBanco);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            _pessoaService.Delete(1);
            // Assert
            Assert.AreEqual(2, _pessoaService.GetAll().Count());
            var pessoa = _pessoaService.Get(1);
            Assert.AreEqual(null, pessoa);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var pessoa = _pessoaService.Get(3);
            pessoa.Nome = "Eduardo";
            pessoa.Email = "eduardo@example.com";
            pessoa.Cnh = "9876543210";
            pessoa.Cpf = "09876543210";
            pessoa.Senha = "outraSenhaAleatoria2";
            pessoa.DataNascimento = new DateTime(1990, 10, 15);
            pessoa.Telefone = "(11)98765-9876";
            pessoa.Cep = "05678901";
            pessoa.Estado = "SP";
            pessoa.Cidade = "São Paulo";
            pessoa.Bairro = "Vila Nova";
            pessoa.Rua = "Rua das Novidades";
            pessoa.Numero = "789";
            pessoa.Agencia = "4321";
            pessoa.ContaCorrente = "987654-1";
            pessoa.Chavepix = "eduardo.pix@example.com";
            pessoa.DataAutorizacao = new DateTime(2022, 12, 20, 11, 35, 0);
            pessoa.Autorizado = 1;
            pessoa.Tipo = "cliente";
            pessoa.IdBanco = 1;
            _pessoaService.Edit(pessoa);
            //Assert
            pessoa = _pessoaService.Get(3);
            Assert.AreEqual("Eduardo", pessoa.Nome);
            Assert.AreEqual("eduardo@example.com", pessoa.Email);
            Assert.AreEqual("9876543210", pessoa.Cnh);
            Assert.AreEqual("09876543210", pessoa.Cpf);
            Assert.AreEqual("outraSenhaAleatoria2", pessoa.Senha);
            Assert.AreEqual(new DateTime(1990, 10, 15), pessoa.DataNascimento);
            Assert.AreEqual("(11)98765-9876", pessoa.Telefone);
            Assert.AreEqual("05678901", pessoa.Cep);
            Assert.AreEqual("SP", pessoa.Estado);
            Assert.AreEqual("São Paulo", pessoa.Cidade);
            Assert.AreEqual("Vila Nova", pessoa.Bairro);
            Assert.AreEqual("Rua das Novidades", pessoa.Rua);
            Assert.AreEqual("789", pessoa.Numero);
            Assert.AreEqual("4321", pessoa.Agencia);
            Assert.AreEqual("987654-1", pessoa.ContaCorrente);
            Assert.AreEqual("eduardo.pix@example.com", pessoa.Chavepix);
            Assert.AreEqual(DateTime.Parse("2022-12-20 11:35:00"), pessoa.DataAutorizacao);
            Assert.AreEqual(1, pessoa.Autorizado);
            Assert.AreEqual("cliente", pessoa.Tipo);
            Assert.AreEqual((uint)1, pessoa.IdBanco);
        }

        [TestMethod()]
        public void GetTest()
        {
            var pessoa = _pessoaService.Get(3);
            Assert.IsNotNull(pessoa);
            Assert.AreEqual("Maria Santos", pessoa.Nome);
            Assert.AreEqual(DateTime.Parse("1990-08-25"), pessoa.DataNascimento);
            Assert.AreEqual("maria.santos@example.com", pessoa.Email);
            Assert.AreEqual("543210987", pessoa.Cnh);
            Assert.AreEqual("98765432112", pessoa.Cpf);
            Assert.AreEqual("outraSenha2", pessoa.Senha);
            Assert.AreEqual("(21)98765-5678", pessoa.Telefone);
            Assert.AreEqual("03210654", pessoa.Cep);
            Assert.AreEqual("RJ", pessoa.Estado);
            Assert.AreEqual("Rio de Janeiro", pessoa.Cidade);
            Assert.AreEqual("Ipanema", pessoa.Bairro);
            Assert.AreEqual("Rua da Praia", pessoa.Rua);
            Assert.AreEqual("789", pessoa.Numero);
            Assert.AreEqual("4567", pessoa.Agencia);
            Assert.AreEqual("321987-0", pessoa.ContaCorrente);
            Assert.AreEqual("maria.pix@example.com", pessoa.Chavepix);
            Assert.AreEqual(DateTime.Parse("2023-02-01 13:00:00"), pessoa.DataAutorizacao);
            Assert.AreEqual(1, pessoa.Autorizado);
            Assert.AreEqual("cliente", pessoa.Tipo);
            Assert.AreEqual((uint)1, pessoa.IdBanco);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaPessoa = _pessoaService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaPessoa, typeof(IEnumerable<Pessoa>));
            Assert.IsNotNull(listaPessoa);
            Assert.AreEqual(3, listaPessoa.Count());
            var firstPerson = listaPessoa.First();
            Assert.AreEqual((uint)1, firstPerson.Id);
            Assert.AreEqual("Alice Johnson", firstPerson.Nome);
            Assert.AreEqual("alice.johnson@example.com", firstPerson.Email);
            Assert.AreEqual("987654321", firstPerson.Cnh);
            Assert.AreEqual("12345678901", firstPerson.Cpf);
            Assert.AreEqual("senhaAleatoria", firstPerson.Senha);
            Assert.AreEqual(new DateTime(1995, 07, 12), firstPerson.DataNascimento);
            Assert.AreEqual("(11)987654321", firstPerson.Telefone);
            Assert.AreEqual("04567-890", firstPerson.Cep);
            Assert.AreEqual("SP", firstPerson.Estado);
            Assert.AreEqual("São Paulo", firstPerson.Cidade);
            Assert.AreEqual("Vila Exemplo", firstPerson.Bairro);
            Assert.AreEqual("Rua da Amostra", firstPerson.Rua);
            Assert.AreEqual("123", firstPerson.Numero);
            Assert.AreEqual("5678", firstPerson.Agencia);
            Assert.AreEqual("987654-3", firstPerson.ContaCorrente);
            Assert.AreEqual("alice.pix@example.com", firstPerson.Chavepix);
            Assert.AreEqual(DateTime.Parse("2021-09-02 03:30:00"), firstPerson.DataAutorizacao);
            Assert.AreEqual(1, firstPerson.Autorizado);
            Assert.AreEqual("cliente", firstPerson.Tipo);
            Assert.AreEqual((uint)1, firstPerson.IdBanco);
        }

        [TestMethod()]
        public void GetByNomeTest()
        {
            //Act
            var pessoas = _pessoaService.GetByNome("Maria");
            //Assert
            Assert.IsNotNull(pessoas);
            Assert.AreEqual(1, pessoas.Count());
            var firstPerson = pessoas.First();
            Assert.AreEqual((uint)3, firstPerson.Id);
            Assert.AreEqual("Maria Santos", firstPerson.Nome);
            Assert.AreEqual("maria.santos@example.com", firstPerson.Email);
            Assert.AreEqual("543210987", firstPerson.Cnh);
            Assert.AreEqual("98765432112", firstPerson.Cpf);
            Assert.AreEqual("(21)98765-5678", firstPerson.Telefone);
        }
    }
}