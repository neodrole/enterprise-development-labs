using DispatchService.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Domain.Services;
public class DriverRideInfo
{
    public string FullName { get; set; } = string.Empty;
    public int RideCount { get; set; }
    public TimeSpan AverageDuration { get; set; }
    public TimeSpan MaxDuration { get; set; }
}
public interface IDailyScheduleRepository : IRepository<DailySchedule, int>
{
    public Task<IList<Driver>> GetDriversByPeriod(DateTime start, DateTime end);
    public Task<Dictionary<string, TimeSpan>> GetTotalTimeByTypeAndModel();
    public Task<IList<Tuple<string, int>>> GetTop5DriversByRides();
    public Task<IList<DriverRideInfo>> GetDriversRidesInfo();
    public Task<IList<Vehicle>> GetVehiclesWithMaxRides(DateTime start, DateTime end);
}
