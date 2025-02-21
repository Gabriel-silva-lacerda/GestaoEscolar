using System.Text.Json.Serialization;

namespace GestaoEscolar.domain.Models;

public class Materia : BaseEntity
{ 
    public string Nome { get; set; }
    public ICollection<Professor> Professor { get; set; } = new List<Professor>();
    public ICollection<Turma> Turma { get; set; } = new List<Turma>();
    public ICollection<Notas> Notas { get; set; }
    public ICollection<Conteudo> Conteudos { get; set; }
}
