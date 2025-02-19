using System.Text.Json.Serialization;

namespace GestaoEscolar.domain.Models;

public class Turma : BaseEntity
{
    public string Nome { get; set; }
    public ICollection<Professor> Professor { get; set; }
    public ICollection<Aluno> Aluno { get; set; }
    public ICollection<Materia> Materia { get; set; }

}
