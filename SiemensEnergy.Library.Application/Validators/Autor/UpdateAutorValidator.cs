using FluentValidation;
using SiemensEnergy.Library.Application.DTOs.Autor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiemensEnergy.Library.Application.Validators.Autor
{
    public class UpdateAutorDtoValidator : AbstractValidator<UpdateAutorDto>
    {
        public UpdateAutorDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("ID inválido.");

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(255).WithMessage("O nome pode ter no máximo 255 caracteres.");
        }
    }
}
