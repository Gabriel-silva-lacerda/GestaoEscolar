using GestaoEscolar.api.Controllers.Base;
using GestaoEscolar.application.Responses;
using GestaoEscolar.domain.DTOs.Notas;
using GestaoEscolar.domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEscolar.api.Controllers.Notas;

[Route("api/notas")]
[ApiController]
public class NotasController : MainController
{
    private readonly INotasAppService _notasAppService;

    public NotasController(INotasAppService notasAppService)
    {
        _notasAppService = notasAppService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(SuccessResponse<IEnumerable<NotasDTO>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _notasAppService.GetAllAsync();
        return HandleServiceResult(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(SuccessResponse<NotasDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetKey(int id)
    {
        var result = await _notasAppService.GetKeyAsync(new NotasDTO { Id = id });
        return HandleServiceResult(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(SuccessResponse<NotasDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] InsertNotasDTO notasDTO)
    {
        var result = await _notasAppService.CreateAsync(notasDTO);
        return HandleServiceResult(result);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(SuccessResponse<NotasDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateNotasDTO notasDTO)
    {
        notasDTO.Id = id;
        var result = await _notasAppService.UpdateAsync(notasDTO);
        return HandleServiceResult(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(SuccessResponse<NotasDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _notasAppService.DeleteAsync(id);
        return HandleServiceResult(result);
    }
}
