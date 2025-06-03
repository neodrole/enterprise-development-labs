using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Application.Contracts.DailySchedule;

/// <summary>
/// Dto для создания или изменения ежедневного графика
/// </summary>
/// <param name="VehicleId">Идентификатор транспортного средства</param>
/// <param name="DriverId">Идентификатор водителя</param>
/// <param name="Route">Маршрут</param>
/// <param name="StartTime">Время выхода на рейс</param>
/// <param name="EndTime">Время окончания рейса</param>
public record DailyScheduleCreateUpdateDto(int VehicleId, int DriverId, string? Route, DateTime? StartTime, DateTime? EndTime);
