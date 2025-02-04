namespace GestaoEscolar.domain.Models;

public class Professor : BaseEntity
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public bool Status { get; set; }
    public ICollection<Turma> Turmas { get; set; }
    public ICollection<Materia> Materias { get; set; }

}
