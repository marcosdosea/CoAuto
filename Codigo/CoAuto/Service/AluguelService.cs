using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class AluguelService : IAluguelService
    {
        private readonly CoAutoContext context;

        public AluguelService(CoAutoContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Cria um novo aluguel
        /// </summary>
        /// <param name="aluguel">dados do aluguel</param>
        /// <returns>id do Aluguel</returns>

        public int Create(Aluguel aluguel)
        {
            context.Add(aluguel);
            context.SaveChanges();
            return aluguel.Id;
        }

        public void delete(Aluguel aluguel)
        {
            context.Remove(aluguel);
            context.SaveChanges();
        }

        public Aluguel Get(int idAluguel)
        {
            return context.Aluguels.Find(idAluguel);

        }

        /// <summary>
        /// Busca todos os Aluguels na base de dados
        /// </summary>
        /// <returns>lista de alugueis</returns> 

        public IEnumerable<Aluguel> GetAll()
        {
            return context.Aluguels.AsNoTracking();
        }

        /// <summary>
        /// Edita os dados do Aluguel na base de dados
        /// </summary>
        /// <param name="aluguel"></param>

        public void Edit(Aluguel aluguel)
        {
            context.Update(aluguel);
            context.SaveChanges();
        }

        /// <summary>
        /// Remove os dados do Aluguel na base de dados
        /// </summary>
        /// <param name="idAluguel"></param>

        public Aluguel Delete(int idAluguel)
        {
            var _aluguel = context.Aluguels.Find(idAluguel);
            context.Remove(_aluguel);
            context.SaveChanges();
            return context.Aluguels.Find(idAluguel);
        }
    }
}
