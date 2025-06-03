using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Application.Contracts.Driver;

/// <summary>
/// Dto для просмотра сведений о водителе
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="LastName">Фамилия</param>
/// <param name="FirstName">Имя</param>
/// <param name="Patronymic">Отчество</param>
/// <param name="Passport">Паспорт</param>
/// <param name="DriverLicense">Водительское удостоверение</param>
/// <param name="Address">Адрес</param>
/// <param name="Phone">Номер телефона</param>
public record DriverDto(int Id, string? LastName, string? FirstName, string? Patronymic, string? Passport, string? DriverLicense, string? Address, string? Phone);

