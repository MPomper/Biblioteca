using MediatR;
using SiemensEnergy.Library.Application.Common;

namespace SiemensEnergy.Library.Application.Commands.Autor
{
    public class CreateAutorCommand : IRequest<Response>
    {
        #region Properties

        public string Nome { get; set; }

        #endregion

        #region Constructor

        public CreateAutorCommand(string nome)
        {
            Nome = nome;
        }

        #endregion
    }
}
