using AutoMapper;
using CoAutoWeb.Models;
using Core;

namespace CoAutoWeb.Mappers
{
    public class PagamentoProfile : Profile
    {
        public PagamentoProfile()
        {
            CreateMap<PagamentoViewModel,Pagamento>().ReverseMap();
        }
    }
}
