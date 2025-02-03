
using System.Linq.Expressions;
using GestaoEscolar.application.Common;
using GestaoEscolar.domain.DTOs.Turma;
using GestaoEscolar.domain.Interfaces.Services;

public class TurmaAppService : ITurmaAppService
{
    private readonly ITurmaService _turmaService;

    public TurmaAppService(ITurmaService turmaService)
    {
        _turmaService = turmaService;
    }
    public async Task<IEnumerable<TurmaDTO>> GetAllAsync()
    {
        // Chama o serviço de domínio para buscar todas as turmas
        return await _turmaService.GetAllAsync();
    }
    public async Task<ServiceResult<TurmaDTO>> CreateAsync(InsertTurmaDTO turmaDTO)
    {
        // Chama o serviço de domínio para criar a turma
        return await _turmaService.CreateAsync(turmaDTO);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        // Chama o serviço de domínio para deletar a turma
        return await _turmaService.DeleteAsync(id);
    }

    public async Task<TurmaDTO> GetKeyAsync(TurmaDTO turmaDTO)
    {
        // Chama o serviço de domínio para buscar a turma específica
        return await _turmaService.GetKeyAsync(turmaDTO);
    }

    public async Task<TurmaDTO> Update(UpdateTurmaDTO entity)
    {
        // Chama o serviço de domínio para atualizar a turma
        return await _turmaService.Update(entity);
    }
}
