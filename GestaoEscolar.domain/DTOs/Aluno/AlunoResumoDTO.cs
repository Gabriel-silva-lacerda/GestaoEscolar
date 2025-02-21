using GestaoEscolar.domain.DTOs.Notas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEscolar.domain.DTOs.Aluno;

public class AlunoResumoDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public bool Situacao { get; set; }
    public string CPF { get; set; }
}
