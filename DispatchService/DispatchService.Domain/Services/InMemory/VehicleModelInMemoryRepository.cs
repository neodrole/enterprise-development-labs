using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatchService.Domain.Data;
using DispatchService.Domain.Model;
namespace DispatchService.Domain.Services.InMemory;
public class VehicleModelInMemoryRepository : IRepository<VehicleModel, int>
{
    private List<VehicleModel> _vehicleModels;
    public VehicleModelInMemoryRepository()
    {
        _vehicleModels = DataSeeder.VehicleModels;
    }
    public bool Add(VehicleModel entity)
    {
        try
        {
            _vehicleModels.Add(entity);
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
            var vehicleModel = Get(key);
            if (vehicleModel != null)
            {
                _vehicleModels.Remove(vehicleModel);
            }
        }
        catch
        {
            return false;
        }
        return true;
    }
    public bool Update(VehicleModel entity)
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
    public VehicleModel? Get(int key) => _vehicleModels.FirstOrDefault(v => v.Id == key);
    public IList<VehicleModel> GetAll() => _vehicleModels;
}
