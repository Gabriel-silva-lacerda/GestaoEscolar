
using System.Linq.Expressions;
using System.Security.Principal;
using AutoMapper;
using FluentValidation;
using GestaoEscolar.Core.Interfaces;
using GestaoEscolar.Core.Services;
using GestaoEscolar.domain.DTOs.Professor;
using GestaoEscolar.domain.Interfaces.Repositories;
using GestaoEscolar.domain.Interfaces.Services;
using GestaoEscolar.domain.Models;

public class ProfessorService : IProfessorService
{
    private readonly IMapper _mapper;

    private readonly IProfessorRepository _professorRepository;
    private readonly ITurmaRepository _turmaRepository;
    private readonly IMateriaRepository _materiaRepository;

    private readonly IValidator<InsertProfessorDTO> _insertValidator;
    private readonly IValidator<UpdateProfessorDTO> _updateValidator;
    private readonly IValidationHelper _validationHelper;

    public ProfessorService(
        IMapper mapper,
        IProfessorRepository professorRepository,
        ITurmaRepository turmaRepository,
        IMateriaRepository materiaRepository,
        IValidator<InsertProfessorDTO> insertValidator,
        IValidator<UpdateProfessorDTO> updateValidator,
        IValidationHelper validationHelper)
    {
        _mapper = mapper;

        _professorRepository = professorRepository;
        _turmaRepository = turmaRepository;
        _materiaRepository = materiaRepository;

        _insertValidator = insertValidator;
        _updateValidator = updateValidator;
        _validationHelper = validationHelper;
    }

    public async Task<ServiceResult<IEnumerable<ProfessorDTO>>> GetAllAsync()
    {
        var professores = await _professorRepository.GetAllWithIncludesAsync(p => p.Turma, p => p.Materia);
        var professoresDTO = _mapper.Map<IEnumerable<ProfessorDTO>>(professores);
        return ServiceResult<IEnumerable<ProfessorDTO>>.SuccessResult(professoresDTO);
    }

    public async Task<ServiceResult<ProfessorDTO>> GetKeyAsync(ProfessorDTO professorDTO)
    {
        var professor = await _professorRepository.GetByIdWithIncludesAsync(p => p.Id == professorDTO.Id, p => p.Turma, p => p.Materia);
        if (professor == null)
            return ServiceResult<ProfessorDTO>.FailureResult(new[] { $"Professor com o ID {professorDTO.Id} não foi encontrado." });

        var professorDTOResult = _mapper.Map<ProfessorDTO>(professor);
        return ServiceResult<ProfessorDTO>.SuccessResult(professorDTOResult);
    }

    public async Task<ServiceResult<ProfessorDTO>> CreateAsync(InsertProfessorDTO entity)
    {
        var validationResult = await _validationHelper.ValidateEntityAsync<InsertProfessorDTO, ProfessorDTO>(entity, _insertValidator);
        if (validationResult != null)
            return validationResult;

        var professor = _mapper.Map<Professor>(entity);

        var createResult = await _professorRepository.CreateAsync(professor);
        if (!createResult.Success)
            return ServiceResult<ProfessorDTO>.FailureResult(createResult.Errors);

        var professorDTOResult = _mapper.Map<ProfessorDTO>(createResult.Data);

        return ServiceResult<ProfessorDTO>.SuccessResult(professorDTOResult);
    }

    public async Task<ServiceResult<ProfessorDTO>> UpdateAsync(UpdateProfessorDTO professorDTO)
    {
        var validationResult = await _validationHelper.ValidateEntityAsync<UpdateProfessorDTO, ProfessorDTO>(professorDTO, _updateValidator);
        if (validationResult != null)
            return validationResult;

        var professor = await _professorRepository.GetByIdWithIncludesAsync(p => p.Id == professorDTO.Id, p => p.Turma, p => p.Materia);
        if (professor == null)
            return ServiceResult<ProfessorDTO>.FailureResult(new[] { $"Professor com o ID {professorDTO.Id} não foi encontrado." });

        _mapper.Map(professorDTO, professor);
        professor.DataAlteracao = DateTime.UtcNow;
        await _professorRepository.UpdateAsync(professor);

        var professorDTOResult = _mapper.Map<ProfessorDTO>(professor);
        return ServiceResult<ProfessorDTO>.SuccessResult(professorDTOResult);
    }

    public async Task<ServiceResult<ProfessorDTO>> DeleteAsync(int id)
    {
        var professor = await _professorRepository.GetByIdWithIncludesAsync(p => p.Id == id, p => p.Turma, p => p.Materia);
        if (professor == null)
            return ServiceResult<ProfessorDTO>.FailureResult(new[] { $"Professor com o ID {id} não foi encontrado." });

        var professorDTOResult = _mapper.Map<ProfessorDTO>(professor);
        await _professorRepository.DeleteAsync(professor);

        return ServiceResult<ProfessorDTO>.SuccessResult(professorDTOResult, "Professor deletado com sucesso.");
    }
}
