using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEscolar.domain.Models;

public class ProfessorMateria
{
    public int ProfessorId { get; set; }
    public Professor Professor { get; set; }
    public int MateriaId { get; set; }
    public Materia Materia { get; set; }
}
