using Azure;
using GestaoEscolar.application.Common;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEscolar.api.Controllers.Base;

[ApiController]
public abstract class MainController : ControllerBase
{
    protected IActionResult CustomResponse(object result = null, string message = null, bool success = true)
    {
        if (success)
        {
            var response = new
            {
                Success = true,
                Data = result
            };

            if (!string.IsNullOrEmpty(message))
            {
                return Ok(new
                {
                    Success = response.Success,
                    Message = message,
                    Data = response.Data,
                });
            }

            return Ok(response);
        }

        return BadRequest(new
        {
            Success = false,
            Errors = result
        });

    }

    protected IActionResult HandleServiceResult<T>(ServiceResult<T> serviceResult)
    {
        if (serviceResult.Success)
        {
            return CustomResponse(serviceResult.Data, serviceResult.Message, true);
        }

        return CustomResponse(serviceResult.Errors, null, false);
    }
}