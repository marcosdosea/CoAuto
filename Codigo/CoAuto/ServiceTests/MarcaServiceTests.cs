using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Service.Tests
{
    [TestClass()]
    public class MarcaServiceTests
    {
        private CoAutoContext _context;
        private IMarcaService _marcaService;

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
            var marcas = new List<Marca>
                {
                    new Marca
                    {
                        Id = 1,
                        Nome = "Fiat",
                    },
                    new Marca
                    {
                        Id = 2,
                        Nome = "Lamborguine",
                    },
                    new Marca
                    {
                        Id = 3,
                        Nome = "Ducati",
                    },
            };

            _context.AddRange(marcas);
            _context.SaveChanges();

            _marcaService = new MarcaService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            _marcaService.Create(new Marca()
            {
                Id = 4,
                Nome = "Honda",
            });
            // Assert
            Assert.AreEqual(4, _marcaService.GetAll().Count());
            var marca = _marcaService.Get(4);
            Assert.AreEqual("Honda", marca.Nome);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            _marcaService.Delete(1);
            // Assert
            Assert.AreEqual(2, _marcaService.GetAll().Count());
            var marca = _marcaService.Get(1);
            Assert.AreEqual(null, marca);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var marca = _marcaService.Get(3);
            marca.Nome = "Inter";
            _marcaService.Edit(marca);

            //Assert
            marca = _marcaService.Get(3);
            Assert.AreEqual("Inter", marca.Nome);
        }

        [TestMethod()]
        public void GetTest()
        {
            var marca = _marcaService.Get(3);
            Assert.IsNotNull(marca);
            Assert.AreEqual("Bradesco", marca.Nome);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaMarca = _marcaService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaMarca, typeof(IEnumerable<Marca>));
            Assert.IsNotNull(listaMarca);
            Assert.AreEqual(3, listaMarca.Count());
            var firstMarca = listaMarca.First();
            Assert.AreEqual((uint)1, firstMarca.Id);
            Assert.AreEqual("Fiat", firstMarca.Nome);
        }
    }
}