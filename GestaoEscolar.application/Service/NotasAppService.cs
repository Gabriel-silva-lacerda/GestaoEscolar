
using System.Linq.Expressions;
using GestaoEscolar.domain.DTOs.Notas;
using GestaoEscolar.domain.Interfaces.Services;

public class NotasAppService : INotasAppService
{
    public Task<NotasDTO> Create(InsertNotasDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<NotasDTO>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<NotasDTO> GetKeyAsync(NotasDTO notasDTO)
    {
        throw new NotImplementedException();
    }

    public Task<NotasDTO> Update(UpdateNotasDTO entity)
    {
        throw new NotImplementedException();
    }
}
