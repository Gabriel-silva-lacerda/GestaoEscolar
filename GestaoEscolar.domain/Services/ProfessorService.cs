
using System.Linq.Expressions;
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

    private readonly IValidator<InsertProfessorDTO> _insertValidator;
    private readonly IValidator<UpdateProfessorDTO> _updateValidator;
    private readonly IValidationHelper _validationHelper;

    public ProfessorService(
        IMapper mapper,
        IProfessorRepository professorRepository,
        ITurmaRepository turmaRepository,
        IValidator<InsertProfessorDTO> insertValidator,
        IValidator<UpdateProfessorDTO> updateValidator,
        IValidationHelper validationHelper)
    {
        _mapper = mapper;

        _professorRepository = professorRepository;
        _turmaRepository = turmaRepository;

        _insertValidator = insertValidator;
        _updateValidator = updateValidator;
        _validationHelper = validationHelper;
    }

    public async Task<ServiceResult<IEnumerable<ProfessorDTO>>> GetAllAsync()
    {
        var professores = await _professorRepository.GetAllAsync();
        var professoresDTO = _mapper.Map<IEnumerable<ProfessorDTO>>(professores.Data);
        return ServiceResult<IEnumerable<ProfessorDTO>>.SuccessResult(professoresDTO);
    }

    public async Task<ServiceResult<ProfessorDTO>> GetKeyAsync(ProfessorDTO professorDTO)
    {
        var professor = await _professorRepository.GetKeyAsync(p => p.Id == professorDTO.Id);
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

        //var professor = _mapper.Map<Professor>(entity);

        var professor = new Professor
        {
            Nome = entity.Nome,
            Sobrenome = entity.Sobrenome,
            //DataInclusao = DateTime.UtcNow,
            Status = true,
            Turmas = new List<Turma>(),
            Materias = new List<Materia>()
        };

        foreach (var turmaId in entity.TurmaIds)
        {
            var turma = await _turmaRepository.GetKeyAsync(t => t.Id == turmaId);
            if (turma != null)
            {

                professor.Turmas.Add(turma);
            }
            else
            {
                return ServiceResult<ProfessorDTO>.FailureResult(new[] { $"Turma com ID {turmaId} não encontrada." });
            }
        }

        var createResult = await _professorRepository.CreateAsync(professor);
        if (!createResult.Success)
            return ServiceResult<ProfessorDTO>.FailureResult(createResult.Errors);

        var professorDTOResult = _mapper.Map<ProfessorDTO>(createResult.Data);

        //professorDTOResult.TurmaIds = professor.Turmas.Select(t => t.Id).ToList();
        //professorDTOResult.MateriaIds = professor.Materias.Select(m => m.Id).ToList();

        return ServiceResult<ProfessorDTO>.SuccessResult(professorDTOResult);
    }

    public async Task<ServiceResult<ProfessorDTO>> UpdateAsync(UpdateProfessorDTO professorDTO)
    {
        var validationResult = await _validationHelper.ValidateEntityAsync<UpdateProfessorDTO, ProfessorDTO>(professorDTO, _updateValidator);
        if (validationResult != null)
            return validationResult;

        var professor = await _professorRepository.GetKeyAsync(p => p.Id == professorDTO.Id);
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
        var professor = await _professorRepository.GetKeyAsync(p => p.Id == id);
        if (professor == null)
            return ServiceResult<ProfessorDTO>.FailureResult(new[] { $"Professor com o ID {id} não foi encontrado." });

        var professorDTOResult = _mapper.Map<ProfessorDTO>(professor);
        await _professorRepository.DeleteAsync(professor);

        return ServiceResult<ProfessorDTO>.SuccessResult(professorDTOResult, "Professor deletado com sucesso.");
    }
}
