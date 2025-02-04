using GestaoEscolar.api.Controllers.Base;
using GestaoEscolar.domain.DTOs.Conteudo;
using GestaoEscolar.domain.DTOs.Notas;
using GestaoEscolar.domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
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
    //[HttpGet]
    //public async Task<IEnumerable<NotasDTO>> GetAllAsync()
    //{

    //}

    //[HttpGet]
    //public async Task<NotasDTO> GetKeyAsync(NotasDTO notasDTO)
    //{

    //}

    [HttpPost]
    public async Task<IActionResult> Create(InsertNotasDTO insertNotasDTO)
    {
        var result = await _notasAppService.CreateAsync(insertNotasDTO);
        return HandleServiceResult(result);
    }

    //[HttpPut]
    //public async Task<NotasDTO> Update(UpdateNotasDTO updateNotasDTO)
    //{

    //}

    //[HttpDelete]
    //public async Task<bool> Delete(int id)
    //{

    //}

}
