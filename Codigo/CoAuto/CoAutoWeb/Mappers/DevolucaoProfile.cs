using AutoMapper;
using CoAutoWeb.Models;
using Core;

namespace CoAutoWeb.Mappers;

public class DevolucaoProfile : Profile
{
    public DevolucaoProfile()
    {
        CreateMap<DevolucaoViewModel, Devolucao>().ReverseMap();
    }
}
