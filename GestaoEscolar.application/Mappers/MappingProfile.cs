using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GestaoEscolar.domain.DTOs.Aluno;
using GestaoEscolar.domain.DTOs.Conteudo;
using GestaoEscolar.domain.DTOs.Materia;
using GestaoEscolar.domain.DTOs.Notas;
using GestaoEscolar.domain.DTOs.Professor;
using GestaoEscolar.domain.DTOs.Turma;
using GestaoEscolar.domain.Models;

namespace GestaoEscolar.application.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapeamento para Aluno
        CreateMap<Aluno, AlunoDTO>()
            .ForMember(dest => dest.Notas, opt => opt.MapFrom(src => src.Notas)) // Mapeando as notas
            .ForMember(dest => dest.TurmaId, opt => opt.MapFrom(src => src.TurmaId)) // TurmaId já é direto
            .ReverseMap();

        CreateMap<Aluno, InsertAlunoDTO>().ReverseMap();
        CreateMap<Aluno, UpdateAlunoDTO>().ReverseMap();

        // Mapeamento para Turma
        CreateMap<Turma, TurmaDTO>()
            .ForMember(dest => dest.Alunos, opt => opt.MapFrom(src => src.Alunos)) // Incluindo os alunos
            .ReverseMap();

        CreateMap<Turma, InsertTurmaDTO>().ReverseMap();
        CreateMap<Turma, UpdateTurmaDTO>().ReverseMap();

        // Mapeamento para Notas
        CreateMap<Notas, NotasDTO>().ReverseMap();
        CreateMap<Notas, InsertNotasDTO>()
            .ForMember(dest => dest.AlunoId, opt => opt.MapFrom(src => src.AlunoId))
            .ForMember(dest => dest.MateriaId, opt => opt.MapFrom(src => src.MateriaId))
            .ReverseMap();
        CreateMap<Notas, UpdateNotasDTO>().ReverseMap();

        // Outros mapeamentos continuam como estão
        CreateMap<Conteudo, ConteudoDTO>().ReverseMap();
        CreateMap<Conteudo, InsertConteudoDTO>().ReverseMap();
        CreateMap<Conteudo, UpdateConteudoDTO>().ReverseMap();

        CreateMap<Materia, MateriaDTO>().ReverseMap();
        CreateMap<Materia, InsertMateriaDTO>().ReverseMap();
        CreateMap<Materia, UpdateMateriaDTO>().ReverseMap();

        //CreateMap<Professor, ProfessorDTO>().ReverseMap();
        CreateMap<Professor, ProfessorDTO>()
         .ForMember(dest => dest.Turmas, opt => opt.MapFrom(src => src.Turmas.Select(t => t.Nome)))  // Mapear os nomes das turmas
         .ForMember(dest => dest.Materias, opt => opt.MapFrom(src => src.Materias.Select(m => m.Nome)));
        //CreateMap<InsertProfessorDTO, Professor>()
        //   .ForMember(dest => dest.Turmas, opt => opt.MapFrom(src =>
        //       src.TurmaIds.Select(turmaId => new Turma { Id = turmaId }).ToList()))  // Mapeia os IDs para as turmas
        //.ReverseMap();

        // CreateMap<Professor, ProfessorDTO>()
        //.ForMember(dest => dest.Turmas, opt => opt.MapFrom(src => src.Turmas)) // Turmas associadas ao professor
        //.ForMember(dest => dest.Materias, opt => opt.MapFrom(src => src.Materias)) // Materias associadas ao professor
        //.ReverseMap();
        CreateMap<Professor, InsertProfessorDTO>().ReverseMap();
        CreateMap<Professor, UpdateProfessorDTO>().ReverseMap();
    }
}
