using MediatR;
using SiemensEnergy.Library.Application.Common;

namespace SiemensEnergy.Library.Application.Commands.Livro
{
    public class DeleteLivroCommand : IRequest<Response>
    {
        #region Properties

        public int Id { get; set; }

        #endregion

        #region Constructor

        public DeleteLivroCommand(int id)
        {
            Id = id;
        }

        #endregion
    }
}
