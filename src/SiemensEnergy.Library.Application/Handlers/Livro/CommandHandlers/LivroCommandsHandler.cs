using MediatR;
using SiemensEnergy.Library.Application.Commands.Livro;
using SiemensEnergy.Library.Application.Interfaces;
using SiemensEnergy.Library.Application.Common;
using AutoMapper;

namespace SiemensEnergy.Library.Application.Handlers.Livro.CommandHandlers
{
    public class LivroCommandsHandler : IRequestHandler<CreateLivroCommand, Response>,
                                        IRequestHandler<UpdateLivroCommand, Response>,
                                        IRequestHandler<DeleteLivroCommand, Response>
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IMapper _mapper;

        public LivroCommandsHandler(ILivroRepository livroRepository, IMapper mapper)
        {
            _livroRepository = livroRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(CreateLivroCommand command, CancellationToken cancellationToken)
        {
            try
            {
                //var livro = _mapper.Map<Domain.Entities.Livro>(command);

                var livro = new Domain.Entities.Livro
                {
                    Titulo = command.Titulo,
                    IdAutor = command.IdAutor,
                    IdGenero = command.IdGenero
                };

                var result = await _livroRepository.CreateAsync(livro);

                var response = new Response
                {
                    Success = true,
                    Data = result,
                    Message = "Registro incluido com sucesso"
                };

                return response;
            }
            catch (Exception ex)
            {
                // Faça log com o erro detalhado
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }

        public async Task<Response> Handle(UpdateLivroCommand command, CancellationToken cancellationToken)
        {
            //var livro = _mapper.Map<Domain.Entities.Livro>(command);

            var livro = new Domain.Entities.Livro
            {
                Id = command.Id,
                Titulo = command.Titulo,
                IdAutor = command.IdAutor,
                IdGenero = command.IdGenero
            };

            await _livroRepository.UpdateAsync(livro);

            var response = new Response
            {
                Success = true,
                Data = null,
                Message = "Registro alterado com sucesso"
            };

            return response;
        }

        public async Task<Response> Handle(DeleteLivroCommand command, CancellationToken cancellationToken)
        {
            await _livroRepository.DeleteAsync(command.Id);

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