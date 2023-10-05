using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Service;
using AutoMapper;
using Moq;
using Core;
using CoAutoWeb.Models;
using Microsoft.AspNetCore.Mvc;
using CoAutoWeb.Mappers;

namespace CoAutoWeb.Controllers.Tests
{
    [TestClass()]
    public class DisponibilidadeControllerTests
    {
        private static DisponibilidadeController controller;


        [TestInitialize]
        public void Initialize()
        {

            var mockService = new Mock<IDisponibilidadeService>();

            IMapper mapper = new MapperConfiguration(ctg =>
            ctg.AddProfile(new DisponibilidadeProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTesteDisponibilidade());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetDisponibilidade());
            mockService.Setup(service => service.Create(It.IsAny<Disponibilidade>()))
                .Verifiable();
            controller = new DisponibilidadeController(mockService.Object, mapper);

        }


        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<DisponibilidadeModel>));

            List<DisponibilidadeModel>? lista = (List<DisponibilidadeModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(DisponibilidadeModel));
            DisponibilidadeModel disponibilidadeModel = (DisponibilidadeModel)viewResult.ViewData.Model;
            Assert.AreEqual((uint)1, disponibilidadeModel.Id);
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
            var result = controller.Create(GetNewDisponibilidade());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void CreateTest_Invalid()
        {
            // Arrange
            controller.ModelState.AddModelError("Data e hora", "é obrigatório.");

            // Act
            var result = controller.Create(GetNewDisponibilidade());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(DisponibilidadeModel));
            DisponibilidadeModel disponibilidadeModel = (DisponibilidadeModel)viewResult.ViewData.Model;
            Assert.AreEqual((uint)1, disponibilidadeModel.Id);
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetDisponibilidade().Id, GetTargetDisponibilidadeModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(DisponibilidadeModel));
            DisponibilidadeModel disponibilidadeModel = (DisponibilidadeModel)viewResult.ViewData.Model;
            Assert.AreEqual((uint)1, disponibilidadeModel.Id);

        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(GetTargetDisponibilidadeModel().Id, GetTargetDisponibilidadeModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private DisponibilidadeModel GetNewDisponibilidade()
        {
            return new DisponibilidadeModel
            {
                Id = 1,
                DataHoraInicio = new DateTime(2021, 09, 2, 3, 30, 0),
                DataHoraFim = new DateTime(2023, 09, 2, 3, 30, 0),
                IdVeiculo = 2

            };
        }
        private static Disponibilidade GetTargetDisponibilidade()
        {
            return new Disponibilidade
            {
                Id = 1,
                DataHoraInicio = new DateTime(2021, 09, 2, 3, 30, 0),
                DataHoraFim = new DateTime(2023, 09, 2, 3, 30, 0),
                IdVeiculo = 2


            };
        }

        private DisponibilidadeModel GetTargetDisponibilidadeModel()
        {
            return new DisponibilidadeModel
            {
                Id = 1,
                DataHoraInicio = new DateTime(2021, 09, 2, 3, 30, 0),
                DataHoraFim = new DateTime(2023, 09, 2, 3, 30, 0),
                IdVeiculo = 2
            };
        }
        private IEnumerable<Disponibilidade> GetTesteDisponibilidade()
        {
            return new List<Disponibilidade>
            {
                new Disponibilidade
                {
                    Id = 2,
                    DataHoraInicio = new DateTime(2021, 09, 3, 9, 0, 0),
                    DataHoraFim = new DateTime(2023, 09, 3, 9, 0, 0),
                    IdVeiculo = 3
                },

                new Disponibilidade
                {
                    Id = 3,
                    DataHoraInicio = new DateTime(2021, 09, 4, 14, 45, 0),
                    DataHoraFim = new DateTime(2023, 09, 4, 14, 45, 0),
                    IdVeiculo = 1
                },

                new Disponibilidade
                {
                    Id = 4,
                    DataHoraInicio = new DateTime(2021, 09, 5, 18, 15, 0),
                    DataHoraFim = new DateTime(2023, 09, 5, 18, 15, 0),
                    IdVeiculo = 4
                }

            };
        }
    }
}