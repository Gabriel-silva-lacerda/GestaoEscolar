using System.Text.Json.Serialization;

namespace GestaoEscolar.domain.Models;

public class Professor : BaseEntity
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public bool Status { get; set; }
    [JsonIgnore]
    public ICollection<Turma> Turma { get; set; }
    [JsonIgnore]
    public ICollection<Materia> Materia { get; set; }

}
