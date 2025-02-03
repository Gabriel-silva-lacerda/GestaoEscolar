namespace GestaoEscolar.domain.Models;

public class Professor
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataInclusao { get; set; }
    public DateTime DataAlteracao { get; set; }
    public bool Status { get; set; }
    public ICollection<Turma> Turmas { get; set; }
    public ICollection<Materia> Materias { get; set; }

}
