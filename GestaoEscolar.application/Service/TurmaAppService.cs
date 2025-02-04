using GestaoEscolar.Core.Services;
using GestaoEscolar.domain.DTOs.Turma;
using GestaoEscolar.domain.Interfaces.Services;

public class TurmaAppService : ITurmaAppService
{
    private readonly ITurmaService _turmaService;

    public TurmaAppService(ITurmaService turmaService)
    {
        _turmaService = turmaService;
    }
    public async Task<ServiceResult<IEnumerable<TurmaDTO>>> GetAllAsync()
    {
        // Chama o serviço de domínio para buscar todas as turmas
        return await _turmaService.GetAllAsync();
    }
    public async Task<ServiceResult<TurmaDTO>> GetKeyAsync(TurmaDTO turmaDTO)
    {
        // Chama o serviço de domínio para buscar a turma específica
        return await _turmaService.GetKeyAsync(turmaDTO);
    }

    public async Task<ServiceResult<TurmaDTO>> CreateAsync(InsertTurmaDTO turmaDTO)
    {
        // Chama o serviço de domínio para criar a turma
        return await _turmaService.CreateAsync(turmaDTO);
    }

    public async Task<ServiceResult<TurmaDTO>> UpdateAsync(UpdateTurmaDTO entity)
    {
        // Chama o serviço de domínio para atualizar a turma
        return await _turmaService.UpdateAsync(entity);
    }

    public async Task<ServiceResult<TurmaDTO>> DeleteAsync(int id)
    {
        // Chama o serviço de domínio para deletar a turma
        return await _turmaService.DeleteAsync(id);
    }
}
