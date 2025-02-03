using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEscolar.Core.Interfaces;

public interface IServiceResult<T>
{
    T Data { get; set; }
    bool Success { get; set; }
    string Message { get; set; }
    IEnumerable<string> Errors { get; set; }
}
