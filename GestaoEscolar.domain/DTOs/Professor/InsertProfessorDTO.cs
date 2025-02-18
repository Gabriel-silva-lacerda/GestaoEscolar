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
    public ICollection<int> TurmaIds { get; set; } // Lista de IDs de turmas
}
