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
    public class AluguelControllerTests
    {
        private static AluguelController controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IAluguelService>();

            IMapper mapper = new MapperConfiguration(cfg =>
            cfg.AddProfile(new AluguelProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestAluguels());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetAluguel());
            mockService.Setup(service => service.Create(It.IsAny<Aluguel>()))
                .Verifiable();
            controller = new AluguelController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<AluguelViewModel>));

            List<AluguelViewModel>? lista = (List<AluguelViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AluguelViewModel));
            AluguelViewModel aluguelViewModel = (AluguelViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(DateTime.Parse("2021-09-02 03:30:00"), aluguelViewModel.DataHoraAluguel);
            Assert.AreEqual((uint)1, aluguelViewModel.IdPessoa);
            Assert.AreEqual("concluido", aluguelViewModel.Status);
            Assert.AreEqual((uint)2, aluguelViewModel.IdVeiculo);
            Assert.AreEqual(DateTime.Parse("2021-09-02 03:30:00"), aluguelViewModel.DataHoraAvaliacaoProprietario);
            Assert.AreEqual((byte)3, aluguelViewModel.QtdEstrelasAvaliacaoProprietario);
            Assert.AreEqual(DateTime.Parse("2021-09-02 03:30:00"), aluguelViewModel.DataHoraAvaliacaoCliente);
            Assert.AreEqual((sbyte)2, aluguelViewModel.QtdEstrelasAvaliacaoCliente);
            Assert.AreEqual("um pouco de texto", aluguelViewModel.DescricaoAvaliacaoProprietario);
            Assert.AreEqual("um pouco de texto", aluguelViewModel.DescricaoAvaliacaoCliente);
            Assert.AreEqual((uint)1, aluguelViewModel.IdEntrega);
            Assert.AreEqual((uint)1, aluguelViewModel.IdDevolucao);
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
            var result = controller.Create(GetNewAluguel());

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
            var result = controller.Create(GetNewAluguel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AluguelViewModel));
            AluguelViewModel aluguelViewModel = (AluguelViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(DateTime.Parse("2021-09-02 03:30:00"), aluguelViewModel.DataHoraAluguel);
            Assert.AreEqual((uint)1, aluguelViewModel.IdPessoa);
            Assert.AreEqual("concluido", aluguelViewModel.Status);
            Assert.AreEqual((uint)2, aluguelViewModel.IdVeiculo);
            Assert.AreEqual(DateTime.Parse("2021-09-02 03:30:00"), aluguelViewModel.DataHoraAvaliacaoProprietario);
            Assert.AreEqual((byte)3, aluguelViewModel.QtdEstrelasAvaliacaoProprietario);
            Assert.AreEqual(DateTime.Parse("2021-09-02 03:30:00"), aluguelViewModel.DataHoraAvaliacaoCliente);
            Assert.AreEqual((sbyte)2, aluguelViewModel.QtdEstrelasAvaliacaoCliente);
            Assert.AreEqual("um pouco de texto", aluguelViewModel.DescricaoAvaliacaoProprietario);
            Assert.AreEqual("um pouco de texto", aluguelViewModel.DescricaoAvaliacaoCliente);
            Assert.AreEqual((uint)1, aluguelViewModel.IdEntrega);
            Assert.AreEqual((uint)1, aluguelViewModel.IdDevolucao);
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetAluguelViewModel().Id, GetTargetAluguelViewModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AluguelViewModel));
            AluguelViewModel aluguelViewModel = (AluguelViewModel)viewResult.ViewData.Model;
            Assert.AreEqual(DateTime.Parse("2021-09-02 03:30:00"), aluguelViewModel.DataHoraAluguel);
            Assert.AreEqual((uint)1, aluguelViewModel.IdPessoa);
            Assert.AreEqual("concluido", aluguelViewModel.Status);
            Assert.AreEqual((uint)2, aluguelViewModel.IdVeiculo);
            Assert.AreEqual(DateTime.Parse("2021-09-02 03:30:00"), aluguelViewModel.DataHoraAvaliacaoProprietario);
            Assert.AreEqual((byte)3, aluguelViewModel.QtdEstrelasAvaliacaoProprietario);
            Assert.AreEqual(DateTime.Parse("2021-09-02 03:30:00"), aluguelViewModel.DataHoraAvaliacaoCliente);
            Assert.AreEqual((sbyte)2, aluguelViewModel.QtdEstrelasAvaliacaoCliente);
            Assert.AreEqual("um pouco de texto", aluguelViewModel.DescricaoAvaliacaoProprietario);
            Assert.AreEqual("um pouco de texto", aluguelViewModel.DescricaoAvaliacaoCliente);
            Assert.AreEqual((uint)1, aluguelViewModel.IdEntrega);
            Assert.AreEqual((uint)1, aluguelViewModel.IdDevolucao);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(GetTargetAluguelViewModel().Id, GetTargetAluguelViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private AluguelViewModel GetNewAluguel()
        {
            return new AluguelViewModel
            {
                Id = 1,
                DataHoraAluguel = new DateTime(2021, 09, 2, 3, 30, 0),
                IdPessoa = 1,
                Status = "concluido",
                IdVeiculo = 2,
                DataHoraAvaliacaoProprietario = new DateTime(2021, 09, 2, 3, 30, 0),
                QtdEstrelasAvaliacaoProprietario = 3,
                DataHoraAvaliacaoCliente = new DateTime(2021, 09, 2, 3, 30, 0),
                QtdEstrelasAvaliacaoCliente = 2,
                DescricaoAvaliacaoProprietario = "um pouco de texto",
                DescricaoAvaliacaoCliente = "um pouco de texto",
                IdEntrega = 1,
                IdDevolucao = 1,
            };
        }
        private static Aluguel GetTargetAluguel()
        {
            return new Aluguel
            {
                Id = 1,
                DataHoraAluguel = new DateTime(2021, 09, 2, 3, 30, 0),
                IdPessoa = 1,
                Status = "concluido",
                IdVeiculo = 2,
                DataHoraAvaliacaoProprietario = new DateTime(2021, 09, 2, 3, 30, 0),
                QtdEstrelasAvaliacaoProprietario = 3,
                DataHoraAvaliacaoCliente = new DateTime(2021, 09, 2, 3, 30, 0),
                QtdEstrelasAvaliacaoCliente = 2,
                DescricaoAvaliacaoProprietario = "um pouco de texto",
                DescricaoAvaliacaoCliente = "um pouco de texto",
                IdEntrega = 1,
                IdDevolucao = 1,
            };
        }

        private AluguelViewModel GetTargetAluguelViewModel()
        {
            return new AluguelViewModel
            {
                Id = 1,
                DataHoraAluguel = new DateTime(2021, 09, 2, 3, 30, 0),
                IdPessoa = 1,
                Status = "concluido",
                IdVeiculo = 2,
                DataHoraAvaliacaoProprietario = new DateTime(2021, 09, 2, 3, 30, 0),
                QtdEstrelasAvaliacaoProprietario = 3,
                DataHoraAvaliacaoCliente = new DateTime(2021, 09, 2, 3, 30, 0),
                QtdEstrelasAvaliacaoCliente = 2,
                DescricaoAvaliacaoProprietario = "um pouco de texto",
                DescricaoAvaliacaoCliente = "um pouco de texto",
                IdEntrega = 1,
                IdDevolucao = 1,
            };
        }

        private IEnumerable<Aluguel> GetTestAluguels()
        {
            return new List<Aluguel>
            {
                new Aluguel
                {
                        Id = 1,
                        DataHoraAluguel = new DateTime(2021, 09, 2, 3, 30, 0),
                        IdPessoa = 1,
                        Status = "concluido",
                        IdVeiculo = 2,
                        DataHoraAvaliacaoProprietario = new DateTime(2021, 09, 2, 3, 30, 0),
                        QtdEstrelasAvaliacaoProprietario = 3,
                        DataHoraAvaliacaoCliente = new DateTime(2021, 09, 2, 3, 30, 0),
                        QtdEstrelasAvaliacaoCliente = 2,
                        DescricaoAvaliacaoProprietario = "um pouco de texto",
                        DescricaoAvaliacaoCliente = "um pouco de texto",
                        IdEntrega = 1,
                        IdDevolucao = 1,
                    },
                new Aluguel
                {
                        Id = 4,
                        DataHoraAluguel = new DateTime(2024, 09, 2, 3, 30, 0),
                        IdPessoa = 1,
                        Status = "concluido",
                        IdVeiculo = 2,
                        DataHoraAvaliacaoProprietario = new DateTime(2024, 09, 2, 3, 30, 0),
                        QtdEstrelasAvaliacaoProprietario = 3,
                        DataHoraAvaliacaoCliente = new DateTime(2024, 09, 2, 3, 30, 0),
                        QtdEstrelasAvaliacaoCliente = 2,
                        DescricaoAvaliacaoProprietario = "um pouco de texto",
                        DescricaoAvaliacaoCliente = "um pouco de texto",
                        IdEntrega = 4,
                        IdDevolucao = 4,
                    },
                new Aluguel
                {
                        Id = 5,
                        DataHoraAluguel = new DateTime(2025, 09, 2, 3, 30, 0),
                        IdPessoa = 1,
                        Status = "cancelado",
                        IdVeiculo = 2,
                        DataHoraAvaliacaoProprietario = new DateTime(2025, 09, 2, 3, 30, 0),
                        QtdEstrelasAvaliacaoProprietario = 3,
                        DataHoraAvaliacaoCliente = new DateTime(2025, 09, 2, 3, 30, 0),
                        QtdEstrelasAvaliacaoCliente = 2,
                        DescricaoAvaliacaoProprietario = "um pouco de texto",
                        DescricaoAvaliacaoCliente = "um pouco de texto",
                        IdEntrega = 5,
                        IdDevolucao = 5,
                    },
            };
        }
    }
}