using AutoMapper;
using FluentAssertions;
using Moq;
using SiemensEnergy.Library.Application.Commands.Genero;
using SiemensEnergy.Library.Application.DTOs.Genero;
using SiemensEnergy.Library.Application.Handlers.Genero.CommandHandlers;
using SiemensEnergy.Library.Application.Interfaces;

namespace SiemensEnergy.Library.Application.Tests.Handlers.Genero
{
    public class CreateGeneroCommandHandlerTests
    {
        [Fact]
        public async Task ExecuteAsync_DeveRetornarSucesso_QuandoGeneroCriado()
        {
            var mockGeneroRepository = new Mock<IGeneroRepository>();
            var mockMapper = new Mock<IMapper>();

            var command = new CreateGeneroCommand("Poesia");
            var genero = new Domain.Entities.Genero { Id = 1, Descricao = "Poesia" };
            var GeneroDto = new CreateGeneroDto { Descricao = "Poesia" };

            mockGeneroRepository.Setup(r => r.CreateAsync(It.IsAny<Domain.Entities.Genero>())).ReturnsAsync(1);
            mockMapper.Setup(m => m.Map<CreateGeneroDto>(It.IsAny<Domain.Entities.Genero>())).Returns(GeneroDto);

            var handler = new GeneroCommandsHandler(mockGeneroRepository.Object, mockMapper.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            mockGeneroRepository.Verify(r => r.CreateAsync(It.Is<Domain.Entities.Genero>(a => a.Descricao == "Poesia")), Times.Once);
        }
    }
}
