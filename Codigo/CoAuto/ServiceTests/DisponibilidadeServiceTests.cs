using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests
{
    [TestClass()]
    public class DisponibilidadeServiceTests
    {
        private CoAutoContext _context;
        private IDisponibilidadeService _disponibilidadeService;


        [TestInitialize()]
        public void Initialize() 
        { 
            var builder = new DbContextOptionsBuilder<CoAutoContext>();
            builder.UseInMemoryDatabase("coauto");
            var options = builder.Options;

            _context = new CoAutoContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var disponibilidades = new List<Disponibilidade>
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
                 },
            };


            _context.AddRange(disponibilidades);
            _context.SaveChanges();

            _disponibilidadeService = new DisponibilidadeService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {

            _disponibilidadeService.Create(new Disponibilidade()
            {
                Id = 1,
                DataHoraInicio = new DateTime(2021, 09, 4, 14, 45, 0),
                DataHoraFim = new DateTime(2024, 09, 05, 18, 15, 0),
                IdVeiculo = 4
            });
            // Asserts
            Assert.AreEqual(4, _disponibilidadeService.GetAll().Count());
            var disponibilidade = _disponibilidadeService.Get(4);
            Assert.AreEqual((uint)1,disponibilidade.Id);
            Assert.AreEqual(DateTime.Parse("2021-09-04 14:45:00"), disponibilidade.DataHoraInicio);
            Assert.AreEqual(DateTime.Parse("2024-05-18 18:15:00"), disponibilidade.DataHoraFim);
            Assert.AreEqual((uint)4, disponibilidade.IdVeiculo);
            

        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            _disponibilidadeService.Delete(2);
            // Assert
            Assert.AreEqual(2, _disponibilidadeService.GetAll().Count());
            var disponibilidade = _disponibilidadeService.Get(2);
            Assert.AreEqual(null, disponibilidade);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var disponibilidade = _disponibilidadeService.Get(3);
            disponibilidade.Id = 3;
            disponibilidade.DataHoraInicio = DateTime.Parse("2021-09-04 14:45:00");
            _disponibilidadeService.Edit(disponibilidade);

            //Assert
            disponibilidade = _disponibilidadeService.Get(3);
            Assert.IsNotNull(disponibilidade);
            Assert.AreEqual(DateTime.Parse("2023-10-18 18:15:00"), disponibilidade.DataHoraInicio);
            Assert.AreEqual(DateTime.Parse("2024-10-18 18:15:00"), disponibilidade.DataHoraFim);
        }

        [TestMethod()]
        public void GetTest()
        {
            var disponibilidade = _disponibilidadeService.Get(1);
            Assert.IsNotNull(disponibilidade);
            Assert.AreEqual((uint)1, disponibilidade.Id);
            Assert.AreEqual((uint)1, disponibilidade.IdVeiculo);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            var listaDisponibilidade = _disponibilidadeService.GetAll();

            Assert.IsInstanceOfType(listaDisponibilidade, typeof(IEnumerable<Disponibilidade>));
            Assert.IsNotNull(listaDisponibilidade);
            Assert.AreEqual(3, listaDisponibilidade.Count());
            Assert.AreEqual((uint)1, listaDisponibilidade.First().Id);
            Assert.AreEqual((uint)1, listaDisponibilidade.First().IdVeiculo);


        }
    }
}