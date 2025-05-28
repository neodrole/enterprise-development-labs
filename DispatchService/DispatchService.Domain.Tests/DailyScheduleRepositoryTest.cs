using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatchService.Domain.Services.InMemory;
namespace DispatchService.Domain.Tests;
public class DailyScheduleRepositoryTest
{
    [Fact]
    public void GetDriversByPeriod_Success()
    {
        var repo = new DailyScheduleInMemoryRepository();
        var result = repo.GetDriversByPeriod(new DateTime(2025, 5, 20), new DateTime(2025, 5, 25));
        Assert.Equal(2, result.Count());
        Assert.Equal("Иванов Иван Иванович", result[0].FullName);
        Assert.Equal("Федоров Иван Васильевич", result[1].FullName);
    }
    [Fact]
    public void GetDriversByPeriod_NoDrivers() 
    {
        var repo = new DailyScheduleInMemoryRepository();
        var result = repo.GetDriversByPeriod(new DateTime(2024, 5, 20), new DateTime(2024, 5, 25));
        Assert.Empty(result);
    }

    [Fact]
    public void GetTotalTimeByTypeAndModel_Success()
    {
        var repo = new DailyScheduleInMemoryRepository();
        var result = repo.GetTotalTimeByTypeAndModel();
        
        var busTime = result["Автобус: ЛиАЗ 4292"];
        Assert.Equal(new TimeSpan(6, 0, 0), busTime);
        var trolleybusTime = result["Троллейбус: Адмирал 2022"];
        Assert.Equal(new TimeSpan(20, 0, 0), trolleybusTime); // 20 часов т.к. 2 троллейбусы одной модели, сперва не понял почему не 16
    }

    [Fact]
    public void GetTop5DriversByRides_Success()
    {
        var repo = new DailyScheduleInMemoryRepository();
        var result = repo.GetTop5DriversByRides();

        Assert.Equal(5, result.Count);

        Assert.Equal("Иванов Иван Иванович", result[0].Item1);
        Assert.Equal(3, result[0].Item2);
        Assert.Contains(Tuple.Create("Иванов Константин Николаевич", 2), result);
    }

    [Fact]
    public void GetDriversRidesInfo_Success()
    {
        var repo = new DailyScheduleInMemoryRepository();
        var result = repo.GetDriversRidesInfo();

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

    [Fact]
    public void GetVehiclesWithMaxRides_Success()
    {
        var repo = new DailyScheduleInMemoryRepository();
        var result = repo.GetVehiclesWithMaxRides(new DateTime(2025, 5, 1), new DateTime(2025, 5, 31));

        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void GetVehiclesWithMaxRides_NoVehicles()
    {
        var repo = new DailyScheduleInMemoryRepository();
        var result = repo.GetVehiclesWithMaxRides(new DateTime(2024, 5, 1), new DateTime(2024, 5, 31));

        Assert.Empty(result);
    }
}

/*
public IList<Driver> GetDriversByPeriod(DateTime start, DateTime end);
    public Dictionary<string, TimeSpan> GetTotalTimeByTypeAndModel();
    public IList<Tuple<string, int>> GetTop5DriversByRides();
    public IList<DriverRideInfo> GetDriversRidesInfo();
    public IList<Vehicle> GetVehiclesWithMaxRides(DateTime start, DateTime end);  
  [Fact]
    public void GetFullInfo_Success()
    {
        // наверное нужно было не строку возвращать, иначе это бред какой-то.

        var expected =
            "ID: 2\r\n" +
            "Гос. номер: A123AA63\r\n" +
            "Тип транспорта: Троллейбус\r\n" +
            "Год выпуска: 2022\r\n" +
            "Модель\r\n" +
            "Название: Адмирал 2022\r\n" +
            "Низкопольный: да\r\n" +
            "Вместимость: 100 чел.\r\n";
        var repo = new VehicleInMemoryRepository();
        var result = repo.GetFullInfo(2);
        Assert.Equal(expected, result);
    }
 
 */