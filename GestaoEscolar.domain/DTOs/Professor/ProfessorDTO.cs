using GestaoEscolar.domain.DTOs.Materia;
using GestaoEscolar.domain.DTOs.Turma;
using System.Text.Json.Serialization;

namespace GestaoEscolar.domain.DTOs.Professor;

public class ProfessorDTO : BaseDTO
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public bool Status { get; set; }
    //[JsonIgnore]
    public IEnumerable<TurmaResumoDTO> Turmas { get; set; }
    //[JsonIgnore]
    public IEnumerable<MateriaResumoDTO> Materias { get; set; }
}
