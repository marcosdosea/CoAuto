using AutoMapper;
using CoAutoWeb.Models;
using Core;
using System.Globalization;

namespace CoAutoWeb.Mappers
{
    public class PerfilProfile : Profile
    {
        public PerfilProfile()
        {
            CreateMap<Pagamento, PagamentoCardListViewModel>()
                .ForMember(destiny => destiny.Valor, origin => origin.MapFrom(src => src.Valor.ToString("C", new CultureInfo("pt-BR"))));

            CreateMap<Veiculo, VeiculoCardListViewModel>()
                .ForMember(destiny => destiny.Placa, origin => origin.MapFrom(src => src.Placa.ToUpper()));

            CreateMap<Modelo, ModeloCardListViewModel>()
                .ForMember(destiny => destiny.Nome, origin => origin.MapFrom(src => src.Nome.ToUpper()));

            CreateMap<Aluguel, AluguelCardListViewModel>()
                .ForMember(destiny => destiny.Status, origin => origin.MapFrom(src => src.Status.ToString()))
                .ForMember(destiny => destiny.DataHoraAluguel, origin => origin.MapFrom(src => src.DataHoraAluguel));

            CreateMap<Pessoa, PerfilViewModel>();
        }
    }
}
