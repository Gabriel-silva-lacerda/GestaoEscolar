using GestaoEscolar.domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar.infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Professor> Profressores { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Conteudo> Conteudos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Notas> Notas { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Administrador> Administrador { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
             .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            };

            base.OnModelCreating(modelBuilder);
        }
    }
}
