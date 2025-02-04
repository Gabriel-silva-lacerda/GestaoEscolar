namespace GestaoEscolar.domain.Models;

public class Materia : BaseEntity
{ 
    public string Nome { get; set; }
    public ICollection<Professor> Professores { get; set; }
    public ICollection<Turma> Turmas { get; set; }
    public ICollection<Notas> Notas { get; set; }
    public ICollection<Conteudo> Conteudos { get; set; }
}
