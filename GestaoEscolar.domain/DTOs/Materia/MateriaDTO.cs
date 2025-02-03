using GestaoEscolar.domain.DTOs.Conteudo;
using GestaoEscolar.domain.DTOs.Notas;
using GestaoEscolar.domain.DTOs.Professor;
using GestaoEscolar.domain.DTOs.Turma;

namespace GestaoEscolar.domain.DTOs.Materia;

public class MateriaDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataInclusao { get; set; }
    public DateTime DataAlteracao { get; set; }
    public ICollection<ProfessorDTO> Professores { get; set; }
    public ICollection<TurmaDTO> Turmas { get; set; }
    public ICollection<NotasDTO> Notas { get; set; }
    public ICollection<ConteudoDTO> Conteudos { get; set; }
}
