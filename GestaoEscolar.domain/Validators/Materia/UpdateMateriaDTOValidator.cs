using FluentValidation;
using GestaoEscolar.domain.DTOs.Materia;
using GestaoEscolar.domain.DTOs.Turma;

namespace GestaoEscolar.domain.Validators.Materia;

public class UpdateMateriaDTOValidator : AbstractValidator<UpdateMateriaDTO>
{
    public UpdateMateriaDTOValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome da matéria é obrigatório.")
            .MaximumLength(100).WithMessage("O nome do matéria deve ter no máximo 100 caracteres.");
    }
}
