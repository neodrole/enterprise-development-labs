using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Domain.Model;

/// <summary>
/// Транспортное средство
/// </summary>
public class Vehicle
{
    /// <summary>
    /// Идентификатор транспорта
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Государственный номер транспортного средства
    /// </summary>
    public string? LicensePlate { get; set; }

    /// <summary>
    /// Тип транспортного средства
    /// </summary>
    public VehicleTypes? VehicleType { get; set; }

    /// <summary>
    /// Идентификатор модели транспортного средства
    /// </summary>
    public int? VehicleModelId { get; set; }

    /// <summary>
    /// Год выпуска транспортного средства
    /// </summary>
    public int? YearOfManufacture {  get; set; }

    /// <summary>
    /// Метод для получения строкового обозначения типа транспортного средства
    /// </summary>
    /// <returns>Тип транспортного средства</returns>
    public string GetVehicleTypeName()
    {
        return VehicleType switch
        {
            VehicleTypes.Bus => "Автобус",
            VehicleTypes.Trolleybus => "Троллейбус",
            VehicleTypes.Tram => "Трамвай",
            _ => "не указан"
        };
    }
}