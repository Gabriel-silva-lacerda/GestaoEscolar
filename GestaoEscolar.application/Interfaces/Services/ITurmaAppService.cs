﻿using GestaoEscolar.application.Common;
using GestaoEscolar.domain.DTOs.Professor;
using GestaoEscolar.domain.DTOs.Turma;
using System.Linq.Expressions;

namespace GestaoEscolar.domain.Interfaces.Services;

public interface ITurmaAppService
{
    Task<IEnumerable<TurmaDTO>> GetAllAsync();
    Task<TurmaDTO> GetKeyAsync(TurmaDTO turmaDTO);
    Task<ServiceResult<TurmaDTO>> CreateAsync(InsertTurmaDTO turmaDTO);
    //Task<ServiceResult<TurmaDTO>> CreateAsync(InsertTurmaDTO turmaDTO);
    Task<TurmaDTO> Update(UpdateTurmaDTO turmaDTO);
    Task<bool> DeleteAsync(int id);
}
