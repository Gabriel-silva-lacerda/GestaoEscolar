using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEscolar.domain.Models;

public class Conteudo : BaseEntity
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int MateriaId { get; set; }
    public Materia Materia { get; set; }
}
