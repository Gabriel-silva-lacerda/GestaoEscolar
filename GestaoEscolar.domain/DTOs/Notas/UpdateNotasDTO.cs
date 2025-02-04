using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEscolar.domain.DTOs.Notas;

public class UpdateNotasDTO
{
    public int Id { get; set; }
    public double Nota { get; set; }
}
