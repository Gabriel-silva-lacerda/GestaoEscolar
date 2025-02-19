using GestaoEscolar.Core.Services;
using GestaoEscolar.domain.Models;
using GestaoEscolar.infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar.domain.Interfaces.Repositories;

public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
{
    public AlunoRepository(AppDbContext context) : base(context)
    {
    }

    public override async Task<ServiceResult<IEnumerable<Aluno>>> GetAllAsync()
    {
        var alunos = await _context.Aluno
                                    .Include(a => a.Notas) 
                                    .ToListAsync();

        return ServiceResult<IEnumerable<Aluno>>.SuccessResult(alunos);
    }
}
