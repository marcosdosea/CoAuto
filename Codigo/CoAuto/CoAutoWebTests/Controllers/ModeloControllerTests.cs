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
    public class ModeloControllerTests
    {
        private static ModeloController controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IModeloService>();

            IMapper mapper = new MapperConfiguration(cfg =>
            cfg.AddProfile(new ModeloProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestModelos());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetModelo());
            mockService.Setup(service => service.Create(It.IsAny<Modelo>()))
                .Verifiable();
            controller = new ModeloController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<ModeloViewModel>));

            List<ModeloViewModel>? lista = (List<ModeloViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ModeloViewModel));
            ModeloViewModel modeloViewModel = (ModeloViewModel)viewResult.ViewData.Model;
            Assert.AreEqual((uint)1, modeloViewModel.IdMarca);
            Assert.AreEqual("Estrada", modeloViewModel.Nome);
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
            var result = controller.Create(GetNewModelo());

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
            var result = controller.Create(GetNewModelo());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ModeloViewModel));
            ModeloViewModel modeloViewModel = (ModeloViewModel)viewResult.ViewData.Model;
            Assert.AreEqual((uint)1, modeloViewModel.IdMarca);
            Assert.AreEqual("Estrada", modeloViewModel.Nome);
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetModeloViewModel().Id, GetTargetModeloViewModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ModeloViewModel));
            ModeloViewModel modeloViewModel = (ModeloViewModel)viewResult.ViewData.Model;
            Assert.AreEqual((uint)1, modeloViewModel.IdMarca);
            Assert.AreEqual("Estrada", actual: modeloViewModel.Nome);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(GetTargetModeloViewModel().Id, GetTargetModeloViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private ModeloViewModel GetNewModelo()
        {
            return new ModeloViewModel
            {
                Id = 1,
                IdMarca = 1,
                Nome = "Estrada",
            };
        }
        private static Modelo GetTargetModelo()
        {
            return new Modelo
            {
                Id = 1,
                IdMarca = 1,
                Nome = "Estrada",
            };
        }

        private ModeloViewModel GetTargetModeloViewModel()
        {
            return new ModeloViewModel
            {
                Id = 1,
                IdMarca = 1,
                Nome = "Estrada",
            };
        }

        private IEnumerable<Modelo> GetTestModelos()
        {
            return new List<Modelo>
            {
                new Modelo
                {
                    Id = 1,
                    IdMarca = 1,
                    Nome = "Estrada",
                },
                new Modelo
                {
                    Id = 4,
                    IdMarca = 1,
                    Nome = "Fastback",
                },
                new Modelo
                {
                    Id = 5,
                    IdMarca = 2,
                    Nome = "Polo",
                },
            };
        }
    }
}