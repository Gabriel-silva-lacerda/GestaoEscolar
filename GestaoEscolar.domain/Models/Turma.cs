namespace GestaoEscolar.domain.Models;

public class Turma
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataInclusao { get; set; }
    public DateTime DataAlteracao { get; set; }
    public ICollection<Professor> Professores { get; set; }
    public ICollection<Aluno> Alunos { get; set; }
    public ICollection<Materia> Materias { get; set; }

}
