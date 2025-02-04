using GestaoEscolar.Core.Services;
using GestaoEscolar.domain.DTOs.Aluno;
using GestaoEscolar.domain.Interfaces.Services;

public class AlunoAppService : IAlunoAppService
{
    private readonly IAlunoService _alunoService;

    public AlunoAppService(IAlunoService alunoService)
    {
        _alunoService = alunoService;
    }

    public async Task<ServiceResult<AlunoDTO>> CreateAsync(InsertAlunoDTO alunoDTO)
    {
        // Delegando ao serviço
        return await _alunoService.CreateAsync(alunoDTO);
    }

    public async Task<ServiceResult<AlunoDTO>> DeleteAsync(int id)
    {
        // Delegando ao serviço
        return await _alunoService.DeleteAsync(id);
    }

    public async Task<ServiceResult<IEnumerable<AlunoDTO>>> GetAllAsync()
    {
        // Delegando ao serviço
        return await _alunoService.GetAllAsync();
    }

    public async Task<ServiceResult<AlunoDTO>> GetKeyAsync(AlunoDTO alunoDTO)
    {
        // Delegando ao serviço
        return await _alunoService.GetKeyAsync(alunoDTO);
    }

    public async Task<ServiceResult<AlunoDTO>> UpdateAsync(UpdateAlunoDTO alunoDTO)
    {
        // Delegando ao serviço
        return await _alunoService.UpdateAsync(alunoDTO);
    }
}
