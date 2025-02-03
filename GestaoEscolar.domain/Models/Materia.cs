namespace GestaoEscolar.domain.Models;

public class Materia
{ 
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataInclusao { get; set; }
    public DateTime DataAlteracao { get; set; }
    public ICollection<Professor> Professores { get; set; }
    public ICollection<Turma> Turmas { get; set; }
    public ICollection<Notas> Notas { get; set; }
    public ICollection<Conteudo> Conteudos { get; set; }
}
