using GestaoEscolar.domain.DTOs.Conteudo;
using GestaoEscolar.domain.DTOs.Notas;
using GestaoEscolar.domain.DTOs.Professor;
using GestaoEscolar.domain.DTOs.Turma;
using System.Text.Json.Serialization;

namespace GestaoEscolar.domain.DTOs.Materia;

public class MateriaDTO : BaseDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public ICollection<ProfessorResumoDTO> Professores { get; set; }
    public ICollection<TurmaResumoDTO> Turmas { get; set; }
    public ICollection<NotasResumoDTO> Notas { get; set; }
    public ICollection<ConteudoDTO> Conteudos { get; set; }
}
