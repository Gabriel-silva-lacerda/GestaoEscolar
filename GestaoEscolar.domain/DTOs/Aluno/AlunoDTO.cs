    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoEscolar.domain.DTOs.Notas;

namespace GestaoEscolar.domain.DTOs.Aluno;

public class AlunoDTO : BaseDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public bool Situacao { get; set; }
    public string CPF { get; set; }
    public int TurmaId { get; set; }
    public IEnumerable<NotasResumoDTO> Notas { get; set; }
}
