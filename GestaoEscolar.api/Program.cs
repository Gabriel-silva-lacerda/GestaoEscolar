using FluentValidation;
using GestaoEscolar.application.Mappers;
using GestaoEscolar.Core.Interfaces;
using GestaoEscolar.domain.DTOs.Aluno;
using GestaoEscolar.domain.DTOs.Materia;
using GestaoEscolar.domain.DTOs.Notas;
using GestaoEscolar.domain.DTOs.Turma;
using GestaoEscolar.domain.Interfaces.Repositories;
using GestaoEscolar.domain.Interfaces.Services;
using GestaoEscolar.domain.Validators.Aluno;
using GestaoEscolar.domain.Validators.Base;
using GestaoEscolar.domain.Validators.Materia;
using GestaoEscolar.domain.Validators.Notas;
using GestaoEscolar.domain.Validators.Turmas;
using GestaoEscolar.infra.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<IAlunoAppService, AlunoAppService>();

builder.Services.AddScoped<ITurmaRepository, TurmaRepository>();
builder.Services.AddScoped<ITurmaService, TurmaService>();
builder.Services.AddScoped<ITurmaAppService, TurmaAppService>();

builder.Services.AddScoped<IMateriaRepository, MateriaRepository>();
builder.Services.AddScoped<IMateriaService, MateriaService>();
builder.Services.AddScoped<IMateriaAppService, MateriaAppService>();

// Registra o repositório, serviço e app service para Notas
builder.Services.AddScoped<INotasRepository, NotasRepository>();
builder.Services.AddScoped<INotasService, NotasService>();
builder.Services.AddScoped<INotasAppService, NotasAppService>();

// Validator Aluno
builder.Services.AddTransient<IValidator<InsertAlunoDTO>, InsertAlunoDTOValidator>();
builder.Services.AddTransient<IValidator<UpdateAlunoDTO>, UpdateAlunoDTOValidator>();
// Validator Aluno

// Validator Turma
builder.Services.AddScoped<IValidator<InsertTurmaDTO>, InsertTurmaDTOValidator>();
builder.Services.AddScoped<IValidator<UpdateTurmaDTO>, UpdateTurmaDTOValidator>();
// Validator Turma

// Validator Materia
builder.Services.AddScoped<IValidator<InsertMateriaDTO>, InsertMateriaDTOValidator>();
builder.Services.AddScoped<IValidator<UpdateMateriaDTO>, UpdateMateriaDTOValidator>();
// Validator Materia

// Validator Notas
builder.Services.AddScoped<IValidator<InsertNotasDTO>, InsertNotasDTOValidator>();
builder.Services.AddScoped<IValidator<UpdateNotasDTO>, UpdateNotasDTOValidator>();
// Validator Notas

// Validator lógica
builder.Services.AddTransient<IValidationHelper, ValidationHelper>();
// Validator lógica

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
