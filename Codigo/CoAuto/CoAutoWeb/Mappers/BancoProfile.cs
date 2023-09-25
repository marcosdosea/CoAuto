using AutoMapper;
using CoAutoWeb.Models;
using Core;

namespace CoAutoWeb.Mappers;

public class BancoProfile : Profile
{
    public BancoProfile()
    {
        CreateMap<BancoViewModel, Banco>().ReverseMap();
    }
}
