using Core.Service;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Service.Tests
{
    [TestClass()]
    public class DisponibilidadeServiceTests
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
            var bancos = new List<Disponibilidade>
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

            _context.AddRange(bancos);
            _context.SaveChanges();

            _bancoService = new BancoService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            _bancoService.Create(new Disponibilidade()
            {
                Id = 4,
                DataHoraInicio = new DateTime(2021, 09, 5, 18, 15, 0),
                DataHoraFim = new DateTime(2023, 09, 5, 18, 15, 0),
                IdVeiculo = 4
            });
            // Assert
            Assert.AreEqual(4, _bancoService.GetAll().Count());
            var disponibilidade = _bancoService.Get(4);
            Assert.AreEqual("Nubank", Disponibilidade.);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            _bancoService.Delete(1);
            // Assert
            Assert.AreEqual(2, _bancoService.GetAll().Count());
            var disponibilidade = _bancoService.Get(1);
            Assert.AreEqual(null, disponibilidade);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var disponibilidade = _bancoService.Get(3);
            disponibilidade.Nome = "Inter";
            _bancoService.Edit(disponibilidade);

            //Assert
            disponibilidade = _bancoService.Get(3);
            Assert.AreEqual("Inter", disponibilidade.Nome);
        }

        [TestMethod()]
        public void GetTest()
        {
            var disponibilidade = _bancoService.Get(3);
            Assert.IsNotNull(disponibilidade);
            Assert.AreEqual("Bradesco", disponibilidade.Nome);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Act
            var listaDisponibilidade = _bancoService.GetAll();
            // Assert
            Assert.IsInstanceOfType(listaDisponibilidade, typeof(IEnumerable<Disponibilidade>));
            Assert.IsNotNull(listaDisponibilidade);
            Assert.AreEqual(3, listaDisponibilidade.Count());
            var firstDisponibilidade = listaDisponibilidade.First();
            Assert.AreEqual((uint)1, firstDisponibilidade.Id);
            Assert.AreEqual("Banco do Brasil", firstDisponibilidade.Nome);
        }
        [TestMethod()]
        public void GetById()
        {
            //Act
            var disponibilidade = _bancoService.GetById(3);
            //Assert
            Assert.IsNotNull(disponibilidade);
            Assert.AreEqual(1, disponibilidade.Count());
            var firstDisponibilidade = disponibilidade.First();
            Assert.AreEqual((uint)3, firstDisponibilidade.Id);
            Assert.AreEqual("Banco do Brasil", firstDisponibilidade.Nome);
        }
    }
}