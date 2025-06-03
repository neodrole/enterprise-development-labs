using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatchService.Domain.Data;
using DispatchService.Domain.Model;

namespace DispatchService.Domain.Services.InMemory;

/// <summary>
/// Имплементация репозитория для моделей транспортных средств, которая хранит коллекцию в оперативной памяти 
/// </summary>
public class VehicleModelInMemoryRepository : IRepository<VehicleModel, int>
{
    private List<VehicleModel> _vehicleModels;

    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public VehicleModelInMemoryRepository()
    {
        _vehicleModels = DataSeeder.VehicleModels;
    }

    /// <inheritdoc/>
    public Task<VehicleModel?> Add(VehicleModel entity)
    {
        try
        {
            _vehicleModels.Add(entity);
        }
        catch
        {
            return Task.FromResult<VehicleModel?>(null);
        }
        return Task.FromResult<VehicleModel?>(entity);
    }

    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public async Task<VehicleModel?> Update(VehicleModel entity)
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

    /// <inheritdoc/>
    public Task<VehicleModel?> Get(int key) => Task.FromResult(_vehicleModels.FirstOrDefault(v => v.Id == key));

    /// <inheritdoc/>
    public Task<IList<VehicleModel>> GetAll() => Task.FromResult((IList<VehicleModel>)_vehicleModels);
}
