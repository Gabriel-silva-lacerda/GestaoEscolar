using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using GestaoEscolar.application.Common;
using GestaoEscolar.Core.Interfaces;

namespace GestaoEscolar.domain.Validators.Base;

public class ValidationHelper : IValidationHelper
{
    public async Task<ServiceResult<TDTO>> ValidateEntityAsync<T, TDTO>(T entity, IValidator<T> validator)
    {
        var validationResult = await validator.ValidateAsync(entity);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage);
            return ServiceResult<TDTO>.FailureResult(errors);
        }
        return null;
    }
}
