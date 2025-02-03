using GestaoEscolar.domain.DTOs.Notas;
using System.Linq.Expressions;

namespace GestaoEscolar.domain.Interfaces.Services;

public interface INotasService
{
    Task<IEnumerable<NotasDTO>> GetAllAsync();
    Task<NotasDTO> GetKeyAsync(NotasDTO notasDTO);
    Task<NotasDTO> Create(InsertNotasDTO notasDTO);
    Task<NotasDTO> Update(UpdateNotasDTO notasDTO);
    Task<bool> Delete(int id);
}
