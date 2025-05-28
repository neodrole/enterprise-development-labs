using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Domain.Model;
public class DailySchedule
{
    [Key]
    public required int Id  { get; set; }
    public required int VehicleId { get; set; }
    public virtual Vehicle? Vehicle { get; set; }
    public required int DriverId { get; set; }
    public virtual Driver? Driver { get; set; }
    //возможно, нужен отдельный класс с маршрутами, но усложнять себе жизнь не хочу
    public string? Route { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    //мб пригодится
    //public DateOnly? Date {  get; set; }
}
