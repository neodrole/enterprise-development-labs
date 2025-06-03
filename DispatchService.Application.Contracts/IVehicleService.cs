using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Application.Contracts;

/// <summary>
/// Интерфейс для службы, выполняющей аналитический запрос согласно бизнес-логике приложения
/// </summary>
public interface IVehicleService
{
    /// <summary>
    /// Метод для вывода информации о транспортном средстве
    /// </summary>
    /// <returns>Строка с информацией о транспортном средстве</returns>
    public Task<string> GetFullInfo(int key);
}
