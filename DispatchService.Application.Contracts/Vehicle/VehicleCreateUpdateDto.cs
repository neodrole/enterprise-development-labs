using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Application.Contracts.Vehicle;

/// <summary>
/// Dto для создания или изменения транспортного средства
/// </summary>
/// <param name="LicensePlate">Государственный номер</param>
/// <param name="VehicleType">Тип транспортного средства</param>
/// <param name="VehicleModelId">Идентификатор модели</param>
/// <param name="YearOfManufacture">Год выпуска</param>
public record VehicleCreateUpdateDto(string? LicensePlate, VehicleTypes? VehicleType, int? VehicleModelId, int? YearOfManufacture);
