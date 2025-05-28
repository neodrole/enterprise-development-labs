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
    public IList<Driver> GetDriversByPeriod(DateTime start, DateTime end);
    public Dictionary<string, TimeSpan> GetTotalTimeByTypeAndModel();
    public IList<Tuple<string, int>> GetTop5DriversByRides();
    public IList<DriverRideInfo> GetDriversRidesInfo();
    public IList<Vehicle> GetVehiclesWithMaxRides(DateTime start, DateTime end);
}
