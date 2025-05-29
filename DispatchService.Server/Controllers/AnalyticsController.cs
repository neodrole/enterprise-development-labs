using DispatchService.Application.Contracts;
using DispatchService.Application.Contracts.Driver;
using DispatchService.Application.Contracts.Vehicle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace DispatchService.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController(IAnalyticsService service, IVehicleService vehicleService) : ControllerBase
{
    [HttpGet("DriversByPeriod")]
    [ProducesResponseType(200)]
    public ActionResult<List<DriverDto>> GetDriversByPeriod(
        [FromQuery, Required] DateTime start, 
        [FromQuery, Required] DateTime end)
    {
        var result = service.GetDriversByPeriod(start, end);
        return Ok(result);
    }

    [HttpGet("TotalTimeByTypeAndModel")]
    [ProducesResponseType(200)]
    public ActionResult<Dictionary<string, int>> GetTotalTimeByTypeAndModel() => Ok(service.GetTotalTimeByTypeAndModel());

    [HttpGet("Top5DriversByRides")]
    [ProducesResponseType(200)]
    public ActionResult<List<Tuple<string, int>>> GetTop5DriversByRides() => Ok(service.GetTop5DriversByRides());

    [HttpGet("DriversRidesInfo")]
    [ProducesResponseType(200)]
    public ActionResult<List<DriverRideInfoDto>> GetDriversRidesInfo() => Ok(service.GetDriversRidesInfo());

    [HttpGet("VehiclesWithMaxRides")]
    [ProducesResponseType(200)]
    public ActionResult<List<VehicleDto>> GetVehiclesWithMaxRides(
        [FromQuery, Required] DateTime start,
        [FromQuery, Required] DateTime end)
    {
        var result = service.GetVehiclesWithMaxRides(start, end);
        return Ok(result);
    }
    //наверное, стоило в какой-то момент подумать головой и не следовать примеру
    //сделать отдельный AnalyticsService 
    //но уже не отступлю
    [HttpGet("VehicleFullInfo/{id}")]
    [ProducesResponseType(200)]
    public ActionResult<string> GetFullInfo(int id) => Ok(vehicleService.GetFullInfo(id));
}
