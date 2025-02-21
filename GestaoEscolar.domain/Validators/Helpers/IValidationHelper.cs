using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using GestaoEscolar.Core.Services;

namespace GestaoEscolar.Core.Interfaces;

public interface IValidationHelper
{
    Task<ServiceResult<TDTO>> ValidateEntityAsync<T, TDTO>(T entity, IValidator<T> validator);
}
