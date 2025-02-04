
using GestaoEscolar.Core.Services;
using GestaoEscolar.domain.DTOs.Notas;
using GestaoEscolar.domain.Interfaces.Services;

public class NotasAppService : INotasAppService
{
    private readonly INotasService _notasService;

    public NotasAppService(INotasService notasService)
    {
        _notasService = notasService;
    }

    public async Task<ServiceResult<IEnumerable<NotasDTO>>> GetAllAsync()
    {
        return await _notasService.GetAllAsync();
    }

    public async Task<ServiceResult<NotasDTO>> GetKeyAsync(NotasDTO notasDTO)
    {
        return await _notasService.GetKeyAsync(notasDTO);
    }

    public async Task<ServiceResult<NotasDTO>> CreateAsync(InsertNotasDTO notasDTO)
    {
        return await _notasService.CreateAsync(notasDTO);
    }

    public async Task<ServiceResult<NotasDTO>> UpdateAsync(UpdateNotasDTO notasDTO)
    {
        return await _notasService.UpdateAsync(notasDTO);
    }

    public async Task<ServiceResult<NotasDTO>> DeleteAsync(int id)
    {
        return await _notasService.DeleteAsync(id);
    }
}
