using FluentValidation;
using SiemensEnergy.Library.Application.DTOs.Genero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiemensEnergy.Library.Application.Validators.Genero
{
    public class UpdateGeneroDtoValidator : AbstractValidator<UpdateGeneroDto>
    {
        public UpdateGeneroDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("ID inválido.");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("A descrição é obrigatória.")
                .MaximumLength(50).WithMessage("A descrição pode ter no máximo 50 caracteres.");
        }
    }
}
