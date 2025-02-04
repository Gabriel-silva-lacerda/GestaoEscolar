using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEscolar.Core.Common;

public class SuccessResponse<T> : BaseResponse
{
    public T Data { get; set; }
    public string Message { get; set; }

    public SuccessResponse(T data, string message = null) : base(true)
    {
        Data = data;
        Message = message;
    }
}
