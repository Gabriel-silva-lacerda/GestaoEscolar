using GestaoEscolar.domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar.infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Professor> Profressor { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Conteudo> Conteudo { get; set; }
        public DbSet<Turma> Turma { get; set; }
        public DbSet<Notas> Nota { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<Administrador> Administrador { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
            // .SelectMany(e => e.GetForeignKeys()))
            //{
            //    foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            //};

            //base.OnModelCreating(modelBuilder);
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
           .SelectMany(e => e.GetForeignKeys()))
                {
                    foreignKey.DeleteBehavior = DeleteBehavior.Cascade; // Permite exclusão em cascata
                }

            base.OnModelCreating(modelBuilder);
        }
    }
}
