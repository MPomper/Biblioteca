using MediatR;
using SiemensEnergy.Library.Application.Common;

namespace SiemensEnergy.Library.Application.Commands.Genero
{
    public class UpdateGeneroCommand : IRequest<Response>
    {
        #region Properties

        public int Id { get; set; }
        public string Descricao { get; set; }

        #endregion

        #region Constructor

        public UpdateGeneroCommand(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        #endregion
    }
}