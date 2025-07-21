using AutoMapper;
using Moq;
using FluentAssertions;
using SiemensEnergy.Library.Application.Commands.Livro;
using SiemensEnergy.Library.Application.DTOs.Livro;
using SiemensEnergy.Library.Application.Handlers.Livro.CommandHandlers;
using SiemensEnergy.Library.Application.Interfaces;

namespace SiemensEnergy.Library.Application.Tests.Handlers.Livro
{
    public class CreateLivroCommandHandlerTests
    {
        [Fact]
        public async Task ExecuteAsync_DeveRetornarSucesso_QuandoLivroCriado()
        {
            var mockLivroRepository = new Mock<ILivroRepository>();
            var mockMapper = new Mock<IMapper>();

            var command = new CreateLivroCommand("Harry Potter", 1, 1);
            var Livro = new Domain.Entities.Livro { Titulo = "Harry Potter", IdAutor = 1, IdGenero = 1 };
            var LivroDto = new CreateLivroDto { Titulo = "Harry Potter", IdAutor = 1, IdGenero = 1 };

            mockLivroRepository.Setup(r => r.CreateAsync(It.IsAny<Domain.Entities.Livro>())).ReturnsAsync(1);
            mockMapper.Setup(m => m.Map<CreateLivroDto>(It.IsAny<Domain.Entities.Livro>())).Returns(LivroDto);

            var handler = new LivroCommandsHandler(mockLivroRepository.Object, mockMapper.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            mockLivroRepository.Verify(r => r.CreateAsync(It.Is<Domain.Entities.Livro>(a => a.Titulo == "Harry Potter")), Times.Once);
        }
    }
}
