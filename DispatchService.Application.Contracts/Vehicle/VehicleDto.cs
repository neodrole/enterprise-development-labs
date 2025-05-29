using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatchService.Application.Contracts;
namespace DispatchService.Application.Contracts.Vehicle;


public record VehicleDto(int Id, string? LicensePlate, VehicleTypes? VehicleType, int? VehicleModelId, int? YearOfManufacture);
