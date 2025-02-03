using GestaoEscolar.domain.Models;
using GestaoEscolar.infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar.domain.Interfaces.Repositories;

public class ProfessorRepository : BaseRepository<Professor>, IProfessorRepository
{
    public ProfessorRepository(AppDbContext context) : base(context)
    {
    }
}