using DispatchService.Application.Contracts;
using DispatchService.Application.Contracts.Driver;
using DispatchService.Application.Contracts.Vehicle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;


namespace DispatchService.Server.Controllers;

/// <summary>
/// Контроллер для выполнения аналитических запросов
/// </summary>
/// <param name="service">Служба для выполнения аналитических запросов требующих DailySchedule</param>
/// <param name="vehicleService">Служба для выполнения аналитических запросов требующих Vehicle</param>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController(IAnalyticsService service, IVehicleService vehicleService) : ControllerBase
{
    /// <summary>
    /// Получение всех водителей, совершивших поездки за заданный период, упорядоченный по ФИО
    /// </summary>
    /// <param name="start">Начало периода</param>
    /// <param name="end">Конец периода</param>
    /// <returns>Список водителей, упорядоченный по ФИО</returns>
    [HttpGet("DriversByPeriod")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<List<DriverDto>>> GetDriversByPeriod(
        [FromQuery, Required] DateTime start, 
        [FromQuery, Required] DateTime end)
    {
        return Ok( await service.GetDriversByPeriod(start, end));        
    }

    /// <summary>
    /// Получение суммарного времени поездок транспортного средства каждого типа и модели
    /// </summary>
    /// <returns>Словарь с типом транспорта, моделью и суммарным временем поездок</returns>
    [HttpGet("TotalTimeByTypeAndModel")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<Dictionary<string, int>>> GetTotalTimeByTypeAndModel() => Ok(await service.GetTotalTimeByTypeAndModel());

    /// <summary>
    /// Получение топ-5 водителей по совершенному количеству поездок
    /// </summary>
    /// <returns>Список кортежей с ФИО водителя и количеством совершенных поездок</returns>
    [HttpGet("Top5DriversByRides")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<List<Tuple<string, int>>>> GetTop5DriversByRides() => Ok(await service.GetTop5DriversByRides());

    /// <summary>
    /// Получение информации о количестве поездок, среднем времени и максимальном времени поездки для каждого водителя
    /// </summary>
    /// <returns>Список с информацией о поездках для каждого водител</returns>
    [HttpGet("DriversRidesInfo")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<List<DriverRideInfoDto>>> GetDriversRidesInfo() => Ok(await service.GetDriversRidesInfo());

    /// <summary>
    /// Получение информации о транспортных средствах, совершивших максимальное число поездок за указанный период
    /// </summary>
    /// <param name="start">Начало периода</param>
    /// <param name="end">Конец периода</param>
    /// <returns>Список транспортных средств</returns>
    [HttpGet("VehiclesWithMaxRides")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<List<VehicleDto>>> GetVehiclesWithMaxRides(
        [FromQuery, Required] DateTime start,
        [FromQuery, Required] DateTime end)
    {
        return Ok(await service.GetVehiclesWithMaxRides(start, end));
    }

    /// <summary>
    /// Получение информации о транспортном средстве
    /// </summary>
    /// <param name="id">Идентификатор транспортного средства</param>
    /// <returns>Строка с информацией о транспортном средстве </returns>
    [HttpGet("VehicleFullInfo/{id}")]
    [ProducesResponseType(200)]
    public async Task<ActionResult<string>> GetFullInfo(int id) => Ok(await vehicleService.GetFullInfo(id));
}
