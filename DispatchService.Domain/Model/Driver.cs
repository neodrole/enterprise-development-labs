using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Domain.Model;

/// <summary>
/// Водитель
/// </summary>
public class Driver
{
    /// <summary>
    /// Идентификатор водителя
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Фамилия водителя
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Имя водителя
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// Отчество водителя
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// Полное имя водителя
    /// </summary>
    public string? FullName => $"{LastName} {FirstName} {Patronymic}".Trim();

    /// <summary>
    /// Паспортные данные
    /// </summary>
    public string? Passport { get; set; }

    /// <summary>
    /// Данные водительского удостоверения
    /// </summary>
    public string? DriverLicense { get; set; }

    /// <summary>
    /// Адрес водителя
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Телефонный номер водителя
    /// </summary>
    public string? Phone { get; set; }


}
