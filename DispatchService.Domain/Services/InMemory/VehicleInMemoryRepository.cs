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

    public bool Add(Vehicle entity)
    {
        try
        {
            _vehicles.Add(entity);
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
            var vehicle = Get(key);
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
    public Vehicle? Get(int key) => _vehicles.FirstOrDefault( v=> v.Id == key);
    public IList<Vehicle> GetAll() => _vehicles;
    public bool Update(Vehicle entity)
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
    public string GetFullInfo(int key)
    {
        var v = Get(key);
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
            return info.ToString();
        }
        
        return "Транспорт не найден";
        
    }

}
