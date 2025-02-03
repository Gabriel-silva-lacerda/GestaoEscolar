using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEscolar.domain.Models;

public class Notas
{
    public int Id { get; set; }
    public double Nota { get; set; }
    public DateTime DataInclusao { get; set; }
    public DateTime DataAlteracao { get; set; }
    public int AlunoId { get; set; }
    public Aluno Aluno { get; set; }
    public int MateriaId { get; set; }
    public Materia Materia { get; set; }
}
