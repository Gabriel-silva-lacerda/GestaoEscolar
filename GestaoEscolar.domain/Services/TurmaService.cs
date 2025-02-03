
using System.Linq.Expressions;
using AutoMapper;
using FluentValidation;
using GestaoEscolar.application.Common;
using GestaoEscolar.domain.DTOs.Turma;
using GestaoEscolar.domain.Interfaces.Repositories;
using GestaoEscolar.domain.Interfaces.Services;
using GestaoEscolar.domain.Models;

public class TurmaService : ITurmaService
{
    private readonly ITurmaRepository _turmaRepository;
    private readonly IAlunoRepository _alunoRepository;

    private readonly IMapper _mapper;
    private readonly IValidator<InsertTurmaDTO> _validator;

    public TurmaService(ITurmaRepository turmaRepository, IAlunoRepository alunoRepository, IMapper mapper, IValidator<InsertTurmaDTO> validator)
    {
        _turmaRepository = turmaRepository;
        _alunoRepository = alunoRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<ServiceResult<TurmaDTO>> CreateAsync(InsertTurmaDTO entity)
    {
        var validationResult = await _validator.ValidateAsync(entity);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage);
            return ServiceResult<TurmaDTO>.FailureResult(errors);
        }

        // Mapeia o DTO para a entidade de domínio
        var turma = _mapper.Map<Turma>(entity);
        turma.DataInclusao = DateTime.UtcNow;
        turma.DataAlteracao = DateTime.UtcNow;

        // Usa o repositório para criar a turma no banco
        var createResult = await _turmaRepository.CreateAsync(turma);

        // Verifica se a criação foi bem-sucedida
        if (!createResult.Success)
        {
            return ServiceResult<TurmaDTO>.FailureResult(createResult.Errors);
        }

        // Mapeia a entidade criada para o DTO e retorna sucesso
        var turmaDTO = _mapper.Map<TurmaDTO>(createResult.Data);
        return ServiceResult<TurmaDTO>.SuccessResult(turmaDTO);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        // Busca a turma pelo ID
        var turma = await _turmaRepository.GetKeyAsync(t => t.Id == id);
        if (turma == null)
        {
            return false; // Turma não encontrada
        }

        var alunosRelacionados = await _alunoRepository.GetByAsync(a => a.TurmaId == id);
        if (alunosRelacionados.Any())
        {
            // Exclui os alunos relacionados
            foreach (var aluno in alunosRelacionados)
            {
                await _alunoRepository.DeleteAsync(aluno);
            }
        }

        // Remove a turma
        await _turmaRepository.DeleteAsync(turma);
        return true;
    }

    public async Task<IEnumerable<TurmaDTO>> GetAllAsync()
    {
        // Busca todas as turmas
        var turmas = await _turmaRepository.GetAllWithIncludesAsync(t => t.Alunos, t => t.Professores, t => t.Materias);

        // Mapeia para uma lista de DTOs
        return _mapper.Map<IEnumerable<TurmaDTO>>(turmas);
    }

    public async Task<TurmaDTO> GetKeyAsync(TurmaDTO turmaDTO)
    {
        // Busca a turma pelo ID
        var turma = await _turmaRepository
            .GetByIdWithIncludesAsync(
                t => t.Id == turmaDTO.Id,
                t => t.Alunos,
                t => t.Professores,
                t => t.Materias
        );

        if (turma == null)
        {
            throw new KeyNotFoundException($"Turma com o ID {turmaDTO.Id} não foi encontrada.");
        }
        // Retorna o DTO da turma encontrada
        return _mapper.Map<TurmaDTO>(turma);
    }


    public async Task<TurmaDTO> Update(UpdateTurmaDTO entity)
    {
        // Busca a turma pelo ID
        var turma = await _turmaRepository
            .GetByIdWithIncludesAsync(
                t => t.Id == entity.Id,
                t => t.Alunos,
                t => t.Professores,
                t => t.Materias
        );
        
        if (turma == null)
        {
            throw new KeyNotFoundException($"Turma com o ID {entity.Id} não foi encontrada.");
        }

        // Atualiza os dados usando o mapeador
        _mapper.Map(entity, turma);
        turma.DataAlteracao = DateTime.UtcNow;

        // Atualiza no banco
        var updatedTurma = _turmaRepository.UpdateAsync(turma);

        // Retorna o DTO atualizado
        return _mapper.Map<TurmaDTO>(updatedTurma);
    }
}
