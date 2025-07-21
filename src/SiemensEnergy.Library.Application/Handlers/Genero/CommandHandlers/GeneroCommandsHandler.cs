using MediatR;
using SiemensEnergy.Library.Application.Commands.Genero;
using SiemensEnergy.Library.Application.Interfaces;
using SiemensEnergy.Library.Application.Common;
using AutoMapper;

namespace SiemensEnergy.Library.Application.Handlers.Genero.CommandHandlers
{
    public class GeneroCommandsHandler : IRequestHandler<CreateGeneroCommand, Response>,
                                        IRequestHandler<UpdateGeneroCommand, Response>,
                                        IRequestHandler<DeleteGeneroCommand, Response>
    {
        private readonly IGeneroRepository _generoRepository;
        private readonly IMapper _mapper;

        public GeneroCommandsHandler(IGeneroRepository generoRepository, IMapper mapper)
        {
            _generoRepository = generoRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(CreateGeneroCommand command, CancellationToken cancellationToken)
        {
            //var genero = _mapper.Map<Domain.Entities.Genero>(command);

            var genero = new Domain.Entities.Genero
            {
                Descricao = command.Descricao
            };

            var result = await _generoRepository.CreateAsync(genero);

            var response = new Response
            {
                Success = true,
                Data = result,
                Message = "Registro incluido com sucesso"
            };

            return response;
        }

        public async Task<Response> Handle(UpdateGeneroCommand command, CancellationToken cancellationToken)
        {
            //var genero = _mapper.Map<Domain.Entities.Genero>(command);

            var genero = new Domain.Entities.Genero
            {
                Id = command.Id,
                Descricao = command.Descricao
            };

            await _generoRepository.UpdateAsync(genero);

            var response = new Response
            {
                Success = true,
                Data = null,
                Message = "Registro alterado com sucesso"
            };

            return response;
        }

        public async Task<Response> Handle(DeleteGeneroCommand command, CancellationToken cancellationToken)
        {
            await _generoRepository.DeleteAsync(command.Id);

            var response = new Response
            {
                Success = true,
                Data = null,
                Message = "Registro excluido com sucesso"
            };

            return response;
        }
    }
}