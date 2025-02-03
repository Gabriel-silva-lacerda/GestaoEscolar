using GestaoEscolar.domain.DTOs.Materia;
using GestaoEscolar.domain.DTOs.Turma;

namespace GestaoEscolar.domain.DTOs.Professor;

public class ProfessorDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataInclusao { get; set; }
    public DateTime DataAlteracao { get; set; }
    public bool Status { get; set; }
    public ICollection<TurmaDTO> Turmas { get; set; }
    public ICollection<MateriaDTO> Materias { get; set; }
}
