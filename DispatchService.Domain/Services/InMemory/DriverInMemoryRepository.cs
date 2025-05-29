using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatchService.Domain.Data;
using DispatchService.Domain.Model;
namespace DispatchService.Domain.Services.InMemory;
public class DriverInMemoryRepository : IRepository<Driver, int>
{
    private List<Driver> _drivers;
    public DriverInMemoryRepository()
    {
        _drivers = DataSeeder.Drivers;
    }
    public Task<Driver> Add(Driver entity)
    {
        try
        {
            _drivers.Add(entity);
        }
        catch
        {
            return null;
        }
        return Task.FromResult(entity);
    }
    public async Task<bool> Delete(int key)
    {
        try
        {
            var driver = await Get(key);
            if (driver != null)
            {
                _drivers.Remove(driver);
            }
        }
        catch
        {
            return false;
        }
        return true;
    }
    public async Task<Driver> Update(Driver entity)
    {
        try
        {
            await Delete(entity.Id);
            await Add(entity);
        }
        catch
        {
            return null;
        }
        return entity;
    }
    public Task<Driver?> Get(int key) => Task.FromResult(_drivers.FirstOrDefault(d => d.Id == key));
    public Task<IList<Driver>> GetAll() => Task.FromResult((IList<Driver>)_drivers);
}
