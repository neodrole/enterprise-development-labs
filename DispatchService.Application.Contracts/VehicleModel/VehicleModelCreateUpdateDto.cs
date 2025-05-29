using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Application.Contracts.VehicleModel;
public record VehicleModelCreateUpdateDto(string? ModelName, bool IsLowFloor, int? MaxCapacity);

