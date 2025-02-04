using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEscolar.Core.Common;

public class ErrorResponse : BaseResponse
{
    public IEnumerable<string> Errors { get; set; }

    public ErrorResponse(IEnumerable<string> errors) : base(false)
    {
        Errors = errors ?? new List<string> { "Ocorreu um erro inesperado." };
    }
}
