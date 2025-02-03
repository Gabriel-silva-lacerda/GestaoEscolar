using GestaoEscolar.domain.DTOs.Aluno;
using GestaoEscolar.domain.DTOs.Materia;
using GestaoEscolar.domain.DTOs.Professor;

namespace GestaoEscolar.domain.DTOs.Turma;

public class TurmaDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataInclusao { get; set; }
    public DateTime DataAlteracao { get; set; }
    public ICollection<ProfessorDTO> Professores { get; set; }
    public ICollection<AlunoDTO> Alunos { get; set; }
    public ICollection<MateriaDTO> Materias { get; set; }
}
