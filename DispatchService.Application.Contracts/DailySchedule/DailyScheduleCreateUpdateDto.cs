using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Application.Contracts.DailySchedule;
public record DailyScheduleCreateUpdateDto(int VehicleId, int DriverId, string? Route, DateTime? StartTime, DateTime? EndTime);
