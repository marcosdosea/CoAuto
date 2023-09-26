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
    public class ModeloServiceTests
    {
        private CoAutoContext _context;
        private IModeloService _modeloService;

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
            var modelos = new List<Modelo>
                {
                    new Modelo
                    {
                        Id = 1,
                        IdMarca = 1,
                        Nome = "Estrada",
                    },
                    new Modelo
                    {
                        Id = 2,
                        IdMarca = 2,
                        Nome = "Gol",
                    },
                    new Modelo
                    {
                        Id = 3,
                        IdMarca = 3,
                        Nome = "Chevete",
                    },
                };

            _context.AddRange(modelos);
            _context.SaveChanges();

            _modeloService = new ModeloService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            _modeloService.Create(new Modelo()
            {
                Id = 4,
                IdMarca = 4,
                Nome = "La Ferrari",
            });
            // Assert
            Assert.AreEqual(4, _modeloService.GetAll().Count());
            var modelo = _modeloService.Get(4);
            Assert.AreEqual((uint)4, modelo.IdMarca);
            Assert.AreEqual("La Ferrari", modelo.Nome);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            _modeloService.Delete(1);
            // Assert
            Assert.AreEqual(2, _modeloService.GetAll().Count());
            var modelo = _modeloService.Get(1);
            Assert.AreEqual(null, modelo);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var modelo = _modeloService.Get(3);
            modelo.IdMarca = 3;
            modelo.Nome = "Golf";
            _modeloService.Edit(modelo);

            //Assert
            modelo = _modeloService.Get(3);
            Assert.AreEqual("Golf", modelo.Nome);
        }

        [TestMethod()]
        public void GetTest()
        {
            var modelo = _modeloService.Get(3);
            Assert.IsNotNull(modelo);
            Assert.AreEqual((uint)3, modelo.IdMarca);
            Assert.AreEqual("Gol", modelo.Nome);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listModelo = _modeloService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listModelo, typeof(IEnumerable<Modelo>));
            Assert.IsNotNull(listModelo);
            Assert.AreEqual(3, listModelo.Count());
            var firstModelo = listModelo.First();
            Assert.AreEqual((uint)1, firstModelo.Id);
            Assert.AreEqual((uint)1, firstModelo.IdMarca);
            Assert.AreEqual("Estrada", firstModelo.Nome);
        }
        [TestMethod()]
        public void GetByNomeTest()
        {
            //Act
            var modelos = _modeloService.GetByNome("Ferrari");
            //Assert
            Assert.IsNotNull(modelos);
            Assert.AreEqual(1, modelos.Count());
            var firstModelo = modelos.First();
            Assert.AreEqual((uint)2, firstModelo.Id);
            Assert.AreEqual((uint)2, firstModelo.IdMarca);
            Assert.AreEqual("La Ferrari", firstModelo.Nome);
        }
    }
}