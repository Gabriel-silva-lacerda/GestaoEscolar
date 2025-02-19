using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestaoEscolar.domain.DTOs.Professor;

public class UpdateProfessorDTO
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
}
