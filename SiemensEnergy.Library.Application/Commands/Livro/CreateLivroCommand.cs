using MediatR;
using SiemensEnergy.Library.Application.Common;

namespace SiemensEnergy.Library.Application.Commands.Livro
{
    public class CreateLivroCommand : IRequest<Response>
    {
        #region Properties

        public string Titulo { get; set; }
        public int IdAutor { get; set; }
        public int IdGenero { get; set; }

        #endregion

        #region Constructor

        public CreateLivroCommand(string titulo, int idAutor, int idGenero)
        {
            Titulo = titulo;
            IdAutor = idAutor;
            IdGenero = idGenero;
        }

        #endregion
    }
}