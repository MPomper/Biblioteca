using MediatR;
using SiemensEnergy.Library.Application.Common;

namespace SiemensEnergy.Library.Application.Commands.Genero
{
    public class CreateGeneroCommand : IRequest<Response>
    {
        #region Properties

        public string Descricao { get; set; }

        #endregion

        #region Constructor

        public CreateGeneroCommand(string descricao)
        {
            Descricao = descricao;
        }

        #endregion
    }
}
