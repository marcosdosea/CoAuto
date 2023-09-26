using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoAutoWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using CoAutoWeb.Mappers;
using Core;
using CoAutoWeb.Models;

namespace CoAutoWeb.Controllers.Tests
{
    [TestClass()]
    public class PagamentoControllerTests
    {
        private static PagamentoController controller;
        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IPagamentoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
            cfg.AddProfile(new PagamentoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestPagamento());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetPagamento());
            mockService.Setup(service => service.Create(It.IsAny<Pagamento>()))
                .Verifiable();
            controller = new PagamentoController(mockService.Object, mapper);
        }

        private Pagamento GetTargetPagamento()
        {
            return new Pagamento
            {
                Id = 1,
                Valor = 100,
                FormaPagamento = "pix",
                IdAluguel = 1
            };
        }

        private IEnumerable<Pagamento> GetTestPagamento()
        {
            return new List<Pagamento>
            { new Pagamento
            {
                Id = 1,
                Valor = 100,
                FormaPagamento = "parcelado",
                IdAluguel = 1
            },
            new Pagamento
            {
              Id = 2,
                Valor = 200,
                FormaPagamento = "pix",
                IdAluguel = 2
            },
            new Pagamento
            {
                Id = 3,
                Valor = 300,
                FormaPagamento = "pix",
                IdAluguel = 3
            }

            };
        }

        [TestMethod()]
        public void PagamentoControllerTest()
        {
         
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<PagamentoViewModel>));

            List<PagamentoViewModel>? lista = (List<PagamentoViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PagamentoViewModel));
            PagamentoViewModel pagamentoViewModel = (PagamentoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual((uint)1,pagamentoViewModel.Id);
            Assert.AreEqual(100, pagamentoViewModel.Valor);
            Assert.AreEqual("pix", pagamentoViewModel.FormaPagamento);
            Assert.AreEqual((uint)1, pagamentoViewModel.IdAluguel);
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
            var result = controller.Create(GetNewPagamento());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private PagamentoViewModel GetNewPagamento()
        {
            return new PagamentoViewModel
            {
                Id = 5,
                Valor = 200,
                FormaPagamento = "pix",
                IdAluguel = 5
            };
        }

        [TestMethod()]
        public void CreateTest_Post_Invalid()
        {
            // Arrange
            controller.ModelState.AddModelError("Id", "Campo requerido");

            // Act
            var result = controller.Create(GetNewPagamento());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PagamentoViewModel));
            PagamentoViewModel PagamentoModel = (PagamentoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual((uint)1, PagamentoModel.Id);
            Assert.AreEqual(100, PagamentoModel.Valor);
            Assert.AreEqual("pix", PagamentoModel.FormaPagamento);
            Assert.AreEqual((uint)1, PagamentoModel.IdAluguel);
        }


        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit((uint)GetTargetPagamentoModel().Id, GetTargetPagamentoModel());
         
            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private PagamentoViewModel GetTargetPagamentoModel()
        {
            return new PagamentoViewModel
            {
                Id = 6,
                Valor = 100,
                FormaPagamento = "pix",
                IdAluguel = 6
            };
        }

     

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PagamentoViewModel));
            PagamentoViewModel pagamentoModel = (PagamentoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual((uint)1,(uint)pagamentoModel.Id);
            Assert.AreEqual(100, pagamentoModel.Valor);
            Assert.AreEqual("pix", pagamentoModel.FormaPagamento);
            Assert.AreEqual((uint)1, pagamentoModel.IdAluguel);
        }
        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete((uint)GetTargetPagamentoModel().Id, GetTargetPagamentoModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
    }
}