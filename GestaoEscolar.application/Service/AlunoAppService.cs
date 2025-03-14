﻿using GestaoEscolar.Core.Services;
using GestaoEscolar.domain.DTOs.Aluno;
using GestaoEscolar.domain.Interfaces.Services;

public class AlunoAppService : IAlunoAppService
{
    private readonly IAlunoService _alunoService;

    public AlunoAppService(IAlunoService alunoService)
    {
        _alunoService = alunoService;
    }

    public async Task<ServiceResult<IEnumerable<AlunoDTO>>> GetAllAsync()
    {
        return await _alunoService.GetAllAsync();
    }

    public async Task<ServiceResult<AlunoDTO>> GetByIdAsync(int id)
    {
        return await _alunoService.GetByIdAsync(id);
    }


    public async Task<ServiceResult<AlunoDTO>> GetByCpfAsync(string cpf)
    {
        return await _alunoService.GetByCpfAsync(cpf);
    }

    public async Task<ServiceResult<AlunoDTO>> CreateAsync(InsertAlunoDTO alunoDTO)
    {
        return await _alunoService.CreateAsync(alunoDTO);
    }

    public async Task<ServiceResult<AlunoDTO>> UpdateAsync(UpdateAlunoDTO alunoDTO)
    {
        return await _alunoService.UpdateAsync(alunoDTO);
    }

    public async Task<ServiceResult<AlunoDTO>> DeleteAsync(int id)
    {
        return await _alunoService.DeleteAsync(id);
    }

}
