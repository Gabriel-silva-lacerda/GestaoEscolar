

using AutoMapper;
using FluentValidation;
using GestaoEscolar.Core.Interfaces;
using GestaoEscolar.Core.Services;
using GestaoEscolar.domain.DTOs.Aluno;
using GestaoEscolar.domain.Interfaces.Repositories;
using GestaoEscolar.domain.Interfaces.Services;
using GestaoEscolar.domain.Models;
using GestaoEscolar.domain.Validators.Helpers;

public class AlunoService : IAlunoService
{
    private readonly IMapper _mapper;

    private readonly IAlunoRepository _alunoRepository;
    private readonly ITurmaRepository _turmaRepository;

    private readonly IValidator<InsertAlunoDTO> _insertValidator;
    private readonly IValidator<UpdateAlunoDTO> _updateValidator;
    private readonly IValidationHelper _validationHelper;
    private readonly ICPFValidator _cpfValidator;
    public AlunoService(
        IMapper mapper,
        IAlunoRepository alunoRepository, 
        ITurmaRepository turmaRepository, 
        IValidator<InsertAlunoDTO> insertValidator,
        IValidator<UpdateAlunoDTO> updateValidator,
        IValidationHelper validationHelper,
        ICPFValidator cpfValidator)
    {
        _mapper = mapper;

        _alunoRepository = alunoRepository;
        _turmaRepository = turmaRepository;
        
        _insertValidator = insertValidator;
        _updateValidator = updateValidator;
        _validationHelper = validationHelper;
        _cpfValidator = cpfValidator;
    }

    public async Task<ServiceResult<IEnumerable<AlunoDTO>>> GetAllAsync()
    {
        // Recupera todos os alunos
        var alunos = await _alunoRepository.GetAllWithIncludesAsync(a => a.Notas);

        // Converte para uma lista de DTOs usando AutoMapper
        var alunosDTO = _mapper.Map<IEnumerable<AlunoDTO>>(alunos);

        // Retorna os alunos no formato de sucesso
        return ServiceResult<IEnumerable<AlunoDTO>>.SuccessResult(alunosDTO);
    }

    public async Task<ServiceResult<AlunoDTO>> GetByIdAsync(int id)
    {
        // Busca o aluno pelo ID no DTO
        var aluno = await _alunoRepository.GetByIdWithIncludesAsync(a => a.Id == id, p => p.Notas);
        if (aluno == null)
            return ServiceResult<AlunoDTO>.FailureResult(new[] { $"Aluno com o ID { id } não foi encontrado." });


        // Converte para DTO usando AutoMapper
        var alunoDTO = _mapper.Map<AlunoDTO>(aluno);
        return ServiceResult<AlunoDTO>.SuccessResult(alunoDTO);
    }

    public async Task<ServiceResult<AlunoDTO>> GetByCpfAsync(string cpf)
    {
        // Busca o aluno pelo ID no DTO
        if (!_cpfValidator.CPFValido(cpf))
            return ServiceResult<AlunoDTO>.FailureResult(new[] { "CPF inválido." });

        var aluno = await _alunoRepository.GetByIdWithIncludesAsync(a => a.CPF == cpf, p => p.Notas);
        if (aluno == null)
            return ServiceResult<AlunoDTO>.FailureResult(new[] { $"Aluno com o CPF { cpf } não foi encontrado." });

        // Converte para DTO usando AutoMapper
        var alunoDTO = _mapper.Map<AlunoDTO>(aluno);
        return ServiceResult<AlunoDTO>.SuccessResult(alunoDTO);
    }

    public async Task<ServiceResult<AlunoDTO>> CreateAsync(InsertAlunoDTO entity)
    {
        var validationResult = await _validationHelper.ValidateEntityAsync<InsertAlunoDTO, AlunoDTO>(entity, _insertValidator);
        if (validationResult != null)
            return validationResult;

        var turmaExiste = await _turmaRepository.GetKeyAsync(t => t.Id == entity.TurmaId);
        if (turmaExiste == null)
            return ServiceResult<AlunoDTO>.FailureResult(new[] { $"A turma associada ao ID $ {entity.TurmaId } não existe." });

        if (!_cpfValidator.CPFValido(entity.CPF))
            return ServiceResult<AlunoDTO>.FailureResult(new[] { "CPF inválido." });

        var aluno = _mapper.Map<Aluno>(entity);

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
        var aluno = await _alunoRepository.GetByIdWithIncludesAsync(a => a.Id == entity.Id, p => p.Notas);
        if (aluno == null)
            return ServiceResult<AlunoDTO>.FailureResult(new[] { "Aluno não encontrado." });

        if (!_cpfValidator.CPFValido(entity.CPF))
            return ServiceResult<AlunoDTO>.FailureResult(new[] { "CPF inválido." });

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
        var aluno = await _alunoRepository.GetByIdWithIncludesAsync(a => a.Id == id, p => p.Notas);
        if (aluno == null)
            return ServiceResult<AlunoDTO>.FailureResult(new[] { "Aluno não encontrado." });

        var alunoDTO = _mapper.Map<AlunoDTO>(aluno);

        // Remove do banco de dados
        await _alunoRepository.DeleteAsync(aluno);

        return ServiceResult<AlunoDTO>.SuccessResult(alunoDTO, "Aluno deletado com sucesso.");
    }
}
