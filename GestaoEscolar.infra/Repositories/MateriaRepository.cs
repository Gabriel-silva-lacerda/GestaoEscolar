using GestaoEscolar.domain.Models;
using GestaoEscolar.infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar.domain.Interfaces.Repositories;

public class MateriaRepository : BaseRepository<Materia>, IMateriaRepository
{
    public MateriaRepository(AppDbContext context) : base(context)
    {
    }
}
