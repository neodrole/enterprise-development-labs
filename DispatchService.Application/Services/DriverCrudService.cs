using AutoMapper;
using DispatchService.Application.Contracts;
using DispatchService.Application.Contracts.Driver;
using DispatchService.Domain.Services;
using DispatchService.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Application.Services;
public class DriverCrudService(IRepository<Driver, int> repository, IMapper mapper) : ICrudService<DriverDto, DriverCreateUpdateDto, int>
{
    public bool Create(DriverCreateUpdateDto newDto)
    {
        var newDriver = mapper.Map<Driver>(newDto);
        newDriver.Id = repository.GetAll().Max(x => x.Id) + 1;
        var result = repository.Add(newDriver);
        return result;
    }

    public bool Delete(int id) => repository.Delete(id);
    public DriverDto? GetById(int id)
    {
        var driver = repository.Get(id);
        return mapper.Map<DriverDto>(driver);
    }

    public IList<DriverDto> GetList() => mapper.Map<List<DriverDto>>(repository.GetAll());

    public bool Update(int key, DriverCreateUpdateDto newDto)
    {
        var oldDriver = repository.Get(key);
        var newDriver = mapper.Map<Driver>(newDto);
        newDriver.Id = key;
        var result = repository.Update(newDriver);
        return result;
    }
}