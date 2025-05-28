using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Domain.Model;
public class VehicleModel
{
    [Key]
    public required int Id { get; set; }
    public string? ModelName { get; set; }
    public bool IsLowFloor { get; set; }
    public int? MaxCapacity { get; set; }
}
