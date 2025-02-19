using GestaoEscolar.domain.DTOs.Aluno;
using GestaoEscolar.domain.DTOs.Materia;
using GestaoEscolar.domain.DTOs.Professor;
using System.Text.Json.Serialization;

namespace GestaoEscolar.domain.DTOs.Turma;

public class TurmaDTO : BaseDTO
{
    public string Nome { get; set; }
    public ICollection<ProfessorResumoDTO> Professores { get; set; }
    public ICollection<AlunoDTO> Alunos { get; set; }
    public ICollection<MateriaResumoDTO> Materias { get; set; }
}
