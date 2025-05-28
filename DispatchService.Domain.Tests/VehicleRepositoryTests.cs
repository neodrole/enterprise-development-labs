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

        var expected = new StringBuilder()
            .AppendLine("ID: 2")
            .AppendLine("Гос. номер: A123AA63")
            .AppendLine("Тип транспорта: Троллейбус")
            .AppendLine("Год выпуска: 2022")
            .AppendLine("Модель")
            .AppendLine("Название: Адмирал 2022")
            .AppendLine("Низкопольный: да")
            .AppendLine("Вместимость: 100 чел.")
            .ToString();
        var repo = new VehicleInMemoryRepository();
        var result = repo.GetFullInfo(2);
        Assert.Equal(expected, result);
    }
}
