using AutoMapper;
using CoAutoWeb.Models;
using Core;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Core;

namespace CoAutoWeb.Mappers
{
    public class VeiculoProfile : Profile
    {
        public VeiculoProfile()
        {
            CreateMap<VeiculoViewModel, Veiculo>().ReverseMap();
        }
    }
}