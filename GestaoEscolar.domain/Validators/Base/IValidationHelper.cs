using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using GestaoEscolar.application.Common;

namespace GestaoEscolar.Core.Interfaces;

public interface IValidationHelper
{
    Task<ServiceResult<TDTO>> ValidateEntityAsync<T, TDTO>(T entity, IValidator<T> validator);
}
