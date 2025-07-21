using MediatR;
using SiemensEnergy.Library.Application.Commands.Autor;
using SiemensEnergy.Library.Application.Interfaces;
using SiemensEnergy.Library.Application.Common;
using AutoMapper;

namespace SiemensEnergy.Library.Application.Handlers.Autor.CommandHandlers
{
    public class AutorCommandsHandler : IRequestHandler<CreateAutorCommand, Response>,
                                        IRequestHandler<UpdateAutorCommand, Response>,
                                        IRequestHandler<DeleteAutorCommand, Response>
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IMapper _mapper;

        public AutorCommandsHandler(IAutorRepository autorRepository, IMapper mapper)
        {
            _autorRepository = autorRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(CreateAutorCommand command, CancellationToken cancellationToken)
        {
            try
            {
                //var autor = _mapper.Map<Domain.Entities.Autor>(command);

                var autor = new Domain.Entities.Autor
                {
                    Nome = command.Nome
                };

                var result = await _autorRepository.CreateAsync(autor);

                var response = new Response
                {
                    Success = true,
                    Data = result,
                    Message = "Registro incluido com sucesso"
                };

                return response;
            }
            catch (Exception)
            {
                var response = new Response
                {
                    Success = false,
                    Data = null,
                    Message = "Registro não foi incluido"
                };

                return response;
            }
        }

        public async Task<Response> Handle(UpdateAutorCommand command, CancellationToken cancellationToken)
        {
            try
            {
                //var autor = _mapper.Map<Domain.Entities.Autor>(command);

                var autor = new Domain.Entities.Autor
                {
                    Id = command.Id,
                    Nome = command.Nome
                };

                await _autorRepository.UpdateAsync(autor);

                var response = new Response
                {
                    Success = true,
                    Data = null,
                    Message = "Registro alterado com sucesso"
                };

                return response;
            }
            catch (Exception)
            {
                var response = new Response
                {
                    Success = false,
                    Data = null,
                    Message = "Registro não foi alterado"
                };

                return response;
            }
        }

        public async Task<Response> Handle(DeleteAutorCommand command, CancellationToken cancellationToken)
        {
            try
            {
                await _autorRepository.DeleteAsync(command.Id);

                var response = new Response
                {
                    Success = true,
                    Data = null,
                    Message = "Registro excluido com sucesso"
                };

                return response;
            }
            catch (Exception)
            {
                var response = new Response
                {
                    Success = false,
                    Data = null,
                    Message = "Registro não foi excluido"
                };

                return response;
            }
        }
    }
}