using BlazorSozluk.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Application.Interfaces.Repositories;
public interface IGenericRepository<TEntity> where TEntity: BaseEntity
{
    Task<int> AddAsync(TEntity entity);
    int Add(TEntity entity);
    int Add(IEnumerable<TEntity> entities);
    Task<int> AddAsync(IEnumerable<TEntity> entities);


    Task<int> UpdateAsync(TEntity entity);
    int Update(TEntity entity);


    Task<int> DeleteAsync(TEntity entity);
    int Delete(TEntity entity);
    Task<int> DeleteAsync(Guid id);
    int Delete(Guid id);
    bool DeleteRange(Expression<Func<TEntity, bool>> predicate);
    Task<bool> DeleteRangeAsync(Expression<Func<TEntity, bool>> predicate);


    Task<int> AddOrUpdateAsync(TEntity entity);

    int AddOrUpdate(TEntity entity);

    IQueryable<TEntity> AsQueryable();

    Task<List<TEntity>> GetAll(bool noTracking = true);


    Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);

    Task<TEntity> GetByIdAsync(Guid id, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);

    Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);

    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);

    IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);



    Task BulkDeleteById(IEnumerable<Guid> ids);
    Task BulkDelete(Expression<Func<TEntity, bool>> predicate);
    Task BulkDelete(IEnumerable<TEntity> entities);
    Task BulkUpdate(IEnumerable<TEntity> entities);
    Task BulkAdd(IEnumerable<TEntity> entities);
}
