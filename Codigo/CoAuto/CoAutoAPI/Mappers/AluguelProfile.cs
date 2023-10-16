using AutoMapper;
using Core;
using CoAutoWeb.Models;

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