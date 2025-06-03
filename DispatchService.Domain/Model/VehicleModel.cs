using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Domain.Model;

/// <summary>
/// Модель транспортного средства
/// </summary>
public class VehicleModel
{
    /// <summary>
    /// Идентификатор модели транспортного средства
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Название модели
    /// </summary>
    public string? ModelName { get; set; }

    /// <summary>
    /// Низкопольный / нет
    /// </summary>
    public bool IsLowFloor { get; set; }

    /// <summary>
    /// Максимальная вместимость
    /// </summary>
    public int? MaxCapacity { get; set; }
}
