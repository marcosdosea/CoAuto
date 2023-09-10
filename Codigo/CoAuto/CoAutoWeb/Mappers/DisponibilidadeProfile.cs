using AutoMapper;
using CoAutoWeb.Models;
using Core;


namespace CoAutoWeb.Mappers
{
    public class DisponibilidadeProfile : Profile
    {
        public DisponibilidadeProfile()
        {
            CreateMap<DisponibilidadeModel, Disponibilidade>().ReverseMap();
        }
    }
}
