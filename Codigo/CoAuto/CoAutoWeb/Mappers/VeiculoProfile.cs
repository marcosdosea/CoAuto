using AutoMapper;
using CoAutoWeb.Models;
using Core;
using Core.DTO;

namespace CoAutoWeb.Mappers;

public class VeiculoProfile : Profile
{
    public VeiculoProfile()
    {
        CreateMap<VeiculoViewModel, Veiculo>().ReverseMap();
        CreateMap<VeiculosSimplesDTO,VeiculoListagemViewModel>().ReverseMap();
    }
}