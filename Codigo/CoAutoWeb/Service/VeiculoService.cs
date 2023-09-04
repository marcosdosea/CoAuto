using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class VeiculoService : IVeiculoService
    {
        private readonly BibliotecaContext context;

        public VeiculoService(BibliotecaContext context)
        {
            this.context = context;
        }

        public int create(Veiculo veiculo)
        {
            context.Add(veiculo);
            context.SaveChanges();
            return veiculo.Id;
        }

        public void delete(Veiculo veiculo)
        {
            context.Remove(veiculo);
            context.SaveChanges();
        }

        public Veiculo get(int idVeiculo)
        {
            return context.Veiculos.Find(idVeiculo);
           
        }

        public IEnumerable<Veiculo> getAll()
        {
            return context.Veiculos.AsNoTracking();
        }

        public void edit(Veiculo veiculo)
        {
            context.Update(veiculo);
            context.SaveChanges();

        }
    }
}
