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
    public Task<VehicleModel> Add(VehicleModel entity)
    {
        try
        {
            _vehicleModels.Add(entity);
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
            var vehicleModel = await Get(key);
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
    public async Task<VehicleModel> Update(VehicleModel entity)
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
    public Task<VehicleModel?> Get(int key) => Task.FromResult(_vehicleModels.FirstOrDefault(v => v.Id == key));
    public Task<IList<VehicleModel>> GetAll() => Task.FromResult((IList<VehicleModel>)_vehicleModels);
}
