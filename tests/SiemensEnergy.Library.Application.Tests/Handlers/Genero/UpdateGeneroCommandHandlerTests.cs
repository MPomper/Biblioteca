using AutoMapper;
using FluentAssertions;
using Moq;
using SiemensEnergy.Library.Application.Commands.Genero;
using SiemensEnergy.Library.Application.DTOs.Genero;
using SiemensEnergy.Library.Application.Handlers.Genero.CommandHandlers;
using SiemensEnergy.Library.Application.Interfaces;

namespace SiemensEnergy.Library.Application.Tests.Handlers.Genero
{
    public class UpdateGeneroCommandHandlerTests
    {
        [Fact]
        public async Task ExecuteAsync_DeveRetornarSucesso_QuandoGeneroAlterado()
        {
            var mockGeneroRepository = new Mock<IGeneroRepository>();
            var mockMapper = new Mock<IMapper>();

            var command = new UpdateGeneroCommand(1, "Narrativo");
            var generoExistente = new Domain.Entities.Genero { Id = 1, Descricao = "Poesia" };

            mockGeneroRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(generoExistente);
            mockGeneroRepository.Setup(r => r.UpdateAsync(It.IsAny<Domain.Entities.Genero>())).Returns(Task.CompletedTask);

            var handler = new GeneroCommandsHandler(mockGeneroRepository.Object, mockMapper.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            mockGeneroRepository.Verify(r => r.UpdateAsync(It.Is<Domain.Entities.Genero>(a => a.Descricao == "Narrativo")), Times.Once);
        }
    }
}
