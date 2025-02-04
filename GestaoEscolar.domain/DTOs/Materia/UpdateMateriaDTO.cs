using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestaoEscolar.domain.DTOs.Materia;

public class UpdateMateriaDTO
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Nome { get; set; }
}
