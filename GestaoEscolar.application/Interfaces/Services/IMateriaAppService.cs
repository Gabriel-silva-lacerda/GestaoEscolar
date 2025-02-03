using GestaoEscolar.domain.DTOs.Conteudo;
using GestaoEscolar.domain.DTOs.Materia;
using System.Linq.Expressions;

namespace GestaoEscolar.domain.Interfaces.Services;

public interface IMateriaAppService
{
    Task<IEnumerable<MateriaDTO>> GetAllAsync();
    Task<MateriaDTO> GetKeyAsync(MateriaDTO materiaDTO);
    Task<MateriaDTO> Create(InsertMateriaDTO materiaDTO);
    Task<MateriaDTO> Update(UpdateMateriaDTO materiaDTO);
    Task<bool> Delete(int id);
}
