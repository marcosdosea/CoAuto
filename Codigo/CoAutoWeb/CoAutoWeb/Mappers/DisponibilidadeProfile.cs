using AutoMapper;
using Core;
using CoAutoWeb.Models;


namespace CoAutoWeb.Mappers
{
    public class DisponibilidadeProfile : Profile
    {
        public DisponibilidadeProfile() 
        {
            CreateMap<DisponibilidadeViewModel, Disponibilidade>().ReverseMap();
        } 
    }
}
