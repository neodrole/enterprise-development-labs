using DispatchService.Application.Contracts;
using DispatchService.Application.Contracts.Driver;
using DispatchService.Application.Contracts.Vehicle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;


namespace DispatchService.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController(IAnalyticsService service, IVehicleService vehicleService) : ControllerBase
{
    [HttpGet("DriversByPeriod")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<List<DriverDto>>> GetDriversByPeriod(
        [FromQuery, Required] DateTime start, 
        [FromQuery, Required] DateTime end)
    {
        return Ok( await service.GetDriversByPeriod(start, end));        
    }

    [HttpGet("TotalTimeByTypeAndModel")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<Dictionary<string, int>>> GetTotalTimeByTypeAndModel() => Ok(await service.GetTotalTimeByTypeAndModel());

    [HttpGet("Top5DriversByRides")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<List<Tuple<string, int>>>> GetTop5DriversByRides() => Ok(await service.GetTop5DriversByRides());

    [HttpGet("DriversRidesInfo")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<List<DriverRideInfoDto>>> GetDriversRidesInfo() => Ok(await service.GetDriversRidesInfo());

    [HttpGet("VehiclesWithMaxRides")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<List<VehicleDto>>> GetVehiclesWithMaxRides(
        [FromQuery, Required] DateTime start,
        [FromQuery, Required] DateTime end)
    {
        return Ok(await service.GetVehiclesWithMaxRides(start, end));
    }
    //наверное, стоило в какой-то момент подумать головой и не следовать примеру
    //сделать отдельный AnalyticsService 
    //но уже не отступлю
    [HttpGet("VehicleFullInfo/{id}")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<string>> GetFullInfo(int id) => Ok(await vehicleService.GetFullInfo(id));
}
