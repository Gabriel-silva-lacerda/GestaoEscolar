namespace GestaoEscolar.domain.Models;

public class Turma : BaseEntity
{
    public string Nome { get; set; }
    public ICollection<Professor> Professores { get; set; }
    public ICollection<Aluno> Alunos { get; set; }
    public ICollection<Materia> Materias { get; set; }

}
