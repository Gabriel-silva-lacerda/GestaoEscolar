
using AutoMapper;
using FluentValidation;
using GestaoEscolar.Core.Interfaces;
using GestaoEscolar.Core.Services;
using GestaoEscolar.domain.DTOs.Materia;
using GestaoEscolar.domain.Interfaces.Repositories;
using GestaoEscolar.domain.Interfaces.Services;
using GestaoEscolar.domain.Models;

public class MateriaService : IMateriaService
{
    private readonly IMapper _mapper;
    private readonly IMateriaRepository _materiaRepository;
    private readonly ITurmaRepository _turmaRepository;
    private readonly IProfessorRepository _professorRepository;
    private readonly IValidator<InsertMateriaDTO> _insertValidator;
    private readonly IValidator<UpdateMateriaDTO> _updateValidator;
    private readonly IValidationHelper _validationHelper;

    public MateriaService(
        IMapper mapper,
        IMateriaRepository materiaRepository,
        ITurmaRepository turmaRepository,
        IProfessorRepository professorRepository,
        IValidator<InsertMateriaDTO> insertValidator,
        IValidator<UpdateMateriaDTO> updateValidator,
        IValidationHelper validationHelper)
    {
        _mapper = mapper;
        _materiaRepository = materiaRepository;
        _turmaRepository = turmaRepository;
        _professorRepository = professorRepository;
        _insertValidator = insertValidator;
        _updateValidator = updateValidator;
        _validationHelper = validationHelper;
    }

    public async Task<ServiceResult<IEnumerable<MateriaDTO>>> GetAllAsync()
    {
        var materias = await _materiaRepository.GetAllWithIncludesAsync(m => m.Professor, m => m.Turma, m => m.Notas, m => m.Conteudos);
        var materiasDTO = _mapper.Map<IEnumerable<MateriaDTO>>(materias);
        return ServiceResult<IEnumerable<MateriaDTO>>.SuccessResult(materiasDTO);
    }

    public async Task<ServiceResult<MateriaDTO>> GetKeyAsync(MateriaDTO entity)
    {
        var materia = await _materiaRepository.GetByIdWithIncludesAsync(m => m.Id == entity.Id, m => m.Professor, m => m.Turma, m => m.Notas, m => m.Conteudos);
        if (materia == null)
            return ServiceResult<MateriaDTO>.FailureResult(new[] { $"Matéria com o ID {entity.Id} não foi encontrada." });


        var materiaDTO = _mapper.Map<MateriaDTO>(materia);
        return ServiceResult<MateriaDTO>.SuccessResult(materiaDTO);
    }

    public async Task<ServiceResult<MateriaDTO>> CreateAsync(InsertMateriaDTO entity)
    {
        var validationResult = await _validationHelper.ValidateEntityAsync<InsertMateriaDTO, MateriaDTO>(entity, _insertValidator);
        if (validationResult != null)
            return validationResult;

        var materiaExistente = await _materiaRepository.GetKeyAsync(m => m.Nome == entity.Nome);
        if (materiaExistente != null)
            return ServiceResult<MateriaDTO>.FailureResult(new[] { $"Matéria com o nome {entity.Nome } já existe." });

        var materia = _mapper.Map<Materia>(entity);

        var professor = await _professorRepository.GetKeyAsync(p => p.Id == entity.ProfessorId);
        if (professor == null)
            return ServiceResult<MateriaDTO>.FailureResult(new[] { $"Professor com o ID {entity.ProfessorId} não foi encontrado." });

        var turma = await _turmaRepository.GetKeyAsync(t => t.Id == entity.TurmaId);
        if (turma == null)
            return ServiceResult<MateriaDTO>.FailureResult(new[] { $"Turma com o ID {entity.TurmaId} não foi encontrada." });

        materia.Professor ??= new List<Professor>();
        materia.Turma ??= new List<Turma>();

        materia.Professor.Add(professor);
        materia.Turma.Add(turma);

        var createResult = await _materiaRepository.CreateAsync(materia);
        if (!createResult.Success)
            return ServiceResult<MateriaDTO>.FailureResult(createResult.Errors);

        var materiaDTO = _mapper.Map<MateriaDTO>(createResult.Data);

        return ServiceResult<MateriaDTO>.SuccessResult(materiaDTO);
    }

    public async Task<ServiceResult<MateriaDTO>> UpdateAsync(UpdateMateriaDTO entity)
    {
        var validationResult = await _validationHelper.ValidateEntityAsync<UpdateMateriaDTO, MateriaDTO>(entity, _updateValidator);
        if (validationResult != null)
            return validationResult;

        var materia = await _materiaRepository.GetByIdWithIncludesAsync(m => m.Id == entity.Id, m => m.Professor, m => m.Turma, m => m.Notas, m => m.Conteudos);
        if (materia == null)
            return ServiceResult<MateriaDTO>.FailureResult(new[] { $"Matéria com o ID { entity.Id } não foi encontrada." });

        _mapper.Map(entity, materia);

        materia.DataAlteracao = DateTime.UtcNow;

        await _materiaRepository.UpdateAsync(materia);

        var materiaDTO = _mapper.Map<MateriaDTO>(materia);
        return ServiceResult<MateriaDTO>.SuccessResult(materiaDTO);
    }

    public async Task<ServiceResult<MateriaDTO>> DeleteAsync(int id)
    {
        var materia = await _materiaRepository.GetByIdWithIncludesAsync(m => m.Id == id, m => m.Professor, m => m.Turma, m => m.Notas, m => m.Conteudos);
        if (materia == null)
            return ServiceResult<MateriaDTO>.FailureResult(new[] { $"Matéria com o ID { id } não foi encontrada." });

        var materiaDTO = _mapper.Map<MateriaDTO>(materia);

        await _materiaRepository.DeleteAsync(materia);

        return ServiceResult<MateriaDTO>.SuccessResult(materiaDTO, "Matéria deletada com sucesso.");
    }
}
