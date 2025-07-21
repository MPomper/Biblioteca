using AutoMapper;
using MediatR;
using SiemensEnergy.Library.Application.Interfaces;
using SiemensEnergy.Library.Application.ViewModels.Autor;
using static SiemensEnergy.Library.Application.Queries.Autor.AutorQueries;

namespace SiemensEnergy.Library.Application.Handlers.Autor.QueriesHandlers
{
    public class AutorQueriesHandler : IRequestHandler<GetAutorByIdQuery, AutorViewModel?>,
                                       IRequestHandler<GetAllAutoresQuery, IEnumerable<AutorViewModel?>>
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IMapper _mapper;

        public AutorQueriesHandler(IAutorRepository autorRepository, IMapper mapper)
        {
            _autorRepository = autorRepository;
            _mapper = mapper;
        }
        public async Task<AutorViewModel?> Handle(GetAutorByIdQuery request, CancellationToken cancellationToken)
        {
            var autor = await _autorRepository.GetByIdAsync(request.Id);
            return autor is null ? null : _mapper.Map<AutorViewModel>(autor);
        }

        public async Task<IEnumerable<AutorViewModel?>> Handle(GetAllAutoresQuery request, CancellationToken cancellationToken)
        {
            var autores = await _autorRepository.GetAllAsync();
            return autores is null ? null : _mapper.Map< List<AutorViewModel>>(autores);
        }
    }
}