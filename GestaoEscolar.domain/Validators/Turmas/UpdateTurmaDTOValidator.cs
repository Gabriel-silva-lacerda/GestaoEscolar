using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using GestaoEscolar.domain.DTOs.Turma;

namespace GestaoEscolar.domain.Validators.Turmas;

public class UpdateTurmaDTOValidator : AbstractValidator<UpdateTurmaDTO>
{
    public UpdateTurmaDTOValidator()
    {

        RuleFor(t => t.Nome)
            .NotEmpty().WithMessage("O nome da turma é obrigatório.");
        //.MustAsync(UniqueName).WithMessage("Já existe uma turma com este nome.");
    }
}
