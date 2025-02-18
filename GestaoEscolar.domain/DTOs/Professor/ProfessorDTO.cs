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
    //public ICollection<TurmaDTO> Turmas { get; set; }
    //public ICollection<MateriaDTO> Materias { get; set; }

    //public List<int> TurmaIds { get; set; } = new List<int>();  // Inicializa a lista como uma lista vazia, caso não seja fornecida
    //public List<int> MateriaIds { get; set; } = new List<int>();

    public ICollection<string> Turmas { get; set; }
    public ICollection<string> Materias { get; set; }
}
