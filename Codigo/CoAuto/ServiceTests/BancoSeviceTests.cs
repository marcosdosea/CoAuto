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
    public class BancoServiceTests
    {
        private CoAutoContext _context;
        private IBancoService _bancoService;

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
            var bancos = new List<Banco>
                {
                    new Banco
                    {
                        Id = 1,
                        Nome = "Banco do Brasil",
                    },
                    new Banco
                    {
                        Id = 2,
                        Nome = "Banco Santander",
                    },
                    new Banco
                    {
                        Id = 3,
                        Nome = "Banco Caixa",
                    },
                };

            _context.AddRange(bancos);
            _context.SaveChanges();

            _bancoService = new BancoService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            _bancoService.Create(new Banco()
            {
                Id = 4,
                Nome = "Nubank",
            });
            // Assert
            Assert.AreEqual(4, _bancoService.GetAll().Count());
            var banco = _bancoService.Get(4);
            Assert.AreEqual("Nubank", banco.Nome);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            _bancoService.Delete(1);
            // Assert
            Assert.AreEqual(2, _bancoService.GetAll().Count());
            var banco = _bancoService.Get(1);
            Assert.AreEqual(null, banco);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var banco = _bancoService.Get(3);
            banco.Nome = "Inter";
            _bancoService.Edit(banco);

            //Assert
            banco = _bancoService.Get(3);
            Assert.AreEqual("Inter", banco.Nome);
        }

        [TestMethod()]
        public void GetTest()
        {
            var banco = _bancoService.Get(3);
            Assert.IsNotNull(banco);
            Assert.AreEqual("Bradesco", banco.Nome);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaBanco = _bancoService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaBanco, typeof(IEnumerable<Banco>));
            Assert.IsNotNull(listaBanco);
            Assert.AreEqual(3, listaBanco.Count());
            var firstBanco = listaBanco.First();
            Assert.AreEqual((uint)1, firstBanco.Id);
            Assert.AreEqual("Banco do Brasil", firstBanco.Nome);
        }
        [TestMethod()]
        public void GetByNomeTest()
        {
            //Act
            var bancos = _bancoService.GetByNome("Brasil");
            //Assert
            Assert.IsNotNull(bancos);
            Assert.AreEqual(1, bancos.Count());
            var firstBanco = bancos.First();
            Assert.AreEqual((uint)3, firstBanco.Id);
            Assert.AreEqual("Banco do Brasil", firstBanco.Nome);
        }
    }
}