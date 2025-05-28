using DispatchService.Domain.Data;
using DispatchService.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Domain.Services.InMemory;
public class DailyScheduleInMemoryRepository : IDailyScheduleRepository
{
    private List<DailySchedule> _dailySchedules;
    private List<VehicleModel> _vehicleModels;
    private List<Vehicle> _vehicles;
    private List<Driver> _drivers;
    public DailyScheduleInMemoryRepository()
    {
        _dailySchedules = DataSeeder.DailySchedules;
        _vehicleModels = DataSeeder.VehicleModels;
        _vehicles = DataSeeder.Vehicles;
        _drivers = DataSeeder.Drivers;

        foreach (var ds in _dailySchedules)
        {
            ds.Driver = _drivers.FirstOrDefault(a => a.Id == ds.DriverId);
            ds.Vehicle = _vehicles.FirstOrDefault(a => a.Id == ds.VehicleId);
        }
    }
    public bool Add(DailySchedule entity)
    {
        try
        {
            _dailySchedules.Add(entity);
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
            var dailySchedule = Get(key);
            if (dailySchedule != null)
            {
                _dailySchedules.Remove(dailySchedule);
            }
        }
        catch
        {
            return false;
        }
        return true;
    }
    public bool Update(DailySchedule entity)
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
    public DailySchedule? Get(int key) => _dailySchedules.FirstOrDefault(d => d.Id == key);
    public IList<DailySchedule> GetAll() => _dailySchedules;
    public IList<Driver> GetDriversByPeriod(DateTime start, DateTime end)
    {
        return _dailySchedules
            .Where(ds =>
                ds.StartTime != null &&
                ds.EndTime != null &&
                ds.StartTime >= start && 
                ds.EndTime <= end &&  
                ds.Driver != null)
            .Select(ds => ds.Driver!)
            .DistinctBy(d => d.Id)  
            .OrderBy(d => d.FullName)
            .ToList();
    }
    public Dictionary<string, TimeSpan> GetTotalTimeByTypeAndModel()
    {
        var totalTime = new Dictionary<string, TimeSpan>();
        foreach (var schedule in _dailySchedules)
        {
            if (schedule.StartTime == null || schedule.EndTime == null) continue;

            var vehicle = _vehicles.FirstOrDefault(v => v.Id == schedule.VehicleId);
            if (vehicle == null) continue;

            var vehicleModel = _vehicleModels.FirstOrDefault(m => m.Id == vehicle.VehicleModelId);
            if (vehicleModel == null) continue;
            TimeSpan duration = schedule.EndTime.Value - schedule.StartTime.Value;
            var vehicleTypeName = vehicle.GetVehicleTypeName();
            var key = $"{vehicleTypeName}: {vehicleModel.ModelName}";
            if (totalTime.ContainsKey(key))
            {
                totalTime[key] += duration;
            }
            else
            {
                totalTime[key] = duration;
            }
        }
        return totalTime;

    }
    public IList<Tuple<string, int>> GetTop5DriversByRides()
    {
        var driverRideCounts = _dailySchedules
            .Where(ds => ds.Driver != null)
            .GroupBy(ds => ds.Driver!.Id)
            .Select(g => new
            {
                DriverId = g.Key,
                RideCount = g.Count(),
                Driver = g.First().Driver
            })
            .ToList();

        
        var topDrivers = driverRideCounts
            .OrderByDescending(x => x.RideCount)
            .Take(5)
            .ToList();

        
        var result = new List<Tuple<string, int>>();

        foreach (var driverInfo in topDrivers)
        {
            
            var fullName = driverInfo.Driver.FullName;
            result.Add(Tuple.Create(fullName, driverInfo.RideCount));
        }

        return result;
    }

    public IList<DriverRideInfo> GetDriversRidesInfo()
    {
        
        return _dailySchedules
            .Where(ds => ds.Driver != null && ds.StartTime != null && ds.EndTime != null)
            .GroupBy(ds => ds.Driver!.Id)
            .Select(g =>
            {
                var driver = g.First().Driver!;
                var durations = g.Select(ds => ds.EndTime!.Value - ds.StartTime!.Value).ToList();

                return new DriverRideInfo
                {
                    FullName = driver.FullName,
                    RideCount = durations.Count,
                    AverageDuration = TimeSpan.FromMinutes(
                        durations.Average(ts => ts.TotalMinutes) 
                    ),
                    MaxDuration = durations.Max()
                };
            })
            .ToList();
    }
    public IList<Vehicle> GetVehiclesWithMaxRides(DateTime start, DateTime end)
    {
        var periodSchedules = _dailySchedules
            .Where(ds =>
                ds.StartTime != null &&
                ds.EndTime != null &&
                ds.StartTime <= end &&
                ds.EndTime >= start)
            .ToList();

        var vehicleRideCounts = periodSchedules
            .GroupBy(ds => ds.VehicleId)
            .Select(g => new
            {
                VehicleId = g.Key,
                RideCount = g.Count()
            })
            .ToList();
        
        if (!vehicleRideCounts.Any())
            return new List<Vehicle>();

        var maxRides = vehicleRideCounts.Max(x => x.RideCount);
        var maxVehicleIds = vehicleRideCounts
            .Where(x => x.RideCount == maxRides)
            .Select(x => x.VehicleId)
            .ToList();

        return _vehicles
            .Where(v => maxVehicleIds.Contains(v.Id))
            .ToList();
    }
}
