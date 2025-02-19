using System.Text.Json.Serialization;

namespace GestaoEscolar.domain.Models;

public class Materia : BaseEntity
{ 
    public string Nome { get; set; }
    public ICollection<Professor> Professor { get; set; }
    public ICollection<Turma> Turma { get; set; }
    public ICollection<Notas> Notas { get; set; }
    public ICollection<Conteudo> Conteudos { get; set; }
}
