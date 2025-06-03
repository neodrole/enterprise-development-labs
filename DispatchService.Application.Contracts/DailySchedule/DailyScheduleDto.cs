using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Application.Contracts.DailySchedule;

/// <summary>
/// Dto для просмотра сведений о ежедневном графике
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="VehicleId">Идентификатор транспортного средства</param>
/// <param name="DriverId">Идентификатор водителя</param>
/// <param name="Route">Маршрут</param>
/// <param name="StartTime">Время выхода на рейс</param>
/// <param name="EndTime">Время окончания рейса</param>
public record DailyScheduleDto(int Id, int VehicleId, int DriverId, string? Route, DateTime? StartTime, DateTime? EndTime);
