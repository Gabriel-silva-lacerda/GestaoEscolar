using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEscolar.domain.DTOs;

public abstract class BaseDTO
{
    //public int Id { get; set; }
    public DateTime DataInclusao { get; set; } = DateTime.UtcNow;
    public DateTime? DataAlteracao { get; set; } // Agora pode ser nulo
}
