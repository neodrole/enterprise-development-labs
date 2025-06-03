using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatchService.Domain.Services.InMemory;

namespace DispatchService.Domain.Tests;

/// <summary>
///  Класс с юнит-тестами репозитория с ежедневными графиками
/// </summary>
public class DailyScheduleRepositoryTest
{
    /// <summary>
    /// Непараметрический тест метода, выводящего всех водителей, совершивших поездки за заданный период, упорядоченных по ФИО
    /// </summary>
    [Fact]
    public async Task GetDriversByPeriod_Success()
    {
        var repo = new DailyScheduleInMemoryRepository();
        var result = await repo.GetDriversByPeriod(new DateTime(2025, 5, 20), new DateTime(2025, 5, 25));
        Assert.Equal(2, result.Count());
        Assert.Equal("Иванов Иван Иванович", result[0].FullName);
        Assert.Equal("Федоров Иван Васильевич", result[1].FullName);
    }

    /// <summary>
    /// Непараметрический тест метода, выводящего всех водителей, совершивших поездки за заданный период, упорядоченных по ФИО
    /// </summary>
    [Fact]
    public async Task GetDriversByPeriod_NoDrivers() 
    {
        var repo = new DailyScheduleInMemoryRepository();
        var result = await repo.GetDriversByPeriod(new DateTime(2024, 5, 20), new DateTime(2024, 5, 25));
        Assert.Empty(result);
    }

    /// <summary>
    /// Непараметрический тест метода для вывода суммарного времени поездок транспортного средства каждого типа и модели
    /// </summary>
    [Fact]
    public async Task GetTotalTimeByTypeAndModel_Success()
    {
        var repo = new DailyScheduleInMemoryRepository();
        var result = await repo.GetTotalTimeByTypeAndModel();
        
        var busTime = result["Автобус: ЛиАЗ 4292"];
        Assert.Equal(new TimeSpan(6, 0, 0), busTime);
        var trolleybusTime = result["Троллейбус: Адмирал 2022"];
        Assert.Equal(new TimeSpan(20, 0, 0), trolleybusTime); // 20 часов т.к. 2 троллейбусы одной модели, сперва не понял почему не 16
    }

    /// <summary>
    /// Непараметрический тест метода для вывода топ-5 водителей по совершенному количеству поездок
    /// </summary>
    [Fact]
    public async Task GetTop5DriversByRides_Success()
    {
        var repo = new DailyScheduleInMemoryRepository();
        var result = await repo.GetTop5DriversByRides();

        Assert.Equal(5, result.Count);

        Assert.Equal("Иванов Иван Иванович", result[0].Item1);
        Assert.Equal(3, result[0].Item2);
        Assert.Contains(Tuple.Create("Иванов Константин Николаевич", 2), result);
    }

    /// <summary>
    /// Непараметрический тест метода для вывода информации о количестве поездок, среднем времени и максимальном времени поездки для каждого водителя
    /// </summary>
    [Fact]
    public async Task GetDriversRidesInfo_Success()
    {
        var repo = new DailyScheduleInMemoryRepository();
        var result = await repo.GetDriversRidesInfo();

        Assert.Equal(6, result.Count);

        var driver1 = result.First(d => d.FullName == "Иванов Иван Иванович");
        Assert.Equal(3, driver1.RideCount);
        Assert.Equal(new TimeSpan(2, 0, 0), driver1.AverageDuration);
        Assert.Equal(new TimeSpan(2,0,0), driver1.MaxDuration);

        var driver3 = result.First(d => d.FullName == "Петров Дмитрий Иванович");
        Assert.Equal(1, driver3.RideCount);
        Assert.Equal(new TimeSpan(8, 0, 0), driver3.AverageDuration);
        Assert.Equal(new TimeSpan(8, 0, 0), driver3.MaxDuration);
    }

    /// <summary>
    /// Непараметрический тест метода для вывода информации о транспортных средствах, совершивших максимальное число поездок за указанный период
    /// </summary>
    [Fact]
    public async Task GetVehiclesWithMaxRides_Success()
    {
        var repo = new DailyScheduleInMemoryRepository();
        var result = await repo.GetVehiclesWithMaxRides(new DateTime(2025, 5, 1), new DateTime(2025, 5, 31));

        Assert.Equal(2, result.Count);
    }

    /// <summary>
    /// Непараметрический тест метода для вывода информации о транспортных средствах, совершивших максимальное число поездок за указанный период
    /// </summary>
    [Fact]
    public async Task GetVehiclesWithMaxRides_NoVehicles()
    {
        var repo = new DailyScheduleInMemoryRepository();
        var result = await repo.GetVehiclesWithMaxRides(new DateTime(2024, 5, 1), new DateTime(2024, 5, 31));

        Assert.Empty(result);
    }
}
