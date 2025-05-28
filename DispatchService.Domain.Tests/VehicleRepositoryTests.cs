namespace DispatchService.Domain.Tests;
using DispatchService.Domain.Services.InMemory;
using System.Numerics;
using System.Text;

public class VehicleRepositoryTests
{
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
}
