using GestaoEscolar.api.Controllers.Base;
using GestaoEscolar.application.Responses;
using GestaoEscolar.domain.DTOs.Materia;
using GestaoEscolar.domain.Interfaces.Services;
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
    [ProducesResponseType(typeof(SuccessResponse<IEnumerable<MateriaDTO>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _materiaAppService.GetAllAsync();
        return HandleServiceResult(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(SuccessResponse<MateriaDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetKey(int id)
    {
        var result = await _materiaAppService.GetKeyAsync(new MateriaDTO { Id = id });
        return HandleServiceResult(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(SuccessResponse<MateriaDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(InsertMateriaDTO insertMateriaDTO)
    {
        var result = await _materiaAppService.CreateAsync(insertMateriaDTO);
        return HandleServiceResult(result);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(SuccessResponse<MateriaDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateMateriaDTO updateMateriaDTO)
    {
        updateMateriaDTO.Id = id;
        var result = await _materiaAppService.UpdateAsync(updateMateriaDTO);
        return HandleServiceResult(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(SuccessResponse<MateriaDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _materiaAppService.DeleteAsync(id);
        return HandleServiceResult(result);
    }
}

