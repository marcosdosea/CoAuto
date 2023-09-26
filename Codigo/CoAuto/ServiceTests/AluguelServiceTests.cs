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
    public class AluguelServiceTests
    {
        private CoAutoContext _context;
        private IAluguelService _aluguelService;

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
            var aluguels = new List<Aluguel>
                {
                    new Aluguel
                    {
                        Id = 1,
                        DataHoraAluguel = new DateTime(2021, 09, 2, 3, 30, 0),
                        IdPessoa = 1,
                        Status = "concluido",
                        IdVeiculo = 2,
                        DataHoraAvaliacaoProprietario = new DateTime(2021, 09, 2, 3, 30, 0),
                        QtdEstrelasAvaliacaoProprietario = 3,
                        DataHoraAvaliacaoCliente = new DateTime(2021, 09, 2, 3, 30, 0),
                        QtdEstrelasAvaliacaoCliente = 2,
                        DescricaoAvaliacaoProprietario = "um pouco de texto",
                        DescricaoAvaliacaoCliente = "um pouco de texto",
                        IdEntrega = 1,
                        IdDevolucao = 1,
                    },
                    new Aluguel
                    {
                        Id = 2,
                        DataHoraAluguel = new DateTime(2022, 09, 2, 3, 30, 0),
                        IdPessoa = 1,
                        Status = "cancelado",
                        IdVeiculo = 2,
                        DataHoraAvaliacaoProprietario = new DateTime(2022, 09, 2, 3, 30, 0),
                        QtdEstrelasAvaliacaoProprietario = 1,
                        DataHoraAvaliacaoCliente = new DateTime(2022, 09, 2, 3, 30, 0),
                        QtdEstrelasAvaliacaoCliente = 4,
                        DescricaoAvaliacaoProprietario = "um pouco de texto",
                        DescricaoAvaliacaoCliente = "um pouco de texto",
                        IdEntrega = 2,
                        IdDevolucao = 2,
                    },
                    new Aluguel
                    {
                        Id = 3,
                        DataHoraAluguel = new DateTime(2023, 09, 2, 3, 30, 0),
                        IdPessoa = 1,
                        Status = "andamento",
                        IdVeiculo = 2,
                        DataHoraAvaliacaoProprietario = new DateTime(2023, 09, 2, 3, 30, 0),
                        QtdEstrelasAvaliacaoProprietario = 3,
                        DataHoraAvaliacaoCliente = new DateTime(2023, 09, 2, 3, 30, 0),
                        QtdEstrelasAvaliacaoCliente = 1,
                        DescricaoAvaliacaoProprietario = "um pouco de texto",
                        DescricaoAvaliacaoCliente = "um pouco de texto",
                        IdEntrega = 3,
                        IdDevolucao = 3,
                    },
                };

            _context.AddRange(aluguels);
            _context.SaveChanges();

            _aluguelService = new AluguelService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            _aluguelService.Create(new Aluguel()
            {
                Id = 4,
                DataHoraAluguel = new DateTime(2024, 02, 1, 23, 30, 0),
                IdPessoa = 1,
                Status = "andamento",
                IdVeiculo = 2,
                DataHoraAvaliacaoProprietario = new DateTime(2024, 02, 1, 23, 30, 0),
                QtdEstrelasAvaliacaoProprietario = 5,
                DataHoraAvaliacaoCliente = new DateTime(2024, 02, 1, 23, 30, 0),
                QtdEstrelasAvaliacaoCliente = 5,
                DescricaoAvaliacaoProprietario = "um pouco de texto",
                DescricaoAvaliacaoCliente = "um pouco de texto",
                IdEntrega = 4,
                IdDevolucao = 4,
            });
            // Assert
            Assert.AreEqual(4, _aluguelService.GetAll().Count());
            var aluguel = _aluguelService.Get(4);
            Assert.AreEqual(DateTime.Parse("2024-02-01 23:30:00"), aluguel.DataHoraAluguel);
            Assert.AreEqual((uint)1, aluguel.IdPessoa);
            Assert.AreEqual("andamento", aluguel.Status);
            Assert.AreEqual((uint)2, aluguel.IdVeiculo);
            Assert.AreEqual(DateTime.Parse("2024-02-01 23:30:00"), aluguel.DataHoraAvaliacaoProprietario);
            Assert.AreEqual((byte)5, aluguel.QtdEstrelasAvaliacaoProprietario);
            Assert.AreEqual(DateTime.Parse("2024-02-01 23:30:00"), aluguel.DataHoraAvaliacaoCliente);
            Assert.AreEqual((sbyte)5, aluguel.QtdEstrelasAvaliacaoCliente);
            Assert.AreEqual("um pouco de texto", aluguel.DescricaoAvaliacaoProprietario);
            Assert.AreEqual("um pouco de texto", aluguel.DescricaoAvaliacaoCliente);
            Assert.AreEqual((uint)4, aluguel.IdEntrega);
            Assert.AreEqual((uint)4, aluguel.IdDevolucao);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            _aluguelService.Delete(1);
            // Assert
            Assert.AreEqual(2, _aluguelService.GetAll().Count());
            var aluguel = _aluguelService.Get(1);
            Assert.AreEqual(null, aluguel);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var aluguel = _aluguelService.Get(3);
            aluguel.DataHoraAluguel = new DateTime(2023, 09, 2, 3, 30, 0);
            aluguel.IdPessoa = 1;
            aluguel.Status = "andamento";
            aluguel.IdVeiculo = 2;
            aluguel.DataHoraAvaliacaoProprietario = new DateTime(2023, 09, 2, 3, 30, 0);
            aluguel.QtdEstrelasAvaliacaoProprietario = 3;
            aluguel.DataHoraAvaliacaoCliente = new DateTime(2023, 09, 2, 3, 30, 0);
            aluguel.QtdEstrelasAvaliacaoCliente = 1;
            aluguel.DescricaoAvaliacaoProprietario = "um pouco de texto";
            aluguel.DescricaoAvaliacaoCliente = "um pouco de texto";
            aluguel.IdEntrega = 3;
            aluguel.IdDevolucao = 3;
            _aluguelService.Edit(aluguel);
            //Assert
            aluguel = _aluguelService.Get(3);
            Assert.AreEqual(DateTime.Parse("2023-02-01 23:30:00"), aluguel.DataHoraAluguel);
            Assert.AreEqual((uint)1, aluguel.IdPessoa);
            Assert.AreEqual("andamento", aluguel.Status);
            Assert.AreEqual((uint)2, aluguel.IdVeiculo);
            Assert.AreEqual(new DateTime(2023, 09, 3, 3, 30, 0), aluguel.DataHoraAvaliacaoProprietario); ;
            Assert.AreEqual((byte)3, aluguel.QtdEstrelasAvaliacaoProprietario);
            Assert.AreEqual(DateTime.Parse("2023-02-01 23:30:00"), aluguel.DataHoraAvaliacaoCliente);
            Assert.AreEqual((sbyte)1, aluguel.QtdEstrelasAvaliacaoCliente);
            Assert.AreEqual("um pouco de texto", aluguel.DescricaoAvaliacaoProprietario);
            Assert.AreEqual("um pouco de texto", aluguel.DescricaoAvaliacaoCliente);
            Assert.AreEqual((uint)3, aluguel.IdEntrega);
            Assert.AreEqual((uint)3, aluguel.IdDevolucao);

        }

        [TestMethod()]
        public void GetTest()
        {
            var aluguel = _aluguelService.Get(3);
            Assert.IsNotNull(aluguel);
            Assert.AreEqual(DateTime.Parse("2023-02-01 23:30:00"), aluguel.DataHoraAluguel);
            Assert.AreEqual((uint)1, aluguel.IdPessoa);
            Assert.AreEqual("andamento", aluguel.Status);
            Assert.AreEqual((uint)2, aluguel.IdVeiculo);
            Assert.AreEqual(DateTime.Parse("2023-02-01 23:30:00"), aluguel.DataHoraAvaliacaoProprietario); ;
            Assert.AreEqual((byte)3, aluguel.QtdEstrelasAvaliacaoProprietario);
            Assert.AreEqual(DateTime.Parse("2023-02-01 23:30:00"), aluguel.DataHoraAvaliacaoCliente);
            Assert.AreEqual((sbyte)1, aluguel.QtdEstrelasAvaliacaoCliente);
            Assert.AreEqual("um pouco de texto", aluguel.DescricaoAvaliacaoProprietario);
            Assert.AreEqual("um pouco de texto", aluguel.DescricaoAvaliacaoCliente);
            Assert.AreEqual((uint)3, aluguel.IdEntrega);
            Assert.AreEqual((uint)3, aluguel.IdDevolucao);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaAluguel = _aluguelService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaAluguel, typeof(IEnumerable<Aluguel>));
            Assert.IsNotNull(listaAluguel);
            Assert.AreEqual(3, listaAluguel.Count());
            var firstAluguel = listaAluguel.First();
            Assert.AreEqual((uint)1, firstAluguel.Id);
            Assert.AreEqual(DateTime.Parse("2021-09-02 03:30:00"), firstAluguel.DataHoraAluguel);
            Assert.AreEqual((uint)1, firstAluguel.IdPessoa);
            Assert.AreEqual("concluido", firstAluguel.Status);
            Assert.AreEqual((uint)2, firstAluguel.IdVeiculo);
            Assert.AreEqual(DateTime.Parse("2021-09-02 03:30:00"), firstAluguel.DataHoraAvaliacaoProprietario);
            Assert.AreEqual((byte)3, firstAluguel.QtdEstrelasAvaliacaoProprietario);
            Assert.AreEqual(DateTime.Parse("2021-09-02 03:30:00"), firstAluguel.DataHoraAvaliacaoCliente);
            Assert.AreEqual((sbyte)2, firstAluguel.QtdEstrelasAvaliacaoCliente);
            Assert.AreEqual("um pouco de texto", firstAluguel.DescricaoAvaliacaoProprietario);
            Assert.AreEqual("um pouco de texto", firstAluguel.DescricaoAvaliacaoCliente);
            Assert.AreEqual((uint)1, firstAluguel.IdEntrega);
            Assert.AreEqual((uint)1, firstAluguel.IdDevolucao);
        }
    }
}