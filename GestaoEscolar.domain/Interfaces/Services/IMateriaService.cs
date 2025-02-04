using GestaoEscolar.Core.Services;
using GestaoEscolar.domain.DTOs.Conteudo;
using GestaoEscolar.domain.DTOs.Materia;
using System.Linq.Expressions;

namespace GestaoEscolar.domain.Interfaces.Services;

public interface IMateriaService
{
    Task<ServiceResult<IEnumerable<MateriaDTO>>> GetAllAsync();
    Task<ServiceResult<MateriaDTO>> GetKeyAsync(MateriaDTO materiaDTO);
    Task<ServiceResult<MateriaDTO>> CreateAsync(InsertMateriaDTO materiaDTO);
    Task<ServiceResult<MateriaDTO>> UpdateAsync(UpdateMateriaDTO materiaDTO);
    Task<ServiceResult<MateriaDTO>> DeleteAsync(int id);
}
