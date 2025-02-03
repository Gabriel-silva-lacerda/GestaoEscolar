using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using GestaoEscolar.domain.DTOs.Aluno;

namespace GestaoEscolar.domain.Validators.Aluno;

public class UpdateAlunoDTOValidator : AbstractValidator<UpdateAlunoDTO>
{
    public UpdateAlunoDTOValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome do aluno é obrigatório.")
            .MaximumLength(100).WithMessage("O nome do aluno deve ter no máximo 100 caracteres.");
        RuleFor(t => t.Sobrenome)
            .NotEmpty().WithMessage("O sobrenome do aluno é obrigatório.");
    }
}
