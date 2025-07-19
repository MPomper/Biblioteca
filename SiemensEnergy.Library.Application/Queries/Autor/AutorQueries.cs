using MediatR;
using SiemensEnergy.Library.Application.ViewModels.Autor;

namespace SiemensEnergy.Library.Application.Queries.Autor
{
    public class AutorQueries
    {
        public record GetAutorByIdQuery(int Id) : IRequest<AutorViewModel?>;
        public record GetAllAutoresQuery() : IRequest<IEnumerable<AutorViewModel?>>;
    }
}
