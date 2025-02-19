using GestaoEscolar.api.Controllers.Base;
using GestaoEscolar.application.Responses;
using GestaoEscolar.domain.DTOs.Professor;
using GestaoEscolar.domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEscolar.api.Controllers.Professor;

[Route("api/professor")]
[ApiController]
public class ProfessorController : MainController
{
    private readonly IProfessorAppService _professorAppService;

    public ProfessorController(IProfessorAppService professorAppService)
    {
        _professorAppService = professorAppService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(SuccessResponse<IEnumerable<ProfessorDTO>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _professorAppService.GetAllAsync();
        return HandleServiceResult(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(SuccessResponse<ProfessorDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetKey(int id)
    {
        var result = await _professorAppService.GetKeyAsync(new ProfessorDTO { Id = id });
        return HandleServiceResult(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(SuccessResponse<ProfessorDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] InsertProfessorDTO insertProfessorDTO)
    {
        var result = await _professorAppService.CreateAsync(insertProfessorDTO);
        return HandleServiceResult(result);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(SuccessResponse<ProfessorDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProfessorDTO updateProfessorDTO)
    {
        updateProfessorDTO.Id = id;
        var result = await _professorAppService.UpdateAsync(updateProfessorDTO);
        return HandleServiceResult(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(SuccessResponse<ProfessorDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _professorAppService.DeleteAsync(id);
        return HandleServiceResult(result);
    }
}

