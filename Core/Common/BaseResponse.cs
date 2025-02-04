using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEscolar.Core.Common;

public abstract class BaseResponse
{
    public bool Success { get; protected set; }

    protected BaseResponse(bool success)
    {
        Success = success;
    }
}
