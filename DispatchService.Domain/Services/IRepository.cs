using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Domain.Services;
public interface IRepository<TEntity, TKey>
    where TEntity : class
    where TKey : struct
{
    public Task<IList<TEntity>> GetAll();
    public Task<TEntity?> Get(TKey key);
    public Task<TEntity> Add(TEntity entity);
    public Task<TEntity> Update(TEntity entity);
    public Task<bool> Delete(TKey key);
}
