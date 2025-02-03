
using System.Linq.Expressions;
using GestaoEscolar.domain.DTOs.Professor;
using GestaoEscolar.domain.Interfaces.Services;

public class ProfessorService : IProfessorService
{
    public Task<ProfessorDTO> Create(InsertProfessorDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProfessorDTO>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProfessorDTO> GetKeyAsync(ProfessorDTO professorDTO)
    {
        throw new NotImplementedException();
    }

    public Task<ProfessorDTO> Update(UpdateProfessorDTO entity)
    {
        throw new NotImplementedException();
    }
}
