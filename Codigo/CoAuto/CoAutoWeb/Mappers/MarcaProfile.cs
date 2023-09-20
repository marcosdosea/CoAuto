using AutoMapper;
using CoAutoWeb.Models;
using Core;

namespace CoAutoWeb.Mappers;

public class MarcaProfile : Profile
{
    public MarcaProfile()
    {
        CreateMap<MarcaViewModel, Marca>().ReverseMap();
    }
}
