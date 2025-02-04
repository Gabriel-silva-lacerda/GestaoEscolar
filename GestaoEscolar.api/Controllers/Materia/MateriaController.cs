using GestaoEscolar.api.Controllers.Base;
using GestaoEscolar.domain.DTOs.Aluno;
using GestaoEscolar.domain.DTOs.Conteudo;
using GestaoEscolar.domain.DTOs.Materia;
using GestaoEscolar.domain.DTOs.Notas;
using GestaoEscolar.domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEscolar.api.Controllers.Materia;

[Route("api/materia")]
[ApiController]
public class MateriaController : MainController
{
    private readonly IMateriaAppService _materiaAppService;

    public MateriaController(IMateriaAppService materiaAppService)
    {
        _materiaAppService = materiaAppService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await _materiaAppService.GetAllAsync();
            return HandleServiceResult(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetKey(int id)
    {
        var result = await _materiaAppService.GetKeyAsync(new MateriaDTO { Id = id});
        return HandleServiceResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(InsertMateriaDTO insertMateriaDTO)
    {
        var result = await _materiaAppService.CreateAsync(insertMateriaDTO);
        return HandleServiceResult(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody]UpdateMateriaDTO updateMateriaDTO)
    {
        updateMateriaDTO.Id = id;
        var result = await _materiaAppService.UpdateAsync(updateMateriaDTO);
        return HandleServiceResult(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _materiaAppService.DeleteAsync(id);
        return HandleServiceResult(result);
    }
}
