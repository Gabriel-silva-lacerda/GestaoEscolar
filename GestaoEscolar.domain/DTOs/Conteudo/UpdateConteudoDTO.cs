using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestaoEscolar.domain.DTOs.Conteudo;

public class UpdateConteudoDTO
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
}
