
using AutoMapper;
using FluentValidation;
using GestaoEscolar.Core.Interfaces;
using GestaoEscolar.Core.Services;
using GestaoEscolar.domain.DTOs.Notas;
using GestaoEscolar.domain.Interfaces.Repositories;
using GestaoEscolar.domain.Interfaces.Services;
using GestaoEscolar.domain.Models;

public class NotasService : INotasService
{
    private readonly IMapper _mapper;
    private readonly INotasRepository _notasRepository;
    private readonly IAlunoRepository _alunoRepository;
    private readonly IMateriaRepository _materiaRepository;
    private readonly IValidator<InsertNotasDTO> _insertValidator;
    private readonly IValidator<UpdateNotasDTO> _updateValidator;
    private readonly IValidationHelper _validationHelper;

    public NotasService(
        IMapper mapper,
        INotasRepository notasRepository,
        IAlunoRepository alunoRepository,
        IMateriaRepository materiaRepository,
        IValidator<InsertNotasDTO> insertValidator,
        IValidator<UpdateNotasDTO> updateValidator,
        IValidationHelper validationHelper)
    {
        _mapper = mapper;

        _notasRepository = notasRepository;
        _alunoRepository = alunoRepository;
        _materiaRepository = materiaRepository;

        _insertValidator = insertValidator;
        _updateValidator = updateValidator;
        _validationHelper = validationHelper;
    }

    public async Task<ServiceResult<IEnumerable<NotasDTO>>> GetAllAsync()
    {
        var notas = await _notasRepository.GetAllAsync();
        var notasDTO = _mapper.Map<IEnumerable<NotasDTO>>(notas.Data);
        return ServiceResult<IEnumerable<NotasDTO>>.SuccessResult(notasDTO);
    }

    public async Task<ServiceResult<NotasDTO>> GetKeyAsync(NotasDTO entity)
    {
        var nota = await _notasRepository.GetKeyAsync(n => n.Id == entity.Id);
        if (nota == null)
            return ServiceResult<NotasDTO>.FailureResult(new[] { $"Nota com o ID {entity.Id} não foi encontrada." });

        var notaDTO = _mapper.Map<NotasDTO>(nota);
        return ServiceResult<NotasDTO>.SuccessResult(notaDTO);
    }

    public async Task<ServiceResult<NotasDTO>> CreateAsync(InsertNotasDTO entity)
    {
        var validationResult = await _validationHelper.ValidateEntityAsync<InsertNotasDTO, NotasDTO>(entity, _insertValidator);
        if (validationResult != null)
            return validationResult;

        var aluno = await _alunoRepository.GetKeyAsync(a => a.Id == entity.AlunoId);
        if (aluno == null)
            return ServiceResult<NotasDTO>.FailureResult(new[] { $"Aluno com o ID { entity.AlunoId } não foi encontrado." });

        var materia = await _materiaRepository.GetKeyAsync(m => m.Id == entity.MateriaId);
        if (materia == null)
            return ServiceResult<NotasDTO>.FailureResult(new[] { $"Matéria com o ID { entity.AlunoId } não foi encontrada." });

        var nota = _mapper.Map<Notas>(entity);
        var createResult = await _notasRepository.CreateAsync(nota);
        if (!createResult.Success)
            return ServiceResult<NotasDTO>.FailureResult(createResult.Errors);

        var notasDTO = _mapper.Map<NotasDTO>(createResult.Data);
        return ServiceResult<NotasDTO>.SuccessResult(notasDTO);
    }

    public async Task<ServiceResult<NotasDTO>> UpdateAsync(UpdateNotasDTO entity)
    {
        var validationResult = await _validationHelper.ValidateEntityAsync<UpdateNotasDTO, NotasDTO>(entity, _updateValidator);
        if (validationResult != null)
            return validationResult;

        var nota = await _notasRepository.GetKeyAsync(n => n.Id == entity.Id);
        if (nota == null)
            return ServiceResult<NotasDTO>.FailureResult(new[] { $"Nota com o ID {entity.Id} não foi encontrada." });

        _mapper.Map(entity, nota);
        nota.DataAlteracao = DateTime.UtcNow;
        await _notasRepository.UpdateAsync(nota);

        var notaDTO = _mapper.Map<NotasDTO>(nota);
        return ServiceResult<NotasDTO>.SuccessResult(notaDTO);
    }

    public async Task<ServiceResult<NotasDTO>> DeleteAsync(int id)
    {
        var nota = await _notasRepository.GetKeyAsync(n => n.Id == id);
        if (nota == null)
            return ServiceResult<NotasDTO>.FailureResult(new[] { $"Nota com o ID {id} não foi encontrada." });

        var notaDTO = _mapper.Map<NotasDTO>(nota);
        await _notasRepository.DeleteAsync(nota);

        return ServiceResult<NotasDTO>.SuccessResult(notaDTO, "Nota deletada com sucesso.");
    }
}
