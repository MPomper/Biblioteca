using FluentValidation;
using SiemensEnergy.Library.Application.DTOs.Genero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiemensEnergy.Library.Application.Validators.Genero
{
    public class CreateGeneroDtoValidator : AbstractValidator<CreateGeneroDto>
    {
        public CreateGeneroDtoValidator()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("A descrição é obrigatória.")
                .MaximumLength(50).WithMessage("A descrição pode ter no máximo 50 caracteres.");
        }
    }
}
