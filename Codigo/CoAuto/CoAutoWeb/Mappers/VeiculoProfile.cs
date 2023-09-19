using AutoMapper;
using CoAutoWeb.Models;
using Core;

namespace CoAutoWeb.Mappers;

public class VeiculoProfile : Profile
{
    public VeiculoProfile()
    {
        CreateMap<VeiculoViewModel, Veiculo>().ReverseMap();
    }
}