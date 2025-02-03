using System.Linq.Expressions;
using System.Threading.Tasks;
using GestaoEscolar.application.Common;
using GestaoEscolar.domain.DTOs.Turma;

namespace GestaoEscolar.domain.Interfaces.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task<ServiceResult<IEnumerable<T>>> GetAllAsync();
    Task<T> GetKeyAsync(Expression<Func<T, bool>> predicate);
    Task<ServiceResult<T>> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
    Task<IEnumerable<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes);
    Task<T> GetByIdWithIncludesAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
    Task<IEnumerable<T>> GetByAsync(Expression<Func<T, bool>> predicate);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
}
