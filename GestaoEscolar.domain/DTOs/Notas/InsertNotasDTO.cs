using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEscolar.domain.DTOs.Notas;

public class InsertNotasDTO
{
    public double Nota { get; set; }
    public int AlunoId { get; set; }
    public int MateriaId { get; set; }
}
