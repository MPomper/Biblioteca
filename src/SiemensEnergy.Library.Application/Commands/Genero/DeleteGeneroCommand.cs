using MediatR;
using SiemensEnergy.Library.Application.Common;

namespace SiemensEnergy.Library.Application.Commands.Genero
{
    public class DeleteGeneroCommand : IRequest<Response>
    {
        #region Properties

        public int Id { get; set; }

        #endregion

        #region Constructor

        public DeleteGeneroCommand(int id)
        {
            Id = id;
        }

        #endregion
    }
}
