using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Domain.Model;
public class Driver
{
    [Key]
    public required int Id { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public string? Patronymic { get; set; }
    public string? FullName => $"{LastName} {FirstName} {Patronymic}".Trim();
    public string? Passport { get; set; }
    public string? DriverLicense { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }


}
