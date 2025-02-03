using GestaoEscolar.domain.Models;
using GestaoEscolar.infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar.domain.Interfaces.Repositories;

public class ConteudoRepository : BaseRepository<Conteudo>, IConteudoRepository
{
    public ConteudoRepository(AppDbContext context) : base(context)
    {
    }
}
