using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using Microsoft.AspNetCore.Mvc;
using CoAutoWeb.Models;
using CoAutoWeb.Mappers;
using Core.Service;
using Moq;
using AutoMapper;

namespace CoAutoWeb.Controllers.Tests
{
    [TestClass()]
    public class PessoaControllerTests
    {
        private static PessoaController controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IPessoaService>();

            IMapper mapper = new MapperConfiguration(cfg =>
            cfg.AddProfile(new PessoaProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestPessoas());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetPessoa());
            mockService.Setup(service => service.Create(It.IsAny<Pessoa>()))
                .Verifiable();
            controller = new PessoaController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<PessoaViewModel>));

            List<PessoaViewModel>? lista = (List<PessoaViewModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaViewModel));
            PessoaViewModel pessoaViewModel = (PessoaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Alice Johnson", pessoaViewModel.Nome);
            Assert.AreEqual(DateTime.Parse("1995-07-12"), pessoaViewModel.DataNascimento);
            Assert.AreEqual("alice.johnson@example.com", pessoaViewModel.Email);
            Assert.AreEqual("987654321", pessoaViewModel.Cnh);
            Assert.AreEqual("12345678901", pessoaViewModel.Cpf);
            Assert.AreEqual("senhaAleatoria", pessoaViewModel.Senha);
            Assert.AreEqual("(11)98765-4321", pessoaViewModel.Telefone);
            Assert.AreEqual("04567890", pessoaViewModel.Cep);
            Assert.AreEqual("SP", pessoaViewModel.Estado);
            Assert.AreEqual("São Paulo", pessoaViewModel.Cidade);
            Assert.AreEqual("Vila Exemplo", pessoaViewModel.Bairro);
            Assert.AreEqual("Rua da Amostra", pessoaViewModel.Rua);
            Assert.AreEqual("123", pessoaViewModel.Numero);
            Assert.AreEqual("5678", pessoaViewModel.Agencia);
            Assert.AreEqual("987654-3", pessoaViewModel.ContaCorrente);
            Assert.AreEqual("alice.pix@example.com", pessoaViewModel.Chavepix);
            Assert.AreEqual(DateTime.Parse("2021-09-02 03:30:00"), pessoaViewModel.DataAutorizacao);
            Assert.AreEqual(1, pessoaViewModel.Autorizado);
            Assert.AreEqual("cliente", pessoaViewModel.Tipo);
            Assert.AreEqual((uint)1, pessoaViewModel.IdBanco);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            var result = controller.Create();

            // Assert 
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void CreateTest_Valid()
        {
            // Act
            var result = controller.Create(GetNewPessoa());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
        public void CreateTest_Invalid()
        {
            // Arrange
            controller.ModelState.AddModelError("Cpf", "CPF é obrigatório.");

            // Act
            var result = controller.Create(GetNewPessoa());

            // Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }


        [TestMethod()]
        public void EditTest_Get_Valid()
        {
            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaViewModel));
            PessoaViewModel pessoaViewModel = (PessoaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Alice Johnson", pessoaViewModel.Nome);
            Assert.AreEqual(DateTime.Parse("1995-07-12"), pessoaViewModel.DataNascimento);
            Assert.AreEqual("alice.johnson@example.com", pessoaViewModel.Email);
            Assert.AreEqual("987654321", pessoaViewModel.Cnh);
            Assert.AreEqual("12345678901", pessoaViewModel.Cpf);
            Assert.AreEqual("senhaAleatoria", pessoaViewModel.Senha);
            Assert.AreEqual("(11)98765-4321", pessoaViewModel.Telefone);
            Assert.AreEqual("04567890", pessoaViewModel.Cep);
            Assert.AreEqual("SP", pessoaViewModel.Estado);
            Assert.AreEqual("São Paulo", pessoaViewModel.Cidade);
            Assert.AreEqual("Vila Exemplo", pessoaViewModel.Bairro);
            Assert.AreEqual("Rua da Amostra", pessoaViewModel.Rua);
            Assert.AreEqual("123", pessoaViewModel.Numero);
            Assert.AreEqual("5678", pessoaViewModel.Agencia);
            Assert.AreEqual("987654-3", pessoaViewModel.ContaCorrente);
            Assert.AreEqual("alice.pix@example.com", pessoaViewModel.Chavepix);
            Assert.AreEqual(DateTime.Parse("2021-09-02 03:30:00"), pessoaViewModel.DataAutorizacao);
            Assert.AreEqual(1, pessoaViewModel.Autorizado);
            Assert.AreEqual("cliente", pessoaViewModel.Tipo);
            Assert.AreEqual((uint)1, pessoaViewModel.IdBanco);
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetPessoaViewModel().Id, GetTargetPessoaViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void DeleteTest_Post_Valid()
        {
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaViewModel));
            PessoaViewModel pessoaViewModel = (PessoaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Alice Johnson", actual: pessoaViewModel.Nome);
            Assert.AreEqual(DateTime.Parse("1995-07-12"), pessoaViewModel.DataNascimento);
            Assert.AreEqual("alice.johnson@example.com", pessoaViewModel.Email);
            Assert.AreEqual("987654321", pessoaViewModel.Cnh);
            Assert.AreEqual("12345678901", pessoaViewModel.Cpf);
            Assert.AreEqual("senhaAleatoria", pessoaViewModel.Senha);
            Assert.AreEqual("(11)98765-4321", pessoaViewModel.Telefone);
            Assert.AreEqual("04567890", pessoaViewModel.Cep);
            Assert.AreEqual("SP", pessoaViewModel.Estado);
            Assert.AreEqual("São Paulo", pessoaViewModel.Cidade);
            Assert.AreEqual("Vila Exemplo", pessoaViewModel.Bairro);
            Assert.AreEqual("Rua da Amostra", pessoaViewModel.Rua);
            Assert.AreEqual("123", pessoaViewModel.Numero);
            Assert.AreEqual("5678", pessoaViewModel.Agencia);
            Assert.AreEqual("987654-3", pessoaViewModel.ContaCorrente);
            Assert.AreEqual("alice.pix@example.com", pessoaViewModel.Chavepix);
            Assert.AreEqual(DateTime.Parse("2021-09-02 03:30:00"), pessoaViewModel.DataAutorizacao);
            Assert.AreEqual(1, pessoaViewModel.Autorizado);
            Assert.AreEqual("cliente", pessoaViewModel.Tipo);
            Assert.AreEqual((uint)1, pessoaViewModel.IdBanco);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(GetTargetPessoaViewModel().Id, GetTargetPessoaViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private PessoaViewModel GetNewPessoa()
        {
            return new PessoaViewModel
            {
                Id = 1,
                Nome = "Alice Johnson",
                Email = "alice.johnson@example.com",
                Cnh = "987654321",
                Cpf = "12345678901",
                Senha = "senhaAleatoria",
                DataNascimento = new DateTime(1995, 07, 12),
                Telefone = "(11)98765-4321",
                Cep = "04567890",
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
            };
        }
        private static  Pessoa GetTargetPessoa()
        {
            return new Pessoa
            {
                Id = 1,
                Nome = "Alice Johnson",
                Email = "alice.johnson@example.com",
                Cnh = "987654321",
                Cpf = "12345678901",
                Senha = "senhaAleatoria",
                DataNascimento = new DateTime(1995, 07, 12),
                Telefone = "(11)98765-4321",
                Cep = "04567890",
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
            };
        }

        private PessoaViewModel GetTargetPessoaViewModel()
        {
            return new PessoaViewModel
            {
                Id = 1,
                Nome = "Alice Johnson",
                Email = "alice.johnson@example.com",
                Cnh = "987654321",
                Cpf = "12345678901",
                Senha = "senhaAleatoria",
                DataNascimento = new DateTime(1995, 07, 12),
                Telefone = "(11)98765-4321",
                Cep = "04567890",
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
            };
        }

        private IEnumerable<Pessoa> GetTestPessoas()
        {
            return new List<Pessoa>
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
                    Telefone = "(11)98765-4321",
                    Cep = "04567890",
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
                    Id = 4,
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
                    DataAutorizacao = new DateTime(2023, 05, 25, 9, 30, 0),
                    Autorizado = 1,
                    Tipo = "cliente",
                    IdBanco = 1
                },
                new Pessoa
                {
                    Id = 5,
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
                    DataAutorizacao = new DateTime(2021, 09, 25, 10, 0, 0),
                    Autorizado = 1,
                    Tipo = "cliente",
                    IdBanco = 1
                },
            };
        }
    }
}