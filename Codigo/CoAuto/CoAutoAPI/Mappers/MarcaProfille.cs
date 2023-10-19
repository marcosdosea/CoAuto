using AutoMapper;
using Core;
using CoAutoWeb.Models;

namespace CoAutoWeb.Mappers
{
    public class MarcaProfile : Profile
    {
        public MarcaProfile()
        {
            CreateMap<MarcaViewModel, Marca>().ReverseMap();
        }
    }
}