using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEscolar.domain.DTOs.Aluno;

public class InsertAlunoDTO
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public bool Situacao { get; set; }
    public string CPF { get; set; }
    public int TurmaId { get; set; }
}
