
using System.Linq.Expressions;
using GestaoEscolar.domain.DTOs.Conteudo;
using GestaoEscolar.domain.Interfaces.Services;

public class ConteudoService : IConteudoService
{
    public Task<ConteudoDTO> Create(InsertConteudoDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ConteudoDTO>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ConteudoDTO> GetKeyAsync(ConteudoDTO conteudoDTO)
    {
        throw new NotImplementedException();
    }

    public Task<ConteudoDTO> Update(UpdateConteudoDTO entity)
    {
        throw new NotImplementedException();
    }
}
