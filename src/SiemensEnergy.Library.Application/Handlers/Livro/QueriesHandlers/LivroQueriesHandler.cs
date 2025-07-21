using AutoMapper;
using MediatR;
using SiemensEnergy.Library.Application.Commands.Livro;
using SiemensEnergy.Library.Application.Interfaces;
using SiemensEnergy.Library.Application.ViewModels.Genero;
using SiemensEnergy.Library.Application.ViewModels.Livro;
using static SiemensEnergy.Library.Application.Queries.Livro.LivroQueries;

namespace SiemensEnergy.Library.Application.Handlers.Livro.QueriesHandlers
{
    public class LivroQueriesHandler : IRequestHandler<GetLivroByIdQuery, LivroViewModel?>,
                                       IRequestHandler<GetLivroByFiltroQuery, IEnumerable<LivroViewModel?>>,
                                       IRequestHandler<GetAllLivrosQuery, IEnumerable<LivroViewModel?>>
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IMapper _mapper;

        public LivroQueriesHandler(ILivroRepository livroRepository, IMapper mapper)
        {
            _livroRepository = livroRepository;
            _mapper = mapper;
        }

        public async Task<LivroViewModel?> Handle(GetLivroByIdQuery request, CancellationToken cancellationToken)
        {
            var livro = await _livroRepository.GetByIdAsync(request.Id);
            return livro is null ? null : _mapper.Map<LivroViewModel>(livro);
        }

        public async Task<IEnumerable<LivroViewModel?>> Handle(GetLivroByFiltroQuery request, CancellationToken cancellationToken)
        {
            //var livro = _mapper.Map<Domain.Entities.Livro>(command);

            var filtro = new Domain.Entities.Livro
            {
                Titulo = request.dto.Titulo ?? "",
                IdAutor = request.dto.IdAutor ?? 0,
                IdGenero = request.dto.IdGenero ?? 0
            };

            var livros = await _livroRepository.GetByFiltroAsync(filtro);
            return livros is null ? null : _mapper.Map<List<LivroViewModel>>(livros);
        }

        public async Task<IEnumerable<LivroViewModel?>> Handle(GetAllLivrosQuery request, CancellationToken cancellationToken)
        {
            var livros = await _livroRepository.GetAllAsync();
            return livros is null ? null : _mapper.Map<List<LivroViewModel>>(livros);
        }
    }
}