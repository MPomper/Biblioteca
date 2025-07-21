using AutoMapper;
using SiemensEnergy.Library.Application.Commands.Autor;
using SiemensEnergy.Library.Application.DTOs.Autor;
using SiemensEnergy.Library.Application.ViewModels.Autor;
using SiemensEnergy.Library.Domain.Entities;

namespace SiemensEnergy.Library.Application.Mapper
{
    public class AutorProfile : Profile
    {
        public AutorProfile()
        {
            CreateMap<CreateAutorDto, CreateAutorCommand>();
            CreateMap<UpdateAutorDto, UpdateAutorCommand>();

            CreateMap<Autor, AutorViewModel>()
            .ForMember(dest => dest.Livros, opt => opt.MapFrom(src =>
                src.Livros.Select(l => l.Titulo).ToList()));
        }
    }
}
