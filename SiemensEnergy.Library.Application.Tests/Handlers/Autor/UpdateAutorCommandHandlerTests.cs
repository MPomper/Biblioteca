using AutoMapper;
using FluentAssertions;
using Moq;
using SiemensEnergy.Library.Application.Commands.Autor;
using SiemensEnergy.Library.Application.Handlers.Autor.CommandHandlers;
using SiemensEnergy.Library.Application.Interfaces;

namespace SiemensEnergy.Library.Application.Tests.Handlers.Autor
{
    public class UpdateAutorCommandHandlerTests
    {
        [Fact]
        public async Task ExecuteAsync_DeveRetornarSucesso_QuandoAutorAlterado()
        {
            var mockAutorRepository = new Mock<IAutorRepository>();
            var mockMapper = new Mock<IMapper>();

            var command = new UpdateAutorCommand(1, "Clarice Linspector");
            var autorExistente = new Domain.Entities.Autor { Id = 1, Nome = "Machado de Assis" };

            mockAutorRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(autorExistente);
            mockAutorRepository.Setup(r => r.UpdateAsync(It.IsAny<Domain.Entities.Autor>())).Returns(Task.CompletedTask);

            var handler = new AutorCommandsHandler(mockAutorRepository.Object, mockMapper.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            mockAutorRepository.Verify(r => r.UpdateAsync(It.Is<Domain.Entities.Autor>(a => a.Nome == "Clarice Linspector")), Times.Once);
        }
    }
}