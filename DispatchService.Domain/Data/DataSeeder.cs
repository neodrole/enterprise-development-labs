using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatchService.Domain.Model;
namespace DispatchService.Domain.Data;
public static class DataSeeder
{
    public static readonly List<Vehicle> Vehicles =
        [
            new()
            {
                Id = 1,
                LicensePlate = "A123AA63",
                VehicleType = Vehicle.VehicleTypes.Bus,
                VehicleModelId = 1,
                YearOfManufacture = 2020,
            },
            new()
            {
                Id = 2,
                LicensePlate = "A123AA63",
                VehicleType = Vehicle.VehicleTypes.Trolleybus,
                VehicleModelId = 3,
                YearOfManufacture = 2022,
            },
            new()
            {
                Id = 3,
                LicensePlate = "A123AA63",
                VehicleType = Vehicle.VehicleTypes.Tram,
                VehicleModelId = 4,
                YearOfManufacture = 2021,
            },
            new()
            {
                Id = 4,
                LicensePlate = "A123AA63",
                VehicleType = Vehicle.VehicleTypes.Bus,
                VehicleModelId = 2,
                YearOfManufacture = 2023,
            },
            new()
            {
                Id = 5,
                LicensePlate = "A123AA63",
                VehicleType = Vehicle.VehicleTypes.Trolleybus,
                VehicleModelId = 3,
                YearOfManufacture = 2024,
            },
            new()
            {
                Id = 6,
                LicensePlate = "A123AA63",
                VehicleType = Vehicle.VehicleTypes.Tram,
                VehicleModelId = 5,
                YearOfManufacture = 2021,
            },

        ];
    public static readonly List<VehicleModel> VehicleModels =
        [
            new()
            {
                Id = 1,
                ModelName = "ЛиАЗ 4292",
                IsLowFloor = true,
                MaxCapacity = 82,
            },
            new()
            {
                Id = 2,
                ModelName = "ЛиАЗ 5292",
                IsLowFloor = true,
                MaxCapacity = 117,
            },
            new()
            {
                Id = 3,
                ModelName = "Адмирал 2022",
                IsLowFloor = true,
                MaxCapacity = 100,
            },
            new()
            {
                Id = 4,
                ModelName = "Богатырь-М",
                IsLowFloor = true,
                MaxCapacity = 184,
            },
            new()
            {
                Id = 5,
                ModelName = "Витязь-Ленинград",
                IsLowFloor = true,
                MaxCapacity = 255,
            },
            new()
            {
                Id = 6,
                ModelName = "ЛиАЗ 6213",
                IsLowFloor = true,
                MaxCapacity = 190,
            },
            
        ];
    public static readonly List<Driver> Drivers =
        [
            new()
            {
                Id = 1,
                LastName = "Иванов",
                FirstName = "Иван",
                Patronymic = "Иванович",
                Passport = "1122 345678",
                DriverLicense = "11 22 345678",
                Address = "Улица Пушкина Дом Колотушкина",
                Phone = "+74950198687",
            },
            new()
            {
                Id = 2,
                LastName = "Федоров",
                FirstName = "Иван",
                Patronymic = "Васильевич",
                Passport = "1122 345678",
                DriverLicense = "11 22 345678",
                Address = "Улица Пушкина Дом Колотушкина",
                Phone = "+74950198687",
            },
            new()
            {
                Id = 3,
                LastName = "Петров",
                FirstName = "Дмитрий",
                Patronymic = "Иванович",
                Passport = "1122 345678",
                DriverLicense = "11 22 345678",
                Address = "Улица Пушкина Дом Колотушкина",
                Phone = "+74950198687",
            },
            new()
            {
                Id = 4,
                LastName = "Сидоров",
                FirstName = "Василий",
                Patronymic = "Дмитриевич",
                Passport = "1122 345678",
                DriverLicense = "11 22 345678",
                Address = "Улица Пушкина Дом Колотушкина",
                Phone = "+74950198687",
            },
            new()
            {
                Id = 5,
                LastName = "Иванов",
                FirstName = "Константин",
                Patronymic = "Николаевич",
                Passport = "1122 345678",
                DriverLicense = "11 22 345678",
                Address = "Улица Пушкина Дом Колотушкина",
                Phone = "+74950198687",
            },
            new()
            {
                Id = 6,
                LastName = "Фролов",
                FirstName = "Иван",
                Patronymic = "Дмитриевич",
                Passport = "1122 345678",
                DriverLicense = "11 22 345678",
                Address = "Улица Пушкина Дом Колотушкина",
                Phone = "+74950198687",
            },
        ];
    public static readonly List<DailySchedule> DailySchedules =
        [
            new()
            {
                Id = 1,
                VehicleId = 1,
                DriverId = 1,
                Route = "52",
                StartTime = new DateTime(2025, 5, 15, 12, 30, 0),
                EndTime = new DateTime(2025, 5, 15, 14, 30, 0),
            },
            new()
            {
                Id = 2,
                VehicleId = 2,
                DriverId = 2,
                Route = "52",
                StartTime = new DateTime(2025, 5, 15, 9, 30, 0),
                EndTime = new DateTime(2025, 5, 15, 14, 30, 0),
            },
            new()
            {
                Id = 3,
                VehicleId = 3,
                DriverId = 3,
                Route = "52",
                StartTime = new DateTime(2025, 5, 15, 8, 0, 0),
                EndTime = new DateTime(2025, 5, 15, 16, 0, 0),
            },
            new()
            {
                Id = 4,
                VehicleId = 4,
                DriverId = 4,
                Route = "52",
                StartTime = new DateTime(2025, 5, 15, 12, 0, 0),
                EndTime = new DateTime(2025, 5, 15, 16, 0, 0),
            },
            new()
            {
                Id = 5,
                VehicleId = 5,
                DriverId = 5,
                Route = "52",
                StartTime = new DateTime(2025, 5, 15, 12, 30, 0),
                EndTime = new DateTime(2025, 5, 15, 14, 30, 0),
            },
            new()
            {
                Id = 6,
                VehicleId = 6,
                DriverId = 6,
                Route = "52",
                StartTime = new DateTime(2025, 5, 15, 5, 0, 0),
                EndTime = new DateTime(2025, 5, 15, 14, 0, 0),
            },
            new()
            {
                Id = 7,
                VehicleId = 1,
                DriverId = 1,
                Route = "52",
                StartTime = new DateTime(2025, 5, 25, 12, 30, 0),
                EndTime = new DateTime(2025, 5, 25, 14, 30, 0),
            },
            new()
            {
                Id = 8,
                VehicleId = 1,
                DriverId = 1,
                Route = "52",
                StartTime = new DateTime(2025, 5, 20, 12, 30, 0),
                EndTime = new DateTime(2025, 5, 20, 14, 30, 0),
            },
            new()
            {
                Id = 9,
                VehicleId = 2,
                DriverId = 2,
                Route = "52",
                StartTime = new DateTime(2025, 5, 25, 9, 30, 0),
                EndTime = new DateTime(2025, 5, 25, 14, 30, 0),
            },
            new()
            {
                Id = 10,
                VehicleId = 2,
                DriverId = 2,
                Route = "52",
                StartTime = new DateTime(2025, 5, 20, 8, 30, 0),
                EndTime = new DateTime(2025, 5, 20, 14, 30, 0),
            },
            new()
            {
                Id = 11,
                VehicleId = 4,
                DriverId = 4,
                Route = "52",
                StartTime = new DateTime(2025, 5, 15, 12, 30, 0),
                EndTime = new DateTime(2025, 5, 15, 14, 30, 0),
            },
            new()
            {
                Id = 12,
                VehicleId = 5,
                DriverId = 5,
                Route = "52",
                StartTime = new DateTime(2025, 5, 15, 12, 30, 0),
                EndTime = new DateTime(2025, 5, 15, 14, 30, 0),
            },

        ];
}
