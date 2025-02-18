using GestaoEscolar.Core.Services;
using GestaoEscolar.domain.DTOs.Professor;
using GestaoEscolar.domain.Models;
using GestaoEscolar.infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar.domain.Interfaces.Repositories;

public class ProfessorRepository : BaseRepository<Professor>, IProfessorRepository
{
    public ProfessorRepository(AppDbContext context) : base(context)
    {
    }

    public override async Task<ServiceResult<IEnumerable<Professor>>> GetAllAsync()
    {
            var professoresDTO = await _context.Profressores
            .Include(p => p.Turmas)
            .Include(p => p.Materias)
            .ToListAsync(); // Realiza a consulta com as projeções necessárias

            return ServiceResult<IEnumerable<Professor>>.SuccessResult(professoresDTO);
    }
}