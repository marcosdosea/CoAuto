using AutoMapper;
using CoAutoWeb.Models;
using Core;

namespace CoAutoWeb.Mappers
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile()
        {
            CreateMap<PessoaModel, Pessoa>().ReverseMap();
        }
    }
}