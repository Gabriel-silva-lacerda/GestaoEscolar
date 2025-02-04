using GestaoEscolar.Core.Services;
using GestaoEscolar.domain.DTOs.Notas;
using System.Linq.Expressions;

namespace GestaoEscolar.domain.Interfaces.Services;

public interface INotasService
{
    Task<ServiceResult<IEnumerable<NotasDTO>>> GetAllAsync();
    Task<ServiceResult<NotasDTO>> GetKeyAsync(NotasDTO notasDTO);
    Task<ServiceResult<NotasDTO>> CreateAsync(InsertNotasDTO notasDTO);
    Task<ServiceResult<NotasDTO>> UpdateAsync(UpdateNotasDTO notasDTO);
    Task<ServiceResult<NotasDTO>> DeleteAsync(int id);
}
