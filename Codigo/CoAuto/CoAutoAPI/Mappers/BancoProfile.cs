using AutoMapper;
using Core;
using CoAutoWeb.Models;

namespace CoAutoWeb.Mappers
{
    public class BancoProfile : Profile
    {
        public BancoProfile()
        {
            CreateMap<BancoViewModel, Banco>().ReverseMap();
        }
    }
}