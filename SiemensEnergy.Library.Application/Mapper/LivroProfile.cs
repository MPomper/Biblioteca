using AutoMapper;
using SiemensEnergy.Library.Application.Commands.Livro;
using SiemensEnergy.Library.Application.DTOs.Livro;
using SiemensEnergy.Library.Application.ViewModels.Livro;
using SiemensEnergy.Library.Domain.Entities;

namespace SiemensEnergy.Library.Application.Mapper
{
    public class LivroProfile : Profile
    {
        public LivroProfile()
        {
            CreateMap<CreateLivroDto, CreateLivroCommand>();
            CreateMap<UpdateLivroDto, UpdateLivroCommand>();

            CreateMap<Livro, LivroViewModel>()
                .ForMember(dest => dest.Autor, opt => opt.MapFrom(src => src.Autor!.Nome))
                .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => src.Genero!.Descricao));
        }
    }
}
