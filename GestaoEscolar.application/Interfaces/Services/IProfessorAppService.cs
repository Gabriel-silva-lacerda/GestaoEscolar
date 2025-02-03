using GestaoEscolar.domain.DTOs.Notas;
using GestaoEscolar.domain.DTOs.Professor;
using System.Linq.Expressions;

namespace GestaoEscolar.domain.Interfaces.Services;

public interface IProfessorAppService
{
    Task<IEnumerable<ProfessorDTO>> GetAllAsync();
    Task<ProfessorDTO> GetKeyAsync(ProfessorDTO professorDTO);
    Task<ProfessorDTO> Create(InsertProfessorDTO professorDTO);
    Task<ProfessorDTO> Update(UpdateProfessorDTO professorDTO);
    Task<bool> Delete(int id);
}
