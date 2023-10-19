using AutoMapper;
using Core;
using CoAutoWeb.Models;
using CoAutoAPI.Models;

namespace CoAutoWeb.Mappers
{
    public class PagamentoProfile : Profile
    {
        public PagamentoProfile()
        {
            CreateMap<PagamentoViewModel, Pagamento>().ReverseMap();
        }
    }
}