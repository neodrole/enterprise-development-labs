using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatchService.Domain.Model;
using DispatchService.Domain.Services;
using DispatchService.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace DispatchService.Infrastructure.EfCore.Services;
public class VehicleEfCoreRepository(DispatchServiceDbContext context) : IVehicleRepository
{
    private readonly DbSet<Vehicle> _vehicles = context.Vehicles;

    public async Task<Vehicle?> Add(Vehicle entity)
    {
        var result = await _vehicles.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> Delete(int key)
    {
        var entity = await _vehicles.FirstOrDefaultAsync(e => e.Id == key);
        if (entity == null)
            return false;
        _vehicles.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<Vehicle?> Get(int key) =>
        await _vehicles.FirstOrDefaultAsync(e => e.Id == key);

    public async Task<IList<Vehicle>> GetAll() =>
        await _vehicles.ToListAsync();

    public async Task<Vehicle?> Update(Vehicle entity)
    {
        _vehicles.Update(entity);
        await context.SaveChangesAsync();
        return (await Get(entity.Id))!;
    }

    public async Task<string> GetFullInfo(int key)
    {
        var vehicle = await _vehicles
            .Where(v => v.Id == key)
            .Select(v => new
            {
                Vehicle = v,
                Model = context.VehicleModels.FirstOrDefault(m => m.Id == v.VehicleModelId)
            })
            .FirstOrDefaultAsync();

        if (vehicle == null)
            return "Транспорт не найден";

        var v = vehicle.Vehicle;
        var info = new StringBuilder();
        info.AppendLine($"ID: {v.Id}");
        info.AppendLine($"Гос. номер: {v.LicensePlate ?? "не указан"}");
        info.AppendLine($"Тип транспорта: {v.GetVehicleTypeName()}");
        info.AppendLine($"Год выпуска: {v.YearOfManufacture?.ToString() ?? "не указан"}");

        if (vehicle.Model != null)
        {
            info.AppendLine("Модель");
            info.AppendLine($"Название: {vehicle.Model.ModelName}");
            info.AppendLine($"Низкопольный: {(vehicle.Model.IsLowFloor ? "да" : "нет")}");
            info.AppendLine($"Вместимость: {vehicle.Model.MaxCapacity?.ToString() ?? "не указано"} чел.");
        }
        else
        {
            info.AppendLine("Информация о модели отсутствует");
        }

        return info.ToString();
    }
}