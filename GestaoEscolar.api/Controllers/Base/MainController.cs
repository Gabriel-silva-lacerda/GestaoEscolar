using GestaoEscolar.application.Responses;
using GestaoEscolar.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEscolar.api.Controllers.Base;

[ApiController]
public abstract class MainController : ControllerBase
{
    //protected IActionResult CustomResponse(object result = null, string message = null, bool success = true)
    //{
    //    if (success)
    //    {
    //        var response = new
    //        {
    //            Success = true,
    //            Data = result
    //        };

    //        if (!string.IsNullOrEmpty(message))
    //        {
    //            return Ok(new
    //            {
    //                Success = response.Success,
    //                Message = message,
    //                Data = response.Data,
    //            });
    //        }

    //        return Ok(response);
    //    }

    //    return BadRequest(new ErrorResponse(result as IEnumerable<string>));

    //}
    protected IActionResult HandleServiceResult<T>(ServiceResult<T> serviceResult)
    {
        if (serviceResult.Success)
        {
            return Ok(new SuccessResponse<T>(serviceResult.Data, serviceResult.Message));
        }

        return BadRequest(new ErrorResponse(serviceResult.Errors));
    }

    protected IActionResult CustomResponse<T>(T result = default, string message = null, bool success = true)
    {
        if (success)
        {
            return Ok(new SuccessResponse<T>(result, message));
        }

        return BadRequest(new ErrorResponse(result as IEnumerable<string>));
    }
}