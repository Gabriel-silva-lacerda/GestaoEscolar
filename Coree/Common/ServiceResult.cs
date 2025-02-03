using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoEscolar.Core.Interfaces;

namespace GestaoEscolar.application.Common;

public class ServiceResult<T> : IServiceResult<T>
{
    public T Data { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
    public IEnumerable<string> Errors { get; set; }

    public static ServiceResult<T> SuccessResult(T data, string message = null) =>
        new ServiceResult<T> { Data = data, Success = true, Message = message };

    public static ServiceResult<T> FailureResult(IEnumerable<string> errors) =>
        new ServiceResult<T> { Success = false, Errors = errors };
}
