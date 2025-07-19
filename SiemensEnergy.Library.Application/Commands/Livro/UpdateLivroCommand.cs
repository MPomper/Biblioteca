using MediatR;
using SiemensEnergy.Library.Application.Common;

namespace SiemensEnergy.Library.Application.Commands.Livro
{
    public class UpdateLivroCommand : IRequest<Response>
    {
        #region Properties

        public int Id { get; set; }
        public string Titulo { get; set; }
        public int IdAutor { get; set; }
        public int IdGenero { get; set; }

        #endregion

        #region Constructor

        public UpdateLivroCommand(int id, string titulo, int idAutor, int idGenero)
        {
            Id = id;
            Titulo = titulo;
            IdAutor = idAutor;
            IdGenero = idGenero;
        }

        #endregion
    }
}