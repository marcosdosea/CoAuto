using Core;
using Core.Service;

namespace Service


/// <summary>
/// Manter dados de Aluguel no banco de dados
/// </summary>
{
    public class AluguelService : IAluguelService
    {

        private readonly CoAutoContext _context;

        public AluguelService(CoAutoContext context)
        {
            _context = context;
        }


        // <summary>
        /// Insere uma novo aluguel
        /// </summary>
        /// <param name="aluguel">dados da aluguel</param>
        /// <returns></returns>
        public int Create(Aluguel aluguel)
        {
            _context.Add(aluguel);
            _context.SaveChanges();
            return aluguel.Id;
        }

        // <summary>
        /// Deleta um aluguel
        /// </summary>
        /// <param name="id do aluguel ">deleta o aluguel </param>
        /// <returns></returns>
        public void Delete(int idaluguel)
        {
            var _aluguel = _context.Aluguels.Find(idaluguel);
            _context.Remove(_aluguel);
            _context.SaveChanges();
        }

        // <summary>
        /// busca um aluguel 
        /// </summary>
        /// <param name="id do aluguel ">dados do aluguel</param>
        /// <returns></returns>
        public Aluguel Get(int id)
        {
            return _context.Aluguels.Find(id);
        }
        /// <summary>
        /// Obtém todos alugueis
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Aluguel> GetAll()
        {
            return _context.Aluguels;
        }
    }
}

