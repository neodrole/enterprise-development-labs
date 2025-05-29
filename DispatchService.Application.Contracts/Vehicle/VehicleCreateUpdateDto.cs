using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Application.Contracts.Vehicle;
public record VehicleCreateUpdateDto(string? LicensePlate, VehicleTypes? VehicleType, int? VehicleModelId, int? YearOfManufacture);
