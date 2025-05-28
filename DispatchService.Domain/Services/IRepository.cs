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
    public IList<TEntity> GetAll();
    public TEntity? Get(TKey key);
    public bool Add(TEntity entity);
    public bool Update(TEntity entity);
    public bool Delete(TKey key);
}
