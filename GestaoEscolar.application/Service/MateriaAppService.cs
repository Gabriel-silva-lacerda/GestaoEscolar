
using System.Linq.Expressions;
using GestaoEscolar.domain.DTOs.Materia;
using GestaoEscolar.domain.Interfaces.Services;

public class MateriaAppService : IMateriaAppService
{
    public Task<MateriaDTO> Create(InsertMateriaDTO materiaDTO)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MateriaDTO>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<MateriaDTO> GetKeyAsync(MateriaDTO materiaDTO)
    {
        throw new NotImplementedException();
    }

    public Task<MateriaDTO> Update(UpdateMateriaDTO materiaDTO)
    {
        throw new NotImplementedException();
    }
}
