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
    public class MarcaControllerTests
    {
        private static MarcaController controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IMarcaService>();

            IMapper mapper = new MapperConfiguration(cfg =>
            cfg.AddProfile(new MarcaProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestMarcas());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetMarca());
            mockService.Setup(service => service.Create(It.IsAny<Marca>()))
                .Verifiable();
            controller = new MarcaController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<MarcaViewModel>));

            List<MarcaViewModel>? lista = (List<MarcaViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(MarcaViewModel));
            MarcaViewModel marcaViewModel = (MarcaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Fiat", marcaViewModel.Nome);
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
            var result = controller.Create(GetNewMarca());

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
            var result = controller.Create(GetNewMarca());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(MarcaViewModel));
            MarcaViewModel marcaViewModel = (MarcaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Fiat", marcaViewModel.Nome);
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetMarcaViewModel().Id, GetTargetMarcaViewModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(MarcaViewModel));
            MarcaViewModel marcaViewModel = (MarcaViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Fiat", actual: marcaViewModel.Nome);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(GetTargetMarcaViewModel().Id, GetTargetMarcaViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private MarcaViewModel GetNewMarca()
        {
            return new MarcaViewModel
            {
                Id = 1,
                Nome = "Fiat",
            };
        }
        private static Marca GetTargetMarca()
        {
            return new Marca
            {
                Id = 1,
                Nome = "Fiat",
            };
        }

        private MarcaViewModel GetTargetMarcaViewModel()
        {
            return new MarcaViewModel
            {
                Id = 1,
                Nome = "Fiat",
            };
        }

        private IEnumerable<Marca> GetTestMarcas()
        {
            return new List<Marca>
            {
                new Marca
                {
                    Id = 1,
                    Nome = "Fiat",
                },
                new Marca
                {
                    Id = 2,
                    Nome = "Toyota",
                },
                new Marca
                {
                    Id = 3,
                    Nome = "Ferrari",
                },
            };
        }
    }
}