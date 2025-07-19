using AutoMapper;
using MediatR;
using SiemensEnergy.Library.Application.Interfaces;
using SiemensEnergy.Library.Application.ViewModels.Genero;
using static SiemensEnergy.Library.Application.Queries.Genero.GeneroQueries;

namespace SiemensEnergy.Library.Application.Handlers.Genero.QueriesHandlers
{
    public class GeneroQueriesHandler : IRequestHandler<GetGeneroByIdQuery, GeneroViewModel?>,
                                       IRequestHandler<GetAllGenerosQuery, IEnumerable<GeneroViewModel?>>
    {
        private readonly IGeneroRepository _generoRepository;
        private readonly IMapper _mapper;

        public GeneroQueriesHandler(IGeneroRepository generoRepository, IMapper mapper)
        {
            _generoRepository = generoRepository;
            _mapper = mapper;
        }
        public async Task<GeneroViewModel?> Handle(GetGeneroByIdQuery request, CancellationToken cancellationToken)
        {
            var genero = await _generoRepository.GetByIdAsync(request.Id);
            return genero is null ? null : _mapper.Map<GeneroViewModel>(genero);
        }

        public async Task<IEnumerable<GeneroViewModel?>> Handle(GetAllGenerosQuery request, CancellationToken cancellationToken)
        {
            var generos = await _generoRepository.GetAllAsync();
            return generos is null ? null : _mapper.Map<List<GeneroViewModel>>(generos);
        }
    }
}