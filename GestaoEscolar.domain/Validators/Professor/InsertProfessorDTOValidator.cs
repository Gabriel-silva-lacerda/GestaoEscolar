using FluentValidation;
using GestaoEscolar.domain.DTOs.Professor;

namespace GestaoEscolar.domain.Validators.Professor;
public class InsertProfessorDTOValidator : AbstractValidator<InsertProfessorDTO>
{
    public InsertProfessorDTOValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome do professor é obrigatório.")
            .MaximumLength(100).WithMessage("O nome do professor deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Sobrenome)
            .NotEmpty().WithMessage("O sobrenome do professor é obrigatório.");

        //RuleFor(x => x.Cpf)
        //    .NotEmpty().WithMessage("O CPF do professor é obrigatório.")
        //    .Length(11).WithMessage("O CPF deve conter exatamente 11 caracteres.");

        //RuleFor(x => x.Email)
        //    .NotEmpty().WithMessage("O e-mail do professor é obrigatório.")
        //    .EmailAddress().WithMessage("O e-mail fornecido é inválido.");

        //RuleFor(x => x.MateriaId)
        //    .NotEmpty().WithMessage("O MateriaId é obrigatório.")
        //    .GreaterThan(0).WithMessage("O MateriaId deve ser maior que 0.");
    }
}
