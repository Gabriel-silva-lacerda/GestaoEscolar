using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEscolar.domain.DTOs.Professor;

public class InsertProfessorDTO
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    //public List<int> TurmaIds { get; set; }
    //public List<int> MateriaIds { get; set; }
}
