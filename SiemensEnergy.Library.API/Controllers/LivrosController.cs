using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SiemensEnergy.Library.Application.Common;
using SiemensEnergy.Library.Domain.Entities;
using static SiemensEnergy.Library.Application.Queries.Livro.LivroQueries;
using SiemensEnergy.Library.Application.Commands.Livro;
using AutoMapper;
using SiemensEnergy.Library.Application.DTOs.Livro;
using SiemensEnergy.Library.Application.ViewModels.Livro;

namespace SiemensEnergy.Library.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public LivrosController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Response), 201)]
        [ProducesResponseType(typeof(Response), 204)]
        [ProducesResponseType(typeof(Response), 400)]
        public async Task<IActionResult> Create(CreateLivroDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var command = _mapper.Map<CreateLivroCommand>(dto);
                var result = await _mediator.Send(command);
                return result.Success ? Ok(result) : BadRequest(result);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Response), 201)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Update(UpdateLivroDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = _mapper.Map<UpdateLivroCommand>(dto);
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Response), 201)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteLivroCommand(id));
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Response), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            var livro = await _mediator.Send(new GetLivroByIdQuery(id));
            return livro is not null ? Ok(livro) : NotFound();
        }

        [HttpGet("buscar")]
        [ProducesResponseType(typeof(Response), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([FromQuery] FiltroLivroDto dto)
        {
            var livros = await _mediator.Send(new GetLivroByFiltroQuery(dto));
            return livros is not null ? Ok(livros) : NotFound();
        }

        [HttpGet]
        [ProducesResponseType(typeof(Response), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var livros = await _mediator.Send(new GetAllLivrosQuery());
            return livros is not null ? Ok(livros) : NotFound();
        }
    }
}