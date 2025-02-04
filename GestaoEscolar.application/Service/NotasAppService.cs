
using System.Linq.Expressions;
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

    public Task<ServiceResult<IEnumerable<NotasDTO>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<NotasDTO>> GetKeyAsync(NotasDTO notasDTO)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResult<NotasDTO>> CreateAsync(InsertNotasDTO notasDTO)
    {
        return await _notasService.CreateAsync(notasDTO);
    }
    public Task<ServiceResult<NotasDTO>> UpdateAsync(UpdateNotasDTO notasDTO)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<NotasDTO>> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
