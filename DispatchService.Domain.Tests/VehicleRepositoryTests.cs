using DispatchService.Domain.Services.InMemory;
using System.Numerics;
using System.Text;

namespace DispatchService.Domain.Tests;

/// <summary>
///  Класс с юнит-тестами репозитория с транспортными средствами
/// </summary>
public class VehicleRepositoryTests
{
    /// <summary>
    /// Непараметрический тест метода, выводящего информацию о транспортном средстве
    /// </summary>
    [Fact]
    public async Task GetFullInfo_Success()
    {

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
        var result = await repo.GetFullInfo(2);
        Assert.Equal(expected, result);
    }
}
