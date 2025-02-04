using GestaoEscolar.api.Controllers.Base;
using GestaoEscolar.Core.Common;
using GestaoEscolar.domain.DTOs.Aluno;
using GestaoEscolar.domain.DTOs.Conteudo;
using GestaoEscolar.domain.DTOs.Turma;
using GestaoEscolar.domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEscolar.api.Controllers.Turma;

[Route("api/turma")]
[ApiController]
public class TurmaController : MainController
{
    private readonly ITurmaAppService _turmaAppService;

    public TurmaController(ITurmaAppService turmaAppService)
    {
        _turmaAppService = turmaAppService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(SuccessResponse<IEnumerable<TurmaDTO>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _turmaAppService.GetAllAsync();
        return HandleServiceResult(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(SuccessResponse<TurmaDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetKeyAsync(int id)
    {
        var result = await _turmaAppService.GetKeyAsync(new TurmaDTO { Id = id });
        return HandleServiceResult(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(SuccessResponse<TurmaDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(InsertTurmaDTO insertTurmaDTO)
    {
        var result = await _turmaAppService.CreateAsync(insertTurmaDTO);
        return HandleServiceResult(result);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(SuccessResponse<TurmaDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(int id, UpdateTurmaDTO updateTurmaDTO)
    {
        updateTurmaDTO.Id = id;
        var result = await _turmaAppService.UpdateAsync(updateTurmaDTO);
        return HandleServiceResult(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(SuccessResponse<TurmaDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _turmaAppService.DeleteAsync(id);
        return HandleServiceResult(result);
    }
}
