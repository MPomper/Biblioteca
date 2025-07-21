using MediatR;
using SiemensEnergy.Library.Application.ViewModels.Genero;

namespace SiemensEnergy.Library.Application.Queries.Genero
{
    public class GeneroQueries
    {
        public record GetGeneroByIdQuery(int Id) : IRequest<GeneroViewModel?>;
        public record GetAllGenerosQuery() : IRequest<IEnumerable<GeneroViewModel?>>;
    }
}
