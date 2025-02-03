using System;
using System.Linq.Expressions;
using GestaoEscolar.domain.Models;
using GestaoEscolar.infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar.domain.Interfaces.Repositories;

public class TurmaRepository : BaseRepository<Turma>, ITurmaRepository
{
    public TurmaRepository(AppDbContext context) : base(context)
    {}
}