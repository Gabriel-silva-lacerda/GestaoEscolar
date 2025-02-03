using GestaoEscolar.domain.Models;
using GestaoEscolar.infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar.domain.Interfaces.Repositories;

public class NotasRepository : BaseRepository<Notas>, INotasRepository
{
    public NotasRepository(AppDbContext context) : base(context)
    {
    }
}

