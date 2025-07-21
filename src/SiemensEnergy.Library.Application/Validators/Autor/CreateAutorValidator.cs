using FluentValidation;
using SiemensEnergy.Library.Application.DTOs.Autor;

namespace SiemensEnergy.Library.Application.Validators.Autor
{
    public class CreateAutorDtoValidator : AbstractValidator<CreateAutorDto>
    {
        public CreateAutorDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(255).WithMessage("O nome pode ter no máximo 255 caracteres.");
        }
    }
}
