using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEscolar.domain.DTOs.Turma;

public class InsertTurmaDTO
{
    public string Nome { get; set; }
    public int ProfessorId { get; set; }
}
