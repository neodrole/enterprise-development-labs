using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatchService.Application.Contracts;

namespace DispatchService.Application.Contracts.Vehicle;

/// <summary>
/// Dto для просмотра сведений о транспортном средстве
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="LicensePlate">Государственный номер</param>
/// <param name="VehicleType">Тип транспортного средства</param>
/// <param name="VehicleModelId">Идентификатор модели</param>
/// <param name="YearOfManufacture">Год выпуска</param>
public record VehicleDto(int Id, string? LicensePlate, VehicleTypes? VehicleType, int? VehicleModelId, int? YearOfManufacture);
