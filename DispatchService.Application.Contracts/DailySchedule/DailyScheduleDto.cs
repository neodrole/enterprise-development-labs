using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Application.Contracts.DailySchedule;
public record DailyScheduleDto(int Id, int VehicleId, int DriverId, string? Route, DateTime? StartTime, DateTime? EndTime);
