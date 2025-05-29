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
public class DailyScheduleEfCoreRepository(DispatchServiceDbContext context) : IDailyScheduleRepository
{
    private readonly DbSet<DailySchedule> _dailySchedules = context.DailySchedules;
    public async Task<DailySchedule> Add(DailySchedule entity)
    {
        var result = await _dailySchedules.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> Delete(int key)
    {
        var entity = await _dailySchedules.FirstOrDefaultAsync(e => e.Id == key);
        if (entity == null)
            return false;
        _dailySchedules.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<DailySchedule>? Get(int key) =>
        await _dailySchedules.FirstOrDefaultAsync(e => e.Id == key);

    public async Task<IList<DailySchedule>> GetAll() =>
        await _dailySchedules.ToListAsync();

    public async Task<DailySchedule> Update(DailySchedule entity)
    {
        _dailySchedules.Update(entity);
        await context.SaveChangesAsync();
        return (await Get(entity.Id))!;

    }

    public async Task<IList<Driver>> GetDriversByPeriod(DateTime start, DateTime end)
    {
        return await _dailySchedules
            .Where(ds => 
                ds.StartTime != null &&
                ds.EndTime != null &&
                ds.StartTime >= start &&
                ds.EndTime <= end)
            .Select(ds => ds.Driver)
            .Distinct()
            .ToListAsync();
    }
/*
Taa
⣿⣿⣿⣿⣿⣿⣿⠿⠿⢛⣋⣙⣋⣩⣭⣭⣭⣭⣍⣉⡛⠻⢿⣿⣿⣿⣿ 
⣿⣿⣿⠟⣋⣥⣴⣾⣿⣿⣿⡆⣿⣿⣿⣿⣿⣿⡿⠟⠛⠗⢦⡙⢿⣿⣿ 
⣿⡟⡡⠾⠛⠻⢿⣿⣿⣿⡿⠃⣿⡿⣿⠿⠛⠉⠠⠴⢶⡜⣦⡀⡈⢿⣿ 
⡿⢀⣰⡏⣼⠋⠁⢲⡌⢤⣠⣾⣷⡄⢄⠠⡶⣾⡀⠀⣸⡷⢸⡷⢹⠈⣿ 
⡇⢘⢿⣇⢻⣤⣠⡼⢃⣤⣾⣿⣿⣿⢌⣷⣅⡘⠻⠿⢛⣡⣿⠀⣾⢠⣿ 
⣷⠸⣮⣿⣷⣨⣥⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⢁⡼⠃⣼⣿ 
⣿⡆⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢃⡞⣱⠆⣿⣿ 
⣿⣿⠈⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠁⣼⢸⡿⢸⣿⣿ 
⣿⣿⡇⢹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⢿⡌⠃⣿⣿⣿ 
⣿⣿⣿⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢋⣿⠙⣷⢸⣷⠀⣿⣿⣿ 
⣿⣿⣿⡇⢻⣿⣿⣿⡿⠿⢿⣿⣿⣿⠟⠋⣡⡈⠻⣇⢹⣿⣿⢠⣿⣿⣿ 
⣿⣿⣿⣿⠘⣿⣿⣿⣿⣯⣽⣉⣿⣟⣛⠷⠙⢿⣷⣌⠀⢿⡇⣼⣿⣿⣿ 
⣿⣿⣿⡿⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣤⡙⢿⢗⣀⣁⠈⢻⣿⣿ 
⣿⡿⢋⣴⣿⣎⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⡉⣯⣿⣷⠆⠙⢿ 
⣏⠀⠈⠧⠡⠉⠙⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠃⠉⢉⣁⣀⣀⣾
*/
    public async Task<Dictionary<string, TimeSpan>> GetTotalTimeByTypeAndModel()
    {
        var schedules = await _dailySchedules
            .Where(ds => ds.StartTime != null && ds.EndTime != null)
            .Include(ds => ds.Vehicle) // Загружаем связанное ТС
            .AsNoTracking()
            .ToListAsync();

        var vehicleModels = await context.VehicleModels
            .AsNoTracking()
            .ToListAsync();

        var modelDict = vehicleModels.ToDictionary(m => m.Id, m => m);

        var result = schedules
            .Where(ds => ds.Vehicle != null && ds.Vehicle.VehicleModelId.HasValue)
            .GroupBy(ds => new
            {
                VehicleType = ds.Vehicle.VehicleType,
                ModelId = ds.Vehicle.VehicleModelId.Value
            })
            .Select(g =>
            {
                var model = modelDict.GetValueOrDefault(g.Key.ModelId);
                return new
                {
                    Key = new
                    {
                        VehicleType = g.Key.VehicleType,
                        ModelName = model?.ModelName ?? "Неизвестная модель"
                    },
                    TotalMinutes = g.Sum(ds =>
                        (ds.EndTime!.Value - ds.StartTime!.Value).TotalMinutes)
                };
            })
            .GroupBy(x => x.Key)
            .Select(g => new
            {
                Key = g.Key,
                TotalMinutes = g.Sum(x => x.TotalMinutes)
            })
            .ToList();

        var vehicleTypeNames = new Dictionary<Vehicle.VehicleTypes, string>
    {
        { Vehicle.VehicleTypes.Bus, "Автобус" },
        { Vehicle.VehicleTypes.Trolleybus, "Троллейбус" },
        { Vehicle.VehicleTypes.Tram, "Трамвай" }
    };

        return result.ToDictionary(
            x => $"{vehicleTypeNames.GetValueOrDefault(x.Key.VehicleType ?? Vehicle.VehicleTypes.Bus, "не указан")}: {x.Key.ModelName}",
            x => TimeSpan.FromMinutes(x.TotalMinutes)
        );
    }

    public async Task<IList<Tuple<string, int>>> GetTop5DriversByRides()
    {
        var query = _dailySchedules
            .Where(ds => ds.Driver != null)
            .GroupBy(ds => new {
                ds.Driver.Id,
                ds.Driver.LastName,
                ds.Driver.FirstName,
                ds.Driver.Patronymic
            })
            .Select(g => new
            {
                LastName = g.Key.LastName ?? "",
                FirstName = g.Key.FirstName ?? "",
                Patronymic = g.Key.Patronymic ?? "",
                Count = g.Count()
            })
            .OrderByDescending(x => x.Count)
            .Take(5);

        var result = await query.ToListAsync();

        return result
            .Select(x => Tuple.Create(
                $"{x.LastName} {x.FirstName} {x.Patronymic}".Trim(),
                x.Count
            ))
            .ToList();
    }

    public async Task<IList<DriverRideInfo>> GetDriversRidesInfo()
    {
        var data = await _dailySchedules
            .Where(ds =>
                ds.Driver != null &&
                ds.StartTime != null &&
                ds.EndTime != null)
            .Select(ds => new
            {
                DriverId = ds.Driver.Id,
                ds.Driver.LastName,
                ds.Driver.FirstName,
                ds.Driver.Patronymic,
                ds.StartTime,
                ds.EndTime
            })
            .AsNoTracking()
            .ToListAsync();

        var result = data
            .GroupBy(ds => new
            {
                ds.DriverId,
                ds.LastName,
                ds.FirstName,
                ds.Patronymic
            })
            .Select(g =>
            {
                var durations = g
                    .Where(x => x.EndTime > x.StartTime)
                    .Select(x => (x.EndTime - x.StartTime).Value)
                    .ToList();

                return new DriverRideInfo
                {
                    FullName = $"{g.Key.LastName} {g.Key.FirstName} {g.Key.Patronymic}".Trim(),
                    RideCount = durations.Count,
                    AverageDuration = durations.Any() ?
                        TimeSpan.FromMinutes(durations.Average(ts => ts.TotalMinutes)) :
                        TimeSpan.Zero,
                    MaxDuration = durations.Any() ?
                        durations.Max() :
                        TimeSpan.Zero
                };
            })
            .ToList();

        return result;
    }

    public async Task<IList<Vehicle>> GetVehiclesWithMaxRides(DateTime start, DateTime end)
    {
        var vehicleRideCounts = await _dailySchedules
            .Where(ds =>
                ds.StartTime != null &&
                ds.EndTime != null &&
                ds.StartTime >= start &&
                ds.EndTime <= end)
            .GroupBy(ds => ds.VehicleId)
            .Select(g => new { VehicleId = g.Key, RideCount = g.Count() })
            .ToListAsync();

        if (!vehicleRideCounts.Any())
            return new List<Vehicle>();

        var maxRides = vehicleRideCounts.Max(x => x.RideCount);
        var vehicleIds = vehicleRideCounts
            .Where(x => x.RideCount == maxRides)
            .Select(x => x.VehicleId)
            .ToList();

        return await context.Vehicles
            .Where(v => vehicleIds.Contains(v.Id))
            .ToListAsync();
    }
}
