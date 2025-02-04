
using System.Linq.Expressions;
using AutoMapper;
using FluentValidation;
using GestaoEscolar.Core.Interfaces;
using GestaoEscolar.Core.Services;
using GestaoEscolar.domain.DTOs.Aluno;
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
    public NotasService(IMapper mapper, INotasRepository notasRepository, IAlunoRepository alunoRepository, IMateriaRepository materiaRepository)
    {
        _notasRepository = notasRepository;
        _alunoRepository = alunoRepository;
        _materiaRepository = materiaRepository;
        //_turmaRepository = turmaRepository;
        _mapper = mapper;
        _alunoRepository = alunoRepository;
        _materiaRepository = materiaRepository;
        //_insertValidator = insertValidator;
        //_updateValidator = updateValidator;
        //_validationHelper = validationHelper;
    }
    public Task<ServiceResult<IEnumerable<NotasDTO>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<NotasDTO>> GetKeyAsync(NotasDTO notasDTO)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResult<NotasDTO>> CreateAsync(InsertNotasDTO entity)
    {
        var aluno = await _alunoRepository.GetKeyAsync(aluno => aluno.Id == entity.AlunoId);
        if (aluno == null)
            return ServiceResult<NotasDTO>.FailureResult(new[] { "Aluno não encontrado." });

        var materia = await _materiaRepository.GetKeyAsync(materia => materia.Id == entity.MateriaId);
        if (materia == null)
        {
            return ServiceResult<NotasDTO>.FailureResult(new List<string> { "Matéria não encontrada." });
        }

        var nota = _mapper.Map<Notas>(entity);
        //nota.Aluno = aluno;
        //nota.AlunoId = aluno.Id;
        //nota.Materia = materia;
        //nota.MateriaId = materia.Id;

        var createResult = await _notasRepository.CreateAsync(nota);
        if (!createResult.Success)
            return ServiceResult<NotasDTO>.FailureResult(createResult.Errors);

        var notasDTO = _mapper.Map<NotasDTO>(createResult.Data);

        return ServiceResult<NotasDTO>.SuccessResult(notasDTO);
    }


    public Task<ServiceResult<NotasDTO>> UpdateAsync(UpdateNotasDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResult<NotasDTO>> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
