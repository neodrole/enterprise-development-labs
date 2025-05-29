using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Application.Contracts.Driver;

public record DriverDto(int Id, string? LastName, string? FirstName, string? Patronymic, string? Passport, string? DriverLicense, string? Address, string? Phone);

