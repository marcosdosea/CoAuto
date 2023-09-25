using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoAutoWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Service;
using AutoMapper;
using Moq;
using Core;

namespace CoAutoWeb.Controllers.Tests
{
    [TestClass()]
    public class DisponibilidadeControllerTests
    {
        private static DisponibilidadeController controller;
        private IDisponibilidadeService @object;
        private IMapper mapper;


        [TestInitialize] 
        public void Initialize() {

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

            //assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.model, typeof(List<Disponibilidade>));
            
            List<DisponibilidadeModel> ? lista = (List<DisponibilidadeModel>)viewResult.ViewData.model; 
            Assert.AreEqual(2, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            var result = controller.Details(1);
        }

        [TestMethod()]
        public void CreateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest1()
        {
            Assert.Fail();
        }
    }
}