using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatchService.Domain.Data;
using DispatchService.Domain.Model;
namespace DispatchService.Domain.Services.InMemory;
public class VehicleInMemoryRepository : IVehicleRepository
{
    private List<Vehicle> _vehicles;
    private List<VehicleModel> _vehicleModels;

    public VehicleInMemoryRepository()
    {
        _vehicles = DataSeeder.Vehicles;
        _vehicleModels = DataSeeder.VehicleModels;
    }

    public Task<Vehicle> Add(Vehicle entity)
    {
        try
        {
            _vehicles.Add(entity);
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
            var vehicle = await Get(key);
            if (vehicle != null)
            {
                _vehicles.Remove(vehicle);
            }
        }
        catch
        {
            return false;
        }
        return true;
    }
    public Task<Vehicle?> Get(int key) => Task.FromResult(_vehicles.FirstOrDefault( v=> v.Id == key));
    public Task<IList<Vehicle>> GetAll() => Task.FromResult((IList<Vehicle>)_vehicles);
    public async Task<Vehicle> Update(Vehicle entity)
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
    public Task<string> GetFullInfo(int key)
    {
        var v = _vehicles.FirstOrDefault(vv => vv.Id == key);
        if (v != null)
        {
            var info = new StringBuilder();
            info.Append($"ID: {v.Id}{Environment.NewLine}");
            info.Append($"Гос. номер: {v.LicensePlate ?? "не указан"}{Environment.NewLine}");
            info.Append($"Тип транспорта: {v.GetVehicleTypeName()}{Environment.NewLine}");
            info.Append($"Год выпуска: {v.YearOfManufacture?.ToString() ?? "не указан"}{Environment.NewLine}");
            var vModel = _vehicleModels.FirstOrDefault(m => m.Id == v.VehicleModelId);
            if (vModel != null)
            {

                info.Append($"Модель{Environment.NewLine}");
                info.Append($"Название: {vModel.ModelName}{Environment.NewLine}");
                info.Append($"Низкопольный: {(vModel.IsLowFloor ? "да" : "нет")}{Environment.NewLine}");
                info.Append($"Вместимость: {vModel.MaxCapacity} чел.{Environment.NewLine}");
            }
            else
            {
                info.Append($"Информация о модели отсутствует{Environment.NewLine}");
            }
            return Task.FromResult(info.ToString());
        }
        
        return Task.FromResult("Транспорт не найден");
        
    }

}
