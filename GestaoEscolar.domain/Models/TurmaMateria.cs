using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEscolar.domain.Models;

public class TurmaMateria
{
    public int TurmaId { get; set; }
    public Turma Turma { get; set; }

    public int MateriaId { get; set; }
    public Materia Materia { get; set; }
}
