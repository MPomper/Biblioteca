using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SiemensEnergy.Library.Application.Common;
using SiemensEnergy.Library.Domain.Entities;
using static SiemensEnergy.Library.Application.Queries.Genero.GeneroQueries;
using SiemensEnergy.Library.Application.Commands.Genero;
using AutoMapper;
using SiemensEnergy.Library.Application.DTOs.Genero;

namespace SiemensEnergy.Library.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GenerosController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Response), 201)]
        [ProducesResponseType(typeof(Response), 204)]
        [ProducesResponseType(typeof(Response), 400)]
        public async Task<IActionResult> Create(CreateGeneroDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var command = _mapper.Map<CreateGeneroCommand>(dto);
                var result = await _mediator.Send(command);
                return result.Success ? Ok(5) : BadRequest(result);
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
        public async Task<IActionResult> Update(UpdateGeneroDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = _mapper.Map<UpdateGeneroCommand>(dto);
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Response), 201)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteGeneroCommand(id));
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Response), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            var genero = await _mediator.Send(new GetGeneroByIdQuery(id));

            return genero is not null ? Ok(genero) : NotFound();
        }

        [HttpGet]
        [ProducesResponseType(typeof(Response), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var generos = await _mediator.Send(new GetAllGenerosQuery());
            return generos is not null ? Ok(generos) : NotFound();
        }
    }
}
