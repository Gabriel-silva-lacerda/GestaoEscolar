
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
    private readonly IProfessorRepository _professorRepository;

    private readonly IValidator<InsertTurmaDTO> _insertValidator;
    private readonly IValidator<UpdateTurmaDTO> _updateValidator;
    private readonly IValidationHelper _validationHelper;

    public TurmaService(
        ITurmaRepository turmaRepository, 
        IAlunoRepository alunoRepository,
        IProfessorRepository professorRepository,
        IMapper mapper,
        IValidationHelper validationHelper,
        IValidator<InsertTurmaDTO> insertValidator,
        IValidator<UpdateTurmaDTO> updateValidator)
    {
        _turmaRepository = turmaRepository;
        _professorRepository = professorRepository;
        _alunoRepository = alunoRepository;
        _mapper = mapper;
        _insertValidator = insertValidator;
        _updateValidator = updateValidator;
        _validationHelper = validationHelper;
    }

    public async Task<ServiceResult<IEnumerable<TurmaDTO>>> GetAllAsync()
    {
        var turmas = await _turmaRepository.GetAllWithIncludesAsync(t => t.Aluno, t => t.Professor, t => t.Materia);
        var turmasDTO = _mapper.Map<IEnumerable<TurmaDTO>>(turmas);
        return ServiceResult<IEnumerable<TurmaDTO>>.SuccessResult(turmasDTO);
    }

    public async Task<ServiceResult<TurmaDTO>> GetKeyAsync(TurmaDTO entity)
    {
        var turma = await _turmaRepository.GetByIdWithIncludesAsync( t => t.Id == entity.Id, t => t.Aluno, t => t.Professor, t => t.Materia);

        if (turma == null)
            ServiceResult<TurmaDTO>.FailureResult(new[] { $"Turma com o ID { entity.Id } não foi encontrada." });
        
        var turmaDTO = _mapper.Map<TurmaDTO>(turma);
        return ServiceResult<TurmaDTO>.SuccessResult(turmaDTO);
    }

    public async Task<ServiceResult<TurmaDTO>> CreateAsync(InsertTurmaDTO entity)
    {

        var validationResult = await _validationHelper.ValidateEntityAsync<InsertTurmaDTO, TurmaDTO>(entity, _insertValidator);
        if (validationResult != null)
            return validationResult;

        var turma = _mapper.Map<Turma>(entity);

        var professor = await _professorRepository.GetKeyAsync(p => p.Id == entity.ProfessorId);
        if (professor == null)
            return ServiceResult<TurmaDTO>.FailureResult(new[] { $"Professor com o ID { entity.ProfessorId } não foi encontrado." });

        professor.Turma ??= new List<Turma>();
        professor.Turma.Add(turma);

        var createResult = await _turmaRepository.CreateAsync(turma);

        if (!createResult.Success)
            return ServiceResult<TurmaDTO>.FailureResult(createResult.Errors);
        
        var turmaDTO = _mapper.Map<TurmaDTO>(createResult.Data);
        return ServiceResult<TurmaDTO>.SuccessResult(turmaDTO);
    }

    public async Task<ServiceResult<TurmaDTO>> UpdateAsync(UpdateTurmaDTO entity)
    {
        var turma = await _turmaRepository.GetByIdWithIncludesAsync(t => t.Id == entity.Id, t => t.Aluno, t => t.Professor, t => t.Materia);
        
        if (turma == null)
            return ServiceResult<TurmaDTO>.FailureResult(new[] { $"Turma com o ID {entity.Id} não foi encontrada." });


        _mapper.Map(entity, turma);
        turma.DataAlteracao = DateTime.UtcNow;

        var updatedTurma = await _turmaRepository.UpdateAsync(turma);

        var turmaDTO = _mapper.Map<TurmaDTO>(updatedTurma);
        return ServiceResult<TurmaDTO>.SuccessResult(turmaDTO);
    }
    public async Task<ServiceResult<TurmaDTO>> DeleteAsync(int id)
    {
        var turma = await _turmaRepository.GetKeyAsync(t => t.Id == id);
        if (turma == null)
            return ServiceResult<TurmaDTO>.FailureResult(new[] { $"Turma com o ID {id} não foi encontrada." });

        var turmaDTO = _mapper.Map<TurmaDTO>(turma);

        await _turmaRepository.DeleteAsync(turma);
        return ServiceResult<TurmaDTO>.SuccessResult(turmaDTO);
    }

}
