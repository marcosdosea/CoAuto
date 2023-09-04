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
        private readonly CoAutoContext context;

        public VeiculoService(CoAutoContext context)
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

        public Veiculo delete(int idVeiculo)
        {
            var _veiculo = context.Veiculos.Find(idVeiculo);
            context.Remove(_veiculo);
            context.SaveChanges();
            return context.Veiculos.Find(idVeiculo);
        }
    }
}
