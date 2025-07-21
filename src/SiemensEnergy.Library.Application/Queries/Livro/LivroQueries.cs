using MediatR;
using SiemensEnergy.Library.Application.DTOs.Livro;
using SiemensEnergy.Library.Application.ViewModels.Livro;

namespace SiemensEnergy.Library.Application.Queries.Livro
{
    public class LivroQueries
    {
        public record GetLivroByIdQuery(int Id) : IRequest<LivroViewModel?>;
        public record GetLivroByFiltroQuery(FiltroLivroDto dto) : IRequest<IEnumerable<LivroViewModel?>>;
        public record GetAllLivrosQuery() : IRequest<IEnumerable<LivroViewModel?>>;
    }
}
