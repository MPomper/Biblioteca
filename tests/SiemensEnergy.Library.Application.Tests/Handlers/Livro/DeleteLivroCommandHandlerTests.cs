using AutoMapper;
using Moq;
using FluentAssertions;
using SiemensEnergy.Library.Application.Commands.Livro;
using SiemensEnergy.Library.Application.DTOs.Livro;
using SiemensEnergy.Library.Application.Handlers.Livro.CommandHandlers;
using SiemensEnergy.Library.Application.Interfaces;

namespace SiemensEnergy.Library.Application.Tests.Handlers.Livro
{
    public class DeleteLivroCommandHandlerTests
    {
        [Fact]
        public async Task ExecuteAsync_DeveRetornarSucesso_QuandoLivroDeletado()
        {
            var mockLivroRepository = new Mock<ILivroRepository>();
            var mockMapper = new Mock<IMapper>();

            var command = new DeleteLivroCommand(1);
            var livroExistente = new Domain.Entities.Livro { Id = 1, Titulo = "Harry Potter", IdAutor = 1, IdGenero = 1 };

            mockLivroRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(livroExistente);
            mockLivroRepository.Setup(r => r.DeleteAsync(1)).Returns(Task.CompletedTask);

            var handler = new LivroCommandsHandler(mockLivroRepository.Object, mockMapper.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            mockLivroRepository.Verify(r => r.DeleteAsync(It.IsAny<int>()), Times.Once);
        }
    }
}
