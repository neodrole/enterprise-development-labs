using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Domain.Model;

/// <summary>
/// Информация о поездках водителя
/// </summary>
public class DriverRideInfo
{
    /// <summary>
    /// Полное имя водителя
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Количество поездок
    /// </summary>
    public int RideCount { get; set; }

    /// <summary>
    /// Среднее время поездки
    /// </summary>
    public TimeSpan AverageDuration { get; set; }

    /// <summary>
    /// Максимальное время поездки
    /// </summary>
    public TimeSpan MaxDuration { get; set; }
}
