using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatchService.Application.Contracts.Driver;
using DispatchService.Application.Contracts.Vehicle;

namespace DispatchService.Application.Contracts;

/// <summary>
/// Интерфейс для службы, выполняющей аналитические запросы согласно бизнес-логике приложения
/// </summary>
public interface IAnalyticsService
{
    /// <summary>
    /// Метод для вывода всех водителей, совершивших поездки за заданный период, упорядоченный по ФИО
    /// </summary>
    /// <returns>Список водителей, упорядоченный по ФИО</returns>
    public Task<IList<DriverDto>> GetDriversByPeriod(DateTime start, DateTime end);

    /// <summary>
    /// Метод для вывода суммарного времени поездок транспортного средства каждого типа и модели
    /// </summary>
    /// <returns>Словарь с типом транспорта, моделью и суммарным временем поездок</returns>
    public Task<Dictionary<string, TimeSpan>> GetTotalTimeByTypeAndModel();

    /// <summary>
    /// Метод для вывода топ-5 водителей по совершенному количеству поездок
    /// </summary>
    /// <returns>Список кортежей с ФИО водителя и количеством совершенных поездок</returns>
    public Task<IList<Tuple<string, int>>> GetTop5DriversByRides();

    /// <summary>
    /// Метод для вывода информации о количестве поездок, среднем времени и максимальном времени поездки для каждого водителя
    /// </summary>
    /// <returns>Список с информацией о поездках для каждого водител</returns>
    public Task<IList<DriverRideInfoDto>> GetDriversRidesInfo();

    /// <summary>
    /// Метод для вывода информации о транспортных средствах, совершивших максимальное число поездок за указанный период
    /// </summary>
    /// <returns>Список транспортных средств</returns>
    public Task<IList<VehicleDto>> GetVehiclesWithMaxRides(DateTime start, DateTime end);
}

public record DriverRideInfoDto(string FullName, int RideCount, TimeSpan AverageDuration, TimeSpan MaxDuration);