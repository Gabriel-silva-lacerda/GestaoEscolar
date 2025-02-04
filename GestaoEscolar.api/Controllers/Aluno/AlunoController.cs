using GestaoEscolar.api.Controllers.Base;
using GestaoEscolar.application.Responses;
using GestaoEscolar.domain.DTOs.Aluno;
using GestaoEscolar.domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEscolar.api.Controllers.Aluno;

[Route("api/aluno")]
[ApiController]
public class AlunoController : MainController
{
    private readonly IAlunoAppService _alunoAppService;

    public AlunoController(IAlunoAppService alunoAppService)
    {
        _alunoAppService = alunoAppService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(SuccessResponse<IEnumerable<AlunoDTO>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> GetAll()
    {
        var result = await _alunoAppService.GetAllAsync();
        return HandleServiceResult(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(SuccessResponse<AlunoDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> GetKey(int id)
    {
        var result = await _alunoAppService.GetKeyAsync(new AlunoDTO { Id = id });
        return HandleServiceResult(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(SuccessResponse<AlunoDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] InsertAlunoDTO alunoDTO)
    {
        var result = await _alunoAppService.CreateAsync(alunoDTO);
        return HandleServiceResult(result); 
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(SuccessResponse<AlunoDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAlunoDTO alunoDTO)
    {
        alunoDTO.Id = id;
        var result = await _alunoAppService.UpdateAsync(alunoDTO);

        return HandleServiceResult(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(SuccessResponse<AlunoDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _alunoAppService.DeleteAsync(id);
        return HandleServiceResult(result);
    }
}
