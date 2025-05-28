using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Domain.Model;

public class Vehicle
{
    [Key]
    public required int Id { get; set; }
    //гос номер
    public string? LicensePlate { get; set; }
    
    
    // тип  автобус / троллейбус / трамвай
    public enum VehicleTypes
    {
        Bus,
        Trolleybus,
        Tram
    }
    public VehicleTypes? VehicleType { get; set; }
    //модель название модели, низкопольный/нет, макс вместимость
    //public VehicleModel? VehicleModel { get; set; }
    public int? VehicleModelId { get; set; }
    //год выпуска
    public int? YearOfManufacture {  get; set; }

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