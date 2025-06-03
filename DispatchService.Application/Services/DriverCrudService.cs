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

/// <summary>
/// Служба слоя приложения для манипуляции над водителями
/// </summary>
/// <param name="repository">Доменная служба для ежедневных графиков</param>
/// <param name="mapper">Автомаппер</param>
public class DriverCrudService(IRepository<Driver, int> repository, IMapper mapper) : ICrudService<DriverDto, DriverCreateUpdateDto, int>
{
    public async Task<DriverDto> Create(DriverCreateUpdateDto newDto)
    {
        var newDriver = mapper.Map<Driver>(newDto);
        newDriver.Id = (await repository.GetAll()).Max(x => x.Id) + 1;
        var res = await repository.Add(newDriver);
        return mapper.Map<DriverDto>(res);
    }

    public async Task<bool> Delete(int id) => await repository.Delete(id);
    public async Task<DriverDto?> GetById(int id)
    {
        var driver = await repository.Get(id);
        return mapper.Map<DriverDto>(driver);
    }

    public async Task<IList<DriverDto>> GetList() => mapper.Map<List<DriverDto>>(await repository.GetAll());

    public async Task<DriverDto> Update(int key, DriverCreateUpdateDto newDto)
    {
        
        var newDriver = mapper.Map<Driver>(newDto);
        await repository.Update(newDriver);
        return mapper.Map<DriverDto>(newDriver);
    }
}