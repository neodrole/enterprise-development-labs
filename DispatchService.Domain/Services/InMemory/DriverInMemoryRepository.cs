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
    public bool Add(Driver entity)
    {
        try
        {
            _drivers.Add(entity);
        }
        catch
        {
            return false;
        }
        return true;
    }
    public bool Delete(int key)
    {
        try
        {
            var driver = Get(key);
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
    public bool Update(Driver entity)
    {
        try
        {
            Delete(entity.Id);
            Add(entity);
        }
        catch
        {
            return false;
        }
        return true;
    }
    public Driver? Get(int key) => _drivers.FirstOrDefault(d => d.Id == key);
    public IList<Driver> GetAll() => _drivers;
}
