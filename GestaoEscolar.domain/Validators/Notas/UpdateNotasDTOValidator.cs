using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using GestaoEscolar.domain.DTOs.Materia;
using GestaoEscolar.domain.DTOs.Notas;

namespace GestaoEscolar.domain.Validators.Notas;

public class UpdateNotasDTOValidator : AbstractValidator<UpdateNotasDTO>
{
    public UpdateNotasDTOValidator()
    {
        //RuleFor(t => t.)
        //  .NotEmpty().WithMessage("O MateriaId é obrigatório.")
        //  .GreaterThan(0).WithMessage("O MateriaId deve ser maior que 0.");

        RuleFor(x => x.Nota)
            .InclusiveBetween(0, 10).WithMessage("A nota deve estar entre 0 e 10.");
    }
}
