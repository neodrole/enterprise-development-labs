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
    
    public Task<IList<DriverDto>> GetDriversByPeriod(DateTime start, DateTime end);
    public Task<Dictionary<string, TimeSpan>> GetTotalTimeByTypeAndModel();
    public Task<IList<Tuple<string, int>>> GetTop5DriversByRides();
    public Task<IList<DriverRideInfoDto>> GetDriversRidesInfo();
    public Task<IList<VehicleDto>> GetVehiclesWithMaxRides(DateTime start, DateTime end);
}

public record DriverRideInfoDto(string FullName, int RideCount, TimeSpan AverageDuration, TimeSpan MaxDuration);