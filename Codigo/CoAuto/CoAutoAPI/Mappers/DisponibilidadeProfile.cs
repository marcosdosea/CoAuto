using AutoMapper;
using Core;
using CoAutoAPI.Models;

namespace CoAutoWeb.Mappers;

public class DisponibilidadeProfile : Profile
{
        public DisponibilidadeProfile()
        {
            CreateMap<DisponibilidadeViewModel, Disponibilidade>().ReverseMap();
        }
}
