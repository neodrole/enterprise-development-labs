using DispatchService.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Domain.Services;

/// <summary>
/// Наследник обобщенного интерфейса для ежедневных графиков с дополнительной функциональностью 
/// </summary>
public interface IDailyScheduleRepository : IRepository<DailySchedule, int>
{
    /// <summary>
    /// Метод для вывода всех водителей, совершивших поездки за заданный период, упорядоченный по ФИО
    /// </summary>
    /// <returns>Список водителей, упорядоченный по ФИО</returns>
    public Task<IList<Driver>> GetDriversByPeriod(DateTime start, DateTime end);

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
    public Task<IList<DriverRideInfo>> GetDriversRidesInfo();

    /// <summary>
    /// Метод для вывода информации о транспортных средствах, совершивших максимальное число поездок за указанный период
    /// </summary>
    /// <returns>Список транспортных средств</returns>
    public Task<IList<Vehicle>> GetVehiclesWithMaxRides(DateTime start, DateTime end);
}
