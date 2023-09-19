using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
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
        public async Task<uint> Create(Aluguel aluguel)
        {
            await _context.AddAsync(aluguel);
            await _context.SaveChangesAsync();
            return aluguel.Id;
        }

        // <summary>
        /// Deleta um Aluguel
        /// </summary>
        /// <param name="id do Aluguel ">deleta o Aluguel </param>
        /// <returns></returns>
        public async Task Delete(uint idAluguel)
        {
            var aluguel = await _context.Aluguels.
            FindAsync(idAluguel);

            if (aluguel == null) return;

            _context.Remove(aluguel);
            await _context.SaveChangesAsync();

        }

        // <summary>
        /// Edita um Aluguel
        /// </summary>
        /// <param name="Aluguel"></param>
        /// <exception cref="ServiceException"></exception>
        public async Task Edit(Aluguel aluguel)
        {
            _context.Update(aluguel);

            await _context.SaveChangesAsync();
        }

        // <summary>
        /// busca um Aluguel 
        /// </summary>
        /// <param name="id do Aluguel ">dados do Aluguel</param>
        /// <returns></returns>
        public async Task<Aluguel> Get(uint idAluguel)
        {
            return await _context.Aluguels.FindAsync(idAluguel);
        }

        /// <summary>
        /// Obtém todos os Aluguel
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Aluguel>> GetAll()
        {
            return await _context.Aluguels.ToListAsync();
        }
    }
}
