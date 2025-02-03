using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using GestaoEscolar.domain.DTOs.Turma;
using GestaoEscolar.domain.Interfaces.Repositories;
using GestaoEscolar.domain.Models;

namespace GestaoEscolar.domain.Validators.Turmas;

public class InsertTurmaDTOValidator : AbstractValidator<InsertTurmaDTO>
{
    public InsertTurmaDTOValidator()
    {

        RuleFor(t => t.Nome)
            .NotEmpty().WithMessage("O nome da turma é obrigatório.");
        //.MustAsync(UniqueName).WithMessage("Já existe uma turma com este nome.");
    }
}