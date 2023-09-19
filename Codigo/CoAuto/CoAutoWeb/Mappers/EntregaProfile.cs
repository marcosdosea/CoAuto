using AutoMapper;
using CoAutoWeb.Models;
using Core;

namespace CoAutoWeb.Mappers;

public class EntregaProfile : Profile
{
    public EntregaProfile()
    {
        CreateMap<EntregaViewModel, Entrega>().ReverseMap();
    }
}
