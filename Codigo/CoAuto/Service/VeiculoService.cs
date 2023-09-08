using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service

/// <summary>
/// Cria um novo Veículo
/// </summary>
/// <param name="veiculo">dados do Veículo</param>
/// <returns>id do Veículo</returns>

{
    public class VeiculoService : IVeiculoService
    {
        private readonly CoAutoContext _context;

        public VeiculoService(CoAutoContext context)
        {
            _context = context;
        }

        // <summary>
        /// Insere um novo veículo
        /// </summary>
        /// <param name="veiculo">dados do veiculo</param>
        /// <returns></returns>

        public int Create(Veiculo veiculo)
        {
            _context.Add(veiculo);
            _context.SaveChanges();
            return (int)veiculo.Id;
        }

        // <summary>
        /// Deleta um veículo
        /// </summary>
        /// <param name="id da veículo ">deleta o veículo </param>
        /// <returns></returns>

        public void Delete(int idVeiculo)
        {
            var _veiculo = _context.Veiculos.Find(idVeiculo);
            _context.Remove(_veiculo);
            _context.SaveChanges();
        }

        // <summary>
        /// Edita um veículo
        /// </summary>
        /// <param name="veículo"></param>
        /// <exception cref="ServiceException"></exception>

        public void Edit(Veiculo veiculo)
        {
            _context.Update(veiculo);
            _context.SaveChanges();

        }

        // <summary>
        /// busca um veículo 
        /// </summary>
        /// <param name="id do veículo ">dados do veículo</param>
        /// <returns></returns>

        public Veiculo Get(int idVeiculo)
        {
            return _context.Veiculos.Find(idVeiculo);
           
        }

        /// <summary>
        /// Obtém todos veículo
        /// </summary>
        /// <returns></returns>

        public IEnumerable<Veiculo> GetAll()
        {
            return _context.Veiculos;
        }
    }
}
