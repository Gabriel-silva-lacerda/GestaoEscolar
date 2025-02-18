using GestaoEscolar.Core.Services;
using GestaoEscolar.domain.DTOs.Notas;
using GestaoEscolar.domain.DTOs.Professor;
using System.Linq.Expressions;

namespace GestaoEscolar.domain.Interfaces.Services;

public interface IProfessorService
{
    Task<ServiceResult<IEnumerable<ProfessorDTO>>> GetAllAsync();
    Task<ServiceResult<ProfessorDTO>> GetKeyAsync(ProfessorDTO professorDTO);
    Task<ServiceResult<ProfessorDTO>> CreateAsync(InsertProfessorDTO professorDTO);
    Task<ServiceResult<ProfessorDTO>> UpdateAsync(UpdateProfessorDTO professorDTO);
    Task<ServiceResult<ProfessorDTO>> DeleteAsync(int id);
}
