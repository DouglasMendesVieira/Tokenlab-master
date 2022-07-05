using AutoMapper;
using Tokenlab.Application.Dtos;
using Tokenlab.Domain;

namespace Tokenlab.API.Helpers
{
    public class TokenlabProfile : Profile
    {
        public TokenlabProfile()
        {
            CreateMap<Evento, EventoDto>().ReverseMap();
            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
            CreateMap<Palestrante, PalestranteDto>().ReverseMap();
        }
    }
}