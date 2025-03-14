﻿using System.Linq.Expressions;
using GestaoEscolar.Core.Services;
using GestaoEscolar.domain.DTOs.Aluno;
using GestaoEscolar.domain.Models;

namespace GestaoEscolar.domain.Interfaces.Services;

public interface IAlunoAppService
{
    Task<ServiceResult<IEnumerable<AlunoDTO>>> GetAllAsync();
    Task<ServiceResult<AlunoDTO>> GetByIdAsync(int id);
    Task<ServiceResult<AlunoDTO>> GetByCpfAsync(string cpf);
    Task<ServiceResult<AlunoDTO>> CreateAsync(InsertAlunoDTO alunoDTO);
    Task<ServiceResult<AlunoDTO>> UpdateAsync(UpdateAlunoDTO alunoDTO);
    Task<ServiceResult<AlunoDTO>> DeleteAsync(int id);
}
