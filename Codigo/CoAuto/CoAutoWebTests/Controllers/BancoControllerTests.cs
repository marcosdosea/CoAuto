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
    public class BancoControllerTests
    {
        private static BancoController controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IBancoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
            cfg.AddProfile(new BancoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestBancos());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetBanco());
            mockService.Setup(service => service.Create(It.IsAny<Banco>()))
                .Verifiable();
            controller = new BancoController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<BancoViewModel>));

            List<BancoViewModel>? lista = (List<BancoViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(BancoViewModel));
            BancoViewModel bancoViewModel = (BancoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Banco do Brasil", bancoViewModel.Nome);
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
            var result = controller.Create(GetNewBanco());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
        public void CreateTest_Invalid()
        {
            // Arrange
            controller.ModelState.AddModelError("Nome", "Nome é obrigatório.");

            // Act
            var result = controller.Create(GetNewBanco());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(BancoViewModel));
            BancoViewModel bancoViewModel = (BancoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Banco do Brasil", bancoViewModel.Nome);
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetBancoViewModel().Id, GetTargetBancoViewModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(BancoViewModel));
            BancoViewModel bancoViewModel = (BancoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Banco do Brasil", actual: bancoViewModel.Nome);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(GetTargetBancoViewModel().Id, GetTargetBancoViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private BancoViewModel GetNewBanco()
        {
            return new BancoViewModel
            {
                Id = 1,
                Nome = "Banco do Brasil",
            };
        }
        private static Banco GetTargetBanco()
        {
            return new Banco
            {
                Id = 1,
                Nome = "Banco do Brasil",
            };
        }

        private BancoViewModel GetTargetBancoViewModel()
        {
            return new BancoViewModel
            {
                Id = 1,
                Nome = "Banco do Brasil",
            };
        }

        private IEnumerable<Banco> GetTestBancos()
        {
            return new List<Banco>
            {
                new Banco
                {
                    Id = 1,
                    Nome = "Banco do Brasil",
                },
                new Banco
                {
                    Id = 4,
                    Nome = "Banco Santander",
                },
                new Banco
                {
                    Id = 5,
                    Nome = "Banco Caixa",
                },
            };
        }
    }
}