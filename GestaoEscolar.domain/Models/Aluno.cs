using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEscolar.domain.Models;

public class Aluno : BaseEntity
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public bool Situacao { get; set; }
    public string CPF { get; set; }
    public int TurmaId { get; set; }
    public Turma Turma { get; set; }
    public ICollection<Notas> Notas { get; set; }
}
