﻿using GestaoEscolar.Core.Services;
using GestaoEscolar.domain.DTOs.Professor;
using GestaoEscolar.domain.DTOs.Turma;
using System.Linq.Expressions;

namespace GestaoEscolar.domain.Interfaces.Services;

public interface ITurmaAppService
{
    Task<ServiceResult<IEnumerable<TurmaDTO>>> GetAllAsync();
    Task<ServiceResult<TurmaDTO>> GetKeyAsync(TurmaDTO turmaDTO);
    Task<ServiceResult<TurmaDTO>> CreateAsync(InsertTurmaDTO turmaDTO);
    Task<ServiceResult<TurmaDTO>> UpdateAsync(UpdateTurmaDTO turmaDTO);
    Task<ServiceResult<TurmaDTO>> DeleteAsync(int id);
}
