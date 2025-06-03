using DispatchService.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Domain.Services;

/// <summary>
/// Наследник обобщенного интерфейса для транспортных средств с дополнительной функциональностью 
/// </summary>
public interface IVehicleRepository : IRepository<Vehicle, int>
{
    /// <summary>
    /// Метод для вывода информации о транспортном средстве
    /// </summary>
    /// <returns>Строка с информацией о транспортном средстве</returns>
    public Task<string> GetFullInfo(int key);
}
