using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
/// <summary>
/// Cria um novo Aluguel
/// </summary>
/// <param name="Aluguel">dados do Aluguel</param>
/// <returns>id do Aluguel</returns>

{
    public class AluguelService : IAluguelService
    {
        private readonly CoAutoContext _context;

        public AluguelService(CoAutoContext context)
        {
            _context = context;
        }

        // <summary>
        /// Insere um novo Aluguel
        /// </summary>
        /// <param name="Aluguel">dados do Aluguel</param>
        /// <returns></returns>

        public int Create(Aluguel aluguel)
        {
            _context.Add(aluguel);
            _context.SaveChanges();
            return (int)aluguel.Id;
        }

        // <summary>
        /// Deleta um Aluguel
        /// </summary>
        /// <param name="id da Aluguel ">deleta o Aluguel </param>
        /// <returns></returns>

        public void Delete(int idAluguel)
        {
            var _aluguel = _context.Aluguels.Find(idAluguel);
            _context.Remove(_aluguel);
            _context.SaveChanges();
        }

        // <summary>
        /// Edita um Aluguel
        /// </summary>
        /// <param name="Aluguel"></param>
        /// <exception cref="ServiceException"></exception>

        public void Edit(Aluguel aluguel)
        {
            _context.Update(aluguel);
            _context.SaveChanges();

        }

        // <summary>
        /// busca um Aluguel 
        /// </summary>
        /// <param name="id do Aluguel ">dados do Aluguel</param>
        /// <returns></returns>

        public Aluguel Get(int idAluguel)
        {
            return _context.Aluguels.Find(idAluguel);

        }

        /// <summary>
        /// Obtém todos Aluguel
        /// </summary>
        /// <returns></returns>

        public IEnumerable<Aluguel> GetAll()
        {
            return _context.Aluguels;
        }
    }
}
