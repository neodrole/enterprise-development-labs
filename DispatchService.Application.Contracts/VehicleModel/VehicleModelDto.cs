using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Application.Contracts.VehicleModel;

/// <summary>
/// Dto для просмотра сведений о модели транспортного средства
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="ModelName">Название модели</param>
/// <param name="IsLowFloor">Низкопольный / нет</param>
/// <param name="MaxCapacity">Максимальная вместимость</param>
public record VehicleModelDto(int Id, string? ModelName, bool IsLowFloor, int? MaxCapacity);
