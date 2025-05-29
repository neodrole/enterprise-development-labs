using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatchService.Application.Contracts.Driver;
using DispatchService.Application.Contracts.Vehicle;
namespace DispatchService.Application.Contracts;
public interface IAnalyticsService
{
    
    public IList<DriverDto> GetDriversByPeriod(DateTime start, DateTime end);
    public Dictionary<string, TimeSpan> GetTotalTimeByTypeAndModel();
    public IList<Tuple<string, int>> GetTop5DriversByRides();
    public IList<DriverRideInfoDto> GetDriversRidesInfo();
    public IList<VehicleDto> GetVehiclesWithMaxRides(DateTime start, DateTime end);
}

public record DriverRideInfoDto(string FullName, int RideCount, TimeSpan AverageDuration, TimeSpan MaxDuration);