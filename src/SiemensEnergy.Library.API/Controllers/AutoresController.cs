using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SiemensEnergy.Library.Application.Commands.Autor;
using SiemensEnergy.Library.Application.Commands.Livro;
using SiemensEnergy.Library.Application.Common;
using SiemensEnergy.Library.Application.DTOs.Autor;
using SiemensEnergy.Library.Domain.Entities;
using static SiemensEnergy.Library.Application.Queries.Autor.AutorQueries;

namespace SiemensEnergy.Library.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AutoresController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Response), 201)]
        [ProducesResponseType(typeof(Response), 204)]
        [ProducesResponseType(typeof(Response), 400)]
        public async Task<IActionResult> Create(CreateAutorDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var command = _mapper.Map<CreateAutorCommand>(dto);
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
        public async Task<IActionResult> Update(UpdateAutorDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = _mapper.Map<UpdateAutorCommand>(dto);
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Response), 201)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteAutorCommand(id));
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Response), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            var autor = await _mediator.Send(new GetAutorByIdQuery(id));

            return autor is not null ? Ok(autor) : NotFound();
        }

        [HttpGet]
        [ProducesResponseType(typeof(Response), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var autores = await _mediator.Send(new GetAllAutoresQuery());
            return autores is not null ? Ok(autores) : NotFound();
        }
    }
}
