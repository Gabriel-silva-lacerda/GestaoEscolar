

using AutoMapper;
using FluentValidation;
using GestaoEscolar.Core.Interfaces;
using GestaoEscolar.Core.Services;
using GestaoEscolar.domain.DTOs.Aluno;
using GestaoEscolar.domain.Interfaces.Repositories;
using GestaoEscolar.domain.Interfaces.Services;
using GestaoEscolar.domain.Models;

public class AlunoService : IAlunoService
{
    private readonly IMapper _mapper;

    private readonly IAlunoRepository _alunoRepository;
    private readonly ITurmaRepository _turmaRepository;

    private readonly IValidator<InsertAlunoDTO> _insertValidator;
    private readonly IValidator<UpdateAlunoDTO> _updateValidator;
    private readonly IValidationHelper _validationHelper;

    public AlunoService(
        IAlunoRepository alunoRepository, 
        ITurmaRepository turmaRepository, 
        IMapper mapper,
        IValidationHelper validationHelper,
        IValidator<InsertAlunoDTO> insertValidator,
        IValidator<UpdateAlunoDTO> updateValidator)
    {
        _alunoRepository = alunoRepository;
        _turmaRepository = turmaRepository; 
        _mapper = mapper;
        _insertValidator = insertValidator;
        _updateValidator = updateValidator;
        _validationHelper = validationHelper;
    }

    public async Task<ServiceResult<IEnumerable<AlunoDTO>>> GetAllAsync()
    {
        // Recupera todos os alunos
        var alunos = await _alunoRepository.GetAllAsync();

        // Converte para uma lista de DTOs usando AutoMapper
        var alunosDTO = _mapper.Map<IEnumerable<AlunoDTO>>(alunos.Data);

        // Retorna os alunos no formato de sucesso
        return ServiceResult<IEnumerable<AlunoDTO>>.SuccessResult(alunosDTO);
    }

    public async Task<ServiceResult<AlunoDTO>> GetKeyAsync(AlunoDTO entity)
    {
        // Busca o aluno pelo ID no DTO
        var aluno = await _alunoRepository.GetKeyAsync(a => a.Id == entity.Id);
        if (aluno == null)
            return ServiceResult<AlunoDTO>.FailureResult(new[] { $"Aluno com o ID { entity.Id } não foi encontrado." });


        // Converte para DTO usando AutoMapper
        var alunoDTO = _mapper.Map<AlunoDTO>(aluno);
        return ServiceResult<AlunoDTO>.SuccessResult(alunoDTO);
    }

    public async Task<ServiceResult<AlunoDTO>> CreateAsync(InsertAlunoDTO entity)
    {
        var validationResult = await _validationHelper.ValidateEntityAsync<InsertAlunoDTO, AlunoDTO>(entity, _insertValidator);
        if (validationResult != null)
            return validationResult;

        var turmaExiste = await _turmaRepository.ExistsAsync(t => t.Id == entity.TurmaId);
        if (!turmaExiste)
            return ServiceResult<AlunoDTO>.FailureResult(new[] { "A turma associada ao ID fornecido não existe." });

        var aluno = _mapper.Map<Aluno>(entity);

        // Define os campos adicionais
        aluno.DataInclusao = DateTime.UtcNow;
        aluno.DataAlteracao = DateTime.UtcNow;

        // Adiciona ao banco de dados
        var createResult = await _alunoRepository.CreateAsync(aluno);

        // Verifica se a criação foi bem-sucedida
        if (!createResult.Success)
            return ServiceResult<AlunoDTO>.FailureResult(createResult.Errors);

        // Mapeia a entidade criada para o DTO
        var alunoDTO = _mapper.Map<AlunoDTO>(createResult.Data);

        // Retorna sucesso com o DTO e a mensagem de sucesso
        return ServiceResult<AlunoDTO>.SuccessResult(alunoDTO);
    }

    public async Task<ServiceResult<AlunoDTO>> UpdateAsync(UpdateAlunoDTO entity)
    {
        var validationResult = await _validationHelper.ValidateEntityAsync<UpdateAlunoDTO, AlunoDTO>(entity, _updateValidator);
        if (validationResult != null)
            return validationResult;

        // Busca o aluno pelo ID
        var aluno = await _alunoRepository.GetKeyAsync(a => a.Id == entity.Id);
        if (aluno == null)
            return ServiceResult<AlunoDTO>.FailureResult(new[] { "Aluno não encontrado." });

        // Atualiza os campos da entidade com AutoMapper
        _mapper.Map(entity, aluno);

        // Atualiza a data de alteração
        aluno.DataAlteracao = DateTime.UtcNow;

        // Atualiza no banco
        await _alunoRepository.UpdateAsync(aluno);

        // Retorna o DTO atualizado usando AutoMapper
        var alunoDTO = _mapper.Map<AlunoDTO>(aluno);
        return ServiceResult<AlunoDTO>.SuccessResult(alunoDTO);
    }

    public async Task<ServiceResult<AlunoDTO>> DeleteAsync(int id)
    {
        // Busca o aluno pelo ID
        var aluno = await _alunoRepository.GetKeyAsync(a => a.Id == id);
        if (aluno == null)
            return ServiceResult<AlunoDTO>.FailureResult(new[] { "Aluno não encontrado." });

        var alunoDTO = _mapper.Map<AlunoDTO>(aluno);

        // Remove do banco de dados
        await _alunoRepository.DeleteAsync(aluno);

        return ServiceResult<AlunoDTO>.SuccessResult(alunoDTO, "Aluno deletado com sucesso.");
    }
}
