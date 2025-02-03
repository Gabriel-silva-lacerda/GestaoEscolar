using GestaoEscolar.domain.DTOs.Aluno;
using GestaoEscolar.domain.DTOs.Conteudo;
using System.Linq.Expressions;

namespace GestaoEscolar.domain.Interfaces.Services;

public interface IConteudoService
{
    Task<IEnumerable<ConteudoDTO>> GetAllAsync();
    Task<ConteudoDTO> GetKeyAsync(ConteudoDTO conteudoDTO);
    Task<ConteudoDTO> Create(InsertConteudoDTO conteudoDTO);
    Task<ConteudoDTO> Update(UpdateConteudoDTO conteudoDTO);
    Task<bool> Delete(int id);
}
