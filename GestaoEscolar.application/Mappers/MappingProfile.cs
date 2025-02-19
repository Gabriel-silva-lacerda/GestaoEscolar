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
            .ForMember(dest => dest.Professores, opt => opt.MapFrom(src => src.Professor))
            .ForMember(dest => dest.Alunos, opt => opt.MapFrom(src => src.Aluno))
            .ForMember(dest => dest.Materias, opt => opt.MapFrom(src => src.Materia))
            .ReverseMap();

        CreateMap<Turma, InsertTurmaDTO>().ReverseMap();
        CreateMap<Turma, UpdateTurmaDTO>().ReverseMap();
        CreateMap<Turma, TurmaResumoDTO>().ReverseMap();

        // Mapeamento para Notas
        CreateMap<Notas, NotasDTO>()
            .ForMember(dest => dest.AlunoId, opt => opt.MapFrom(src => src.AlunoId))
            .ForMember(dest => dest.MateriaId, opt => opt.MapFrom(src => src.MateriaId)).ReverseMap();
        CreateMap<Notas, InsertNotasDTO>().ReverseMap();
        CreateMap<Notas, UpdateNotasDTO>().ReverseMap();
        CreateMap<Notas, NotasResumoDTO>().ReverseMap();

        // Mapeamento para Conteúdo
        CreateMap<Conteudo, ConteudoDTO>().ReverseMap();
        CreateMap<Conteudo, InsertConteudoDTO>().ReverseMap();
        CreateMap<Conteudo, UpdateConteudoDTO>().ReverseMap();

        // Mapeamento para Matéria
        CreateMap<Materia, MateriaDTO>()
            .ForMember(dest => dest.Professores, opt => opt.MapFrom(src => src.Professor))
            .ForMember(dest => dest.Turmas, opt => opt.MapFrom(src => src.Turma))
            .ForMember(dest => dest.Notas, opt => opt.MapFrom(src => src.Notas))
            .ForMember(dest => dest.Conteudos, opt => opt.MapFrom(src => src.Conteudos))
            .ReverseMap();
        CreateMap<Materia, InsertMateriaDTO>().ReverseMap();
        CreateMap<Materia, UpdateMateriaDTO>().ReverseMap();
        CreateMap<Materia, MateriaResumoDTO>().ReverseMap();

        // Mapeamento para Professor
        CreateMap<Professor, ProfessorDTO>()
            .ForMember(dest => dest.Turmas, opt => opt.MapFrom(src => src.Turma))
            .ForMember(dest => dest.Materias, opt => opt.MapFrom(src => src.Materia));
        CreateMap<Professor, InsertProfessorDTO>().ReverseMap();
        CreateMap<Professor, UpdateProfessorDTO>().ReverseMap();
        CreateMap<Professor, ProfessorResumoDTO>().ReverseMap();
    }
}
