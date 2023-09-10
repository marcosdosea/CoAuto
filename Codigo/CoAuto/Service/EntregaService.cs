using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Service
{
    public class EntregaService : IEntregaService
    {
        private readonly CoAutoContext _context;

        public EntregaService(CoAutoContext context)
        {
            _context = context;
        }

        // <summary>
        /// Insere uma nova entrega
        /// </summary>
        /// <param name="entrega">dados da entrega</param>
        /// <returns></returns>
        public async Task<int> Create(Entrega entrega)
        {
            await _context.AddAsync(entrega);
            await _context.SaveChangesAsync();
            return (int)entrega.Id;
        }

        // <summary>
        /// Deleta uma entrega
        /// </summary>
        /// <param name="id da entrega ">deleta a entrega </param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            var entrega = await _context.Entregas.
            FindAsync(id);

            if (entrega == null) return;

            _context.Remove(entrega);
            await _context.SaveChangesAsync();
        }

        // <summary>
        /// Edita uma entrega
        /// </summary>
        /// <param name="entrega"></param>
        /// <exception cref="ServiceException"></exception>
        public async Task Edit(Entrega entrega)
        {
            _context.Update(entrega);

            await _context.SaveChangesAsync();
        }

        // <summary>
        /// busca uma entrega 
        /// </summary>
        /// <param name="id da entrega ">dados da entrega</param>
        /// <returns></returns>
        public async Task<Entrega> Get(int idEntrega)
        {
            return await _context.Entregas.FindAsync(idEntrega);
        }

        /// <summary>
        /// Obtém todas as entregas
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Entrega>> GetAll()
        {
            return await _context.Entregas.ToListAsync();
        }
    }
}
