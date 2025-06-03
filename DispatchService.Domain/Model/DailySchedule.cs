using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Domain.Model;

/// <summary>
/// Ежедневный график
/// </summary>
public class DailySchedule
{
    /// <summary>
    /// Идентификатор графика
    /// </summary>
    [Key]
    public required int Id  { get; set; }

    /// <summary>
    /// Идентификатор транспортного средства
    /// </summary>
    public required int VehicleId { get; set; }

    /// <summary>
    /// Навигейшен транспортного средства
    /// </summary>
    public virtual Vehicle? Vehicle { get; set; }

    /// <summary>
    /// Идентификатор водителя
    /// </summary>
    public required int DriverId { get; set; }

    /// <summary>
    /// Навигейшен водителя
    /// </summary>
    public virtual Driver? Driver { get; set; }

    /// <summary>
    /// Маршрут
    /// </summary>
    public string? Route { get; set; }

    /// <summary>
    /// Время выхода на рейс
    /// </summary>
    public DateTime? StartTime { get; set; }

    /// <summary>
    /// Время окончания рейса
    /// </summary>
    public DateTime? EndTime { get; set; }

}
