using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class MarcaService : IMarcaService
    {
        private readonly CoAutoContext _context;

        public MarcaService(CoAutoContext context)
        {
            _context = context;
        }

        // <summary>
        /// Insere uma nova marca 
        /// </summary>
        /// <param name="marca">dados da marca</param>
        /// <returns></returns>
        public async Task<uint> Create(Marca marca)
        {
            await _context.AddAsync(marca);
            await _context.SaveChangesAsync();
            return marca.Id;
        }

        // <summary>
        /// Deleta uma marca
        /// </summary>
        /// <param name="id da marca ">deleta a marca </param>
        /// <returns></returns>
        public async Task Delete(uint idMarca)
        {
            var marca = await _context.Marcas.
            FindAsync(idMarca);

            if (marca == null) return;

            _context.Remove(marca);
            await _context.SaveChangesAsync();

        }

        // <summary>
        /// Edita uma marca
        /// </summary>
        /// <param name="marca"></param>
        /// <exception cref="ServiceException"></exception>
        public async Task Edit(Marca marca)
        {
            _context.Update(marca);

            await _context.SaveChangesAsync();
        }

        // <summary>
        /// busca uma marca 
        /// </summary>
        /// <param name="id da marca ">dados da marca</param>
        /// <returns></returns>
        public async Task<Marca> Get(uint idMarca)
        {
            return await _context.Marcas.FindAsync(idMarca);
        }

        /// <summary>
        /// Obtém todas as marca
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Marca>> GetAll()
        {
            return await _context.Marcas.ToListAsync();
        }
    }
}
