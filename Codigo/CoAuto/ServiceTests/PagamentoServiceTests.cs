using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Service.Tests
{
    [TestClass()]
    public class PagamentoServiceTests
    {
        private CoAutoContext _context;
        private IPagamentoService _pagamentoService;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<CoAutoContext>();
            builder.UseInMemoryDatabase("CoAuto");
            var options = builder.Options;

            _context = new CoAutoContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var pagamentos = new List<Pagamento>
                {
                    new Pagamento
            {
                Id = 1,
                Valor = 100,
                FormaPagamento = "a vista",
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

            _context.AddRange(pagamentos);
            _context.SaveChanges();

            _pagamentoService = new PagamentoService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            _pagamentoService.Create(new Pagamento() {
                Id = 4,
                Valor = 100,
                FormaPagamento = "a vista",
                IdAluguel = 4
            });
            // Assert
            Assert.AreEqual(4, _pagamentoService.GetAll().Count());
            var pagamento = _pagamentoService.Get(4);
            Assert.AreEqual((uint)4, pagamento.Id);
            Assert.AreEqual(100, pagamento.Valor);
            Assert.AreEqual("a vista", pagamento.FormaPagamento);
            Assert.AreEqual((uint)4, pagamento.IdAluguel);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            _pagamentoService.Delete(2);
            // Assert
            Assert.AreEqual(2, _pagamentoService.GetAll().Count());
            var pagamento = _pagamentoService.Get(2);
            Assert.AreEqual(null, pagamento);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var pagamento = _pagamentoService.Get(3);
            pagamento.Valor = 400;
            pagamento.FormaPagamento = "a vista";
            _pagamentoService.Edit(pagamento);
            //Assert
            pagamento = _pagamentoService.Get(3);
            Assert.IsNotNull(pagamento);
            Assert.AreEqual(400, pagamento.Valor);
            Assert.AreEqual("a vista", pagamento.FormaPagamento);
        }

        [TestMethod()]
        public void GetTest()
        {
            var pagamento = _pagamentoService.Get(1);
            Assert.IsNotNull(pagamento);
            Assert.AreEqual((uint)1, pagamento.Id);
            Assert.AreEqual(100, pagamento.Valor);
            Assert.AreEqual("a vista", pagamento.FormaPagamento);
            Assert.AreEqual((uint)1, pagamento.IdAluguel);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaPagamento = _pagamentoService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaPagamento, typeof(IEnumerable<Pagamento>));
            Assert.IsNotNull(listaPagamento);
            Assert.AreEqual(3, listaPagamento.Count());
            Assert.AreEqual((uint)1, listaPagamento.First().Id);
            Assert.AreEqual(100, listaPagamento.First().Valor);
            Assert.AreEqual("a vista", listaPagamento.First().FormaPagamento);
            Assert.AreEqual((uint)1, listaPagamento.First().IdAluguel);
        }
    }
}