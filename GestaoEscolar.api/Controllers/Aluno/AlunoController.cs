using GestaoEscolar.api.Controllers.Base;
using GestaoEscolar.application.Common;
using GestaoEscolar.domain.DTOs.Aluno;
using GestaoEscolar.domain.Interfaces.Services;
using GestaoEscolar.domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
    [ProducesResponseType(typeof(ServiceResult<IEnumerable<AlunoDTO>>), 200)]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _alunoAppService.GetAllAsync();
        return HandleServiceResult(result);
    }

    [HttpGet("{id}", Name = "ObterAluno")]
    public async Task<IActionResult> GetKeyAsync(int id)
    {
        var result = await _alunoAppService.GetKeyAsync(new AlunoDTO { Id = id });
        return HandleServiceResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] InsertAlunoDTO alunoDTO)
    {
        var aluno = await _alunoAppService.CreateAsync(alunoDTO);
        return HandleServiceResult(aluno); 
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAlunoDTO alunoDTO)
    {
        alunoDTO.Id = id;
        var updatedAluno = await _alunoAppService.UpdateAsync(alunoDTO);

        return HandleServiceResult(updatedAluno);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _alunoAppService.DeleteAsync(id);
        return HandleServiceResult(result);
    }
}
