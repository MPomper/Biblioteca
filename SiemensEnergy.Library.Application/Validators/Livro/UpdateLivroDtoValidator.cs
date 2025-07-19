using FluentValidation;
using SiemensEnergy.Library.Application.DTOs.Livro;

namespace SiemensEnergy.Library.Application.Validators.Livro
{
    public class UpdateLivroDtoValidator : AbstractValidator<UpdateLivroDto>
    {
        public UpdateLivroDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("ID inválido.");

            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("O título é obrigatório.")
                .MaximumLength(200).WithMessage("O título pode ter no máximo 200 caracteres.");

            RuleFor(x => x.IdAutor)
                .GreaterThan(0).WithMessage("Autor inválido.");

            RuleFor(x => x.IdGenero)
                .GreaterThan(0).WithMessage("Gênero inválido.");
        }
    }
}