using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Application.Contracts;

public interface ICrudService<TDto, TCreateUpdateDto, TKey>
    where TDto: class
    where TCreateUpdateDto : class
    where TKey : struct
{
    public bool Create(TCreateUpdateDto newDto);
    public bool Update(TKey key, TCreateUpdateDto newDto);
    public bool Delete(TKey id);
    public IList<TDto> GetList();
    public TDto? GetById(TKey id);
}
