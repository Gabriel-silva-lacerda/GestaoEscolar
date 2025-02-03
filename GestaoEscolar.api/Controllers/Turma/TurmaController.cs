using GestaoEscolar.domain.DTOs.Conteudo;
using GestaoEscolar.domain.DTOs.Turma;
using GestaoEscolar.domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEscolar.api.Controllers.Turma;

[Route("api/turma")]
[ApiController]
public class TurmaController : ControllerBase
{
    private readonly ITurmaAppService _turmaAppService;

    public TurmaController(ITurmaAppService turmaAppService)
    {
        _turmaAppService = turmaAppService;
    }

    [HttpGet]
    public async Task<IEnumerable<TurmaDTO>> GetAllAsync()
    {
        return await _turmaAppService.GetAllAsync();
    }

    [HttpGet("{id}", Name = "ObterTurma")]
    public async Task<IActionResult> GetKeyAsync(int id)
    {
        // Cria um DTO para buscar pela chave
        var turmaDTO = new TurmaDTO { Id = id };
        var result = await _turmaAppService.GetKeyAsync(turmaDTO);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(InsertTurmaDTO insertTurmaDTO)
    {
        var turma = await _turmaAppService.CreateAsync(insertTurmaDTO);
        return new CreatedAtRouteResult("ObterTurma", new { id = turma.Data.Id }, turma); 
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateTurmaDTO updateTurmaDTO)
    {
        updateTurmaDTO.Id = id;
        var result = await _turmaAppService.Update(updateTurmaDTO);

        if (result == null)
        {
            return NotFound(); 
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {

        var result = await _turmaAppService.DeleteAsync(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}
