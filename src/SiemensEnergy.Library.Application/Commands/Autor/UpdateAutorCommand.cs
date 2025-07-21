using MediatR;
using SiemensEnergy.Library.Application.Common;

namespace SiemensEnergy.Library.Application.Commands.Autor
{
    public class UpdateAutorCommand : IRequest<Response>
    {
        #region Properties

        public int Id { get; set; }
        public string Nome { get; set; }

        #endregion

        #region Constructor

        public UpdateAutorCommand(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        #endregion
    }
}