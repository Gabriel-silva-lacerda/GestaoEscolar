
using System.Linq.Expressions;
using GestaoEscolar.Core.Services;
using GestaoEscolar.domain.DTOs.Professor;
using GestaoEscolar.domain.Interfaces.Services;

public class ProfessorAppService : IProfessorAppService
{
    private readonly IProfessorService _professorService;

    public ProfessorAppService(IProfessorService professorService)
    {
        _professorService = professorService;
    }

    public async Task<ServiceResult<IEnumerable<ProfessorDTO>>> GetAllAsync()
    {
        return await _professorService.GetAllAsync();
    }

    public async Task<ServiceResult<ProfessorDTO>> GetKeyAsync(ProfessorDTO professorDTO)
    {
        return await _professorService.GetKeyAsync(professorDTO);
    }

    public async Task<ServiceResult<ProfessorDTO>> CreateAsync(InsertProfessorDTO professorDTO)
    {
        return await _professorService.CreateAsync(professorDTO);
    }
    public async Task<ServiceResult<ProfessorDTO>> UpdateAsync(UpdateProfessorDTO professorDTO)
    {
        return await _professorService.UpdateAsync(professorDTO);
    }

    public async Task<ServiceResult<ProfessorDTO>> DeleteAsync(int id)
    {
        return await _professorService.DeleteAsync(id);
    }
   
}

