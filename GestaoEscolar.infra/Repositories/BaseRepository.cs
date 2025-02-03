using System.Linq.Expressions;
using GestaoEscolar.application.Common;
using GestaoEscolar.infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar.domain.Interfaces.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public virtual async Task<ServiceResult<IEnumerable<T>>> GetAllAsync()
    {
        try
        {
            var result = await _dbSet.ToListAsync();
            return ServiceResult<IEnumerable<T>>.SuccessResult(result);
        }
        catch (Exception ex)
        {
            return ServiceResult<IEnumerable<T>>.FailureResult(new[] { ex.Message });
        }
    }

    public async Task<T> GetKeyAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<ServiceResult<T>> CreateAsync(T entity)
    {
        try
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return ServiceResult<T>.SuccessResult(entity);
        }
        catch (Exception ex)
        {
            return ServiceResult<T>.FailureResult(new[] { ex.Message });
        }
    }

    public async Task<IEnumerable<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.ToListAsync();
    }

    public async Task<T> GetByIdWithIncludesAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(predicate);
    }

    public async Task<IEnumerable<T>> GetByAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.AnyAsync(predicate);
    }
}
