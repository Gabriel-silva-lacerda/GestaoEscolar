
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

    private readonly IValidator<InsertMateriaDTO> _insertValidator;
    private readonly IValidator<UpdateMateriaDTO> _updateValidator;
    private readonly IValidationHelper _validationHelper;

    public MateriaService(
        IMapper mapper, 
        IMateriaRepository materiaRepository,
        IValidator<InsertMateriaDTO> insertValidator,
        IValidator<UpdateMateriaDTO> updateValidator,
        IValidationHelper validationHelper)
    {
        _mapper = mapper;

        _materiaRepository = materiaRepository;

        _insertValidator = insertValidator;
        _updateValidator = updateValidator;
        _validationHelper = validationHelper;
    }

    public async Task<ServiceResult<IEnumerable<MateriaDTO>>> GetAllAsync()
    {
        var materias = await _materiaRepository.GetAllAsync();

        var materiasDTO = _mapper.Map<IEnumerable<MateriaDTO>>(materias.Data);

        return ServiceResult<IEnumerable<MateriaDTO>>.SuccessResult(materiasDTO);
    }

    public async Task<ServiceResult<MateriaDTO>> GetKeyAsync(MateriaDTO entity)
    {
        var materia = await _materiaRepository.GetKeyAsync(a => a.Id == entity.Id);
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

        var createResult = await _materiaRepository.CreateAsync(materia);
        if (!createResult.Success)
        {
            return ServiceResult<MateriaDTO>.FailureResult(createResult.Errors);
        }

        var materiaDTOResult = _mapper.Map<MateriaDTO>(createResult.Data);

        return ServiceResult<MateriaDTO>.SuccessResult(materiaDTOResult);
    }

    public async Task<ServiceResult<MateriaDTO>> UpdateAsync(UpdateMateriaDTO entity)
    {
        var validationResult = await _validationHelper.ValidateEntityAsync<UpdateMateriaDTO, MateriaDTO>(entity, _updateValidator);
        if (validationResult != null)
            return validationResult;

        var materia = await _materiaRepository.GetKeyAsync(a => a.Id == entity.Id);
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
        var materia = await _materiaRepository.GetKeyAsync(a => a.Id == id);
        if (materia == null)
            return ServiceResult<MateriaDTO>.FailureResult(new[] { $"Matéria com o ID { id } não foi encontrada." });

        var materiaDTO = _mapper.Map<MateriaDTO>(materia);

        await _materiaRepository.DeleteAsync(materia);

        return ServiceResult<MateriaDTO>.SuccessResult(materiaDTO, "Matéria deletada com sucesso.");
    }
}
