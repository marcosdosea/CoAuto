using AutoMapper;
using CoAutoWeb.Models;
using Core;


namespace CoAutoWeb.Mappers
{
    public class AluguelProfile : Profile
    {
        public AluguelProfile()
        {
            CreateMap<AluguelViewModel, Aluguel>().ReverseMap();
        }
    }
}