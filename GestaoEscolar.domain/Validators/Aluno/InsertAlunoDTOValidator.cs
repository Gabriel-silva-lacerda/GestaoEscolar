using FluentValidation;
using GestaoEscolar.domain.DTOs.Aluno;

namespace GestaoEscolar.domain.Validators.Aluno;

public class InsertAlunoDTOValidator : AbstractValidator<InsertAlunoDTO>
{
    public InsertAlunoDTOValidator()
    {

        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome do aluno é obrigatório.")
            .MaximumLength(100).WithMessage("O nome do aluno deve ter no máximo 100 caracteres.");
        RuleFor(t => t.Sobrenome)
            .NotEmpty().WithMessage("O sobrenome do aluno é obrigatório.");
        RuleFor(t => t.TurmaId)
            .NotEmpty().WithMessage("O TurmaId é obrigatório.")
            .GreaterThan(0).WithMessage("O TurmaId deve ser maior que 0.");
    }
}
