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
            info.AppendLine($"ID: {v.Id}");
            info.AppendLine($"Гос. номер: {v.LicensePlate ?? "не указан"}");
            info.AppendLine($"Тип транспорта: {v.GetVehicleTypeName()}");
            info.AppendLine($"Год выпуска: {v.YearOfManufacture?.ToString() ?? "не указан"}");
            var vModel = _vehicleModels.FirstOrDefault(m => m.Id == v.VehicleModelId);
            if (vModel != null)
            {
                
                info.AppendLine("Модель");
                info.AppendLine($"Название: {vModel.ModelName}");
                info.AppendLine($"Низкопольный: {(vModel.IsLowFloor ? "да" : "нет")}");
                info.AppendLine($"Вместимость: {vModel.MaxCapacity} чел.");
            }
            else
            {
                info.AppendLine("Информация о модели отсутствует");
            }
            return info.ToString();
        }
        
        return "Транспорт не найден";
        
    }

}
