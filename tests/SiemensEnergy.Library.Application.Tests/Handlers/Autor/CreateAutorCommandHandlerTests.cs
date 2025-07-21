using AutoMapper;
using FluentAssertions;
using Moq;
using SiemensEnergy.Library.Application.Commands.Autor;
using SiemensEnergy.Library.Application.DTOs.Autor;
using SiemensEnergy.Library.Application.Handlers.Autor.CommandHandlers;
using SiemensEnergy.Library.Application.Interfaces;

namespace SiemensEnergy.Library.Application.Tests.Handlers.Autor
{
    public class CreateAutorCommandHandlerTests
    {
        [Fact]
        public async Task ExecuteAsync_DeveRetornarSucesso_QuandoAutorCriado()
        {
            var mockAutorRepository = new Mock<IAutorRepository>();
            var mockMapper = new Mock<IMapper>();

            var command = new CreateAutorCommand("Machado de Assis");
            var autor = new Domain.Entities.Autor { Id = 1, Nome = "Machado de Assis" };
            var autorDto = new CreateAutorDto { Nome = "Machado de Assis" };

            mockAutorRepository.Setup(r => r.CreateAsync(It.IsAny<Domain.Entities.Autor>())).ReturnsAsync(1);
            mockMapper.Setup(m => m.Map<CreateAutorDto>(It.IsAny<Domain.Entities.Autor>())).Returns(autorDto);

            var handler = new AutorCommandsHandler(mockAutorRepository.Object, mockMapper.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            mockAutorRepository.Verify(r => r.CreateAsync(It.Is<Domain.Entities.Autor>(a => a.Nome == "Machado de Assis")), Times.Once);
        }
    }
}