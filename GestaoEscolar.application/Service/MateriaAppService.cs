
using GestaoEscolar.Core.Services;
using GestaoEscolar.domain.DTOs.Materia;
using GestaoEscolar.domain.Interfaces.Services;

public class MateriaAppService : IMateriaAppService
{
    private readonly IMateriaService _materiaService;

    public MateriaAppService(IMateriaService materiaService)
    {
        _materiaService = materiaService;
    }
    public async Task<ServiceResult<IEnumerable<MateriaDTO>>> GetAllAsync()
    {
        return await _materiaService.GetAllAsync();
    }

    public async Task<ServiceResult<MateriaDTO>> GetKeyAsync(MateriaDTO materiaDTO)
    {
        return await _materiaService.GetKeyAsync(materiaDTO);
    }
    public async Task<ServiceResult<MateriaDTO>> CreateAsync(InsertMateriaDTO materiaDTO)
    {
        return await _materiaService.CreateAsync(materiaDTO);
    }

    public async Task<ServiceResult<MateriaDTO>> UpdateAsync(UpdateMateriaDTO materiaDTO)
    {
        return await _materiaService.UpdateAsync(materiaDTO);
    }

    public async Task<ServiceResult<MateriaDTO>> DeleteAsync(int id)
    {
        return await _materiaService.DeleteAsync(id);
    }
}
