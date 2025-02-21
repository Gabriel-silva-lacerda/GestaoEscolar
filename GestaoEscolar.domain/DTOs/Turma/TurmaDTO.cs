using GestaoEscolar.domain.DTOs.Aluno;
using GestaoEscolar.domain.DTOs.Materia;
using GestaoEscolar.domain.DTOs.Professor;
using System.Text.Json.Serialization;

namespace GestaoEscolar.domain.DTOs.Turma;

public class TurmaDTO : BaseDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public IEnumerable<ProfessorResumoDTO> Professores { get; set; }
    public IEnumerable<AlunoResumoDTO> Alunos { get; set; }
    public IEnumerable<MateriaResumoDTO> Materias { get; set; }
}
