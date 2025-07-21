using MediatR;
using SiemensEnergy.Library.Application.Common;

namespace SiemensEnergy.Library.Application.Commands.Autor
{
    public class DeleteAutorCommand : IRequest<Response>
    {
        #region Properties

        public int Id { get; set; }

        #endregion

        #region Constructor

        public DeleteAutorCommand(int id)
        {
            Id = id;
        }

        #endregion
    }
}
