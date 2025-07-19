using AutoMapper;
using SiemensEnergy.Library.Application.Commands.Genero;
using SiemensEnergy.Library.Application.DTOs.Genero;
using SiemensEnergy.Library.Application.ViewModels.Genero;
using SiemensEnergy.Library.Domain.Entities;

namespace SiemensEnergy.Library.Application.Mapper
{
    public class GeneroProfile : Profile
    {
        public GeneroProfile()
        {
            CreateMap<CreateGeneroDto, CreateGeneroCommand>();
            CreateMap<UpdateGeneroDto, UpdateGeneroCommand>();

            CreateMap<Genero, GeneroViewModel>()
            .ForMember(dest => dest.Livros, opt => opt.MapFrom(src =>
                src.Livros.Select(l => l.Titulo).ToList()));
        }
    }
}
