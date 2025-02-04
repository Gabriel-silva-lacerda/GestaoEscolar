
using System.Linq.Expressions;
using AutoMapper;
using FluentValidation;
using GestaoEscolar.Core.Interfaces;
using GestaoEscolar.Core.Services;
using GestaoEscolar.domain.DTOs.Aluno;
using GestaoEscolar.domain.DTOs.Turma;
using GestaoEscolar.domain.Interfaces.Repositories;
using GestaoEscolar.domain.Interfaces.Services;
using GestaoEscolar.domain.Models;
using GestaoEscolar.domain.Validators.Base;

public class TurmaService : ITurmaService
{
    private readonly IMapper _mapper;

    private readonly ITurmaRepository _turmaRepository;
    private readonly IAlunoRepository _alunoRepository;

    private readonly IValidator<InsertTurmaDTO> _insertValidator;
    private readonly IValidator<UpdateTurmaDTO> _updateValidator;
    private readonly IValidationHelper _validationHelper;

    public TurmaService(
        ITurmaRepository turmaRepository, 
        IAlunoRepository alunoRepository, 
        IMapper mapper,
        IValidationHelper validationHelper,
        IValidator<InsertTurmaDTO> insertValidator,
        IValidator<UpdateTurmaDTO> updateValidator)
    {
        _turmaRepository = turmaRepository;
        _alunoRepository = alunoRepository;
        _mapper = mapper;
        _insertValidator = insertValidator;
        _updateValidator = updateValidator;
        _validationHelper = validationHelper;
    }

    public async Task<ServiceResult<IEnumerable<TurmaDTO>>> GetAllAsync()
    {
        // Busca todas as turmas
        var turmas = await _turmaRepository.GetAllWithIncludesAsync(t => t.Alunos, t => t.Professores, t => t.Materias);

        var turmasDTO = _mapper.Map<IEnumerable<TurmaDTO>>(turmas);
        // Mapeia para uma lista de DTOs
        return ServiceResult<IEnumerable<TurmaDTO>>.SuccessResult(turmasDTO);
    }

    public async Task<ServiceResult<TurmaDTO>> GetKeyAsync(TurmaDTO entity)
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
            ServiceResult<TurmaDTO>.FailureResult(new[] { $"Turma com o ID { entity.Id } não foi encontrada." });
        
        // Retorna o DTO da turma encontrada
        var turmaDTO = _mapper.Map<TurmaDTO>(turma);
        return ServiceResult<TurmaDTO>.SuccessResult(turmaDTO);
    }

    public async Task<ServiceResult<TurmaDTO>> CreateAsync(InsertTurmaDTO entity)
    {

        var validationResult = await _validationHelper.ValidateEntityAsync<InsertTurmaDTO, TurmaDTO>(entity, _insertValidator);
        if (validationResult != null)
            return validationResult;

        // Mapeia o DTO para a entidade de domínio
        var turma = _mapper.Map<Turma>(entity);
        turma.DataInclusao = DateTime.UtcNow;
        turma.DataAlteracao = DateTime.UtcNow;

        // Usa o repositório para criar a turma no banco
        var createResult = await _turmaRepository.CreateAsync(turma);

        // Verifica se a criação foi bem-sucedida
        if (!createResult.Success)
            return ServiceResult<TurmaDTO>.FailureResult(createResult.Errors);
        

        // Mapeia a entidade criada para o DTO e retorna sucesso
        var turmaDTO = _mapper.Map<TurmaDTO>(createResult.Data);
        return ServiceResult<TurmaDTO>.SuccessResult(turmaDTO);
    }

    public async Task<ServiceResult<TurmaDTO>> UpdateAsync(UpdateTurmaDTO entity)
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
            return ServiceResult<TurmaDTO>.FailureResult(new[] { $"Turma com o ID {entity.Id} não foi encontrada." });


        // Atualiza os dados usando o mapeador
        _mapper.Map(entity, turma);
        turma.DataAlteracao = DateTime.UtcNow;

        // Atualiza no banco
        var updatedTurma = await _turmaRepository.UpdateAsync(turma);

        // Retorna o DTO atualizado
        var turmaDTO = _mapper.Map<TurmaDTO>(updatedTurma);
        return ServiceResult<TurmaDTO>.SuccessResult(turmaDTO);
    }
    public async Task<ServiceResult<TurmaDTO>> DeleteAsync(int id)
    {
        // Busca a turma pelo ID
        var turma = await _turmaRepository.GetKeyAsync(t => t.Id == id);
        if (turma == null)
            return ServiceResult<TurmaDTO>.FailureResult(new[] { $"Turma com o ID {id} não foi encontrada." });

        var turmaDTO = _mapper.Map<TurmaDTO>(turma);

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
        return ServiceResult<TurmaDTO>.SuccessResult(turmaDTO);
    }

}
