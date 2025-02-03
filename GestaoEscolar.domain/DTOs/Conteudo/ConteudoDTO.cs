using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEscolar.domain.DTOs.Conteudo;

public class ConteudoDTO
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataInclusao { get; set; }
    public DateTime DataAlteracao { get; set; }
    public int MateriaId { get; set; }
}
