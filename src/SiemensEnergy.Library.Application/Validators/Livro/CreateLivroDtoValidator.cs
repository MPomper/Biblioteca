using FluentValidation;
using SiemensEnergy.Library.Application.DTOs.Livro;

namespace SiemensEnergy.Library.Application.Validators.Livro
{
    public class CreateLivroDtoValidator : AbstractValidator<CreateLivroDto>
    {
        public CreateLivroDtoValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("O título é obrigatório.")
                .MaximumLength(200).WithMessage("O título pode ter no máximo 150 caracteres.");

            RuleFor(x => x.IdAutor)
                .GreaterThan(0).WithMessage("Autor inválido.");

            RuleFor(x => x.IdGenero)
                .GreaterThan(0).WithMessage("Gênero inválido.");
        }
    }
}