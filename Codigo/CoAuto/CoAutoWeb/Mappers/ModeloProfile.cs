using AutoMapper;
using CoAutoWeb.Models;
using Core;

namespace CoAutoWeb.Mappers;

public class ModeloProfile : Profile
{
    public ModeloProfile()
    {
        CreateMap<ModeloViewModel, Modelo>().ReverseMap();
    }
}
