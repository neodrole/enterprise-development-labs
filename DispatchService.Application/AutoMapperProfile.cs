using AutoMapper;
using DispatchService.Application.Contracts;
using DispatchService.Application.Contracts.DailySchedule;
using DispatchService.Application.Contracts.Driver;
using DispatchService.Application.Contracts.Vehicle;
using DispatchService.Application.Contracts.VehicleModel;
using DispatchService.Domain.Model;
using DispatchService.Domain.Services;
using System.Net;
namespace DispatchService.Application;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<DailySchedule, DailyScheduleDto>();
        CreateMap<DailyScheduleCreateUpdateDto, DailySchedule>();

        CreateMap<Driver, DriverDto>();
        CreateMap<DriverCreateUpdateDto, Driver>();

        CreateMap<Vehicle, VehicleDto>();
        CreateMap<VehicleCreateUpdateDto, Vehicle>();

        CreateMap<VehicleModel, VehicleModelDto>();
        CreateMap<VehicleModelCreateUpdateDto, VehicleModel>();

        CreateMap<DriverRideInfo, DriverRideInfoDto>();
    }
}
/*

у меня тут идея возникла

⣿⣿⣿⣿⣿⣿⣿⠿⠿⢛⣋⣙⣋⣩⣭⣭⣭⣭⣍⣉⡛⠻⢿⣿⣿⣿⣿
⣿⣿⣿⠟⣋⣥⣴⣾⣿⣿⣿⡆⣿⣿⣿⣿⣿⣿⡿⠟⠛⠗⢦⡙⢿⣿⣿
⣿⡟⡡⠾⠛⠻⢿⣿⣿⣿⡿⠃⣿⡿⣿⠿⠛⠉⠠⠴⢶⡜⣦⡀⡈⢿⣿
⡿⢀⣰⡏⣼⠋⠁⢲⡌⢤⣠⣾⣷⡄⢄⠠⡶⣾⡀⠀⣸⡷⢸⡷⢹⠈⣿
⡇⢘⢿⣇⢻⣤⣠⡼⢃⣤⣾⣿⣿⣿⢌⣷⣅⡘⠻⠿⢛⣡⣿⠀⣾⢠⣿
⣷⠸⣮⣿⣷⣨⣥⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⢁⡼⠃⣼⣿
⡟⠛⠛⠛⣿⠛⠛⢻⡟⠛⠛⢿⡟⠛⠛⡿⢻⡿⠛⡛⢻⣿⠛⡟⠛⠛⢿
⡇⢸⣿⠀⣿⠀⠛⢻⡇⠸⠃⢸⡇⠛⢛⡇⠘⠃⢼⣷⡀⠃⣰⡇⠸⠇⢸
⡇⢸⣿⠀⣿⠀⠛⢻⡇⢰⣿⣿⡇⠛⠛⣇⢸⣧⠈⣟⠃⣠⣿⡇⢰⣾⣿
⣿⣿⣿⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢋⣿⠙⣷⢸⣷⠀⣿⣿⣿
⣿⣿⣿⡇⢻⣿⣿⣿⡿⠿⢿⣿⣿⣿⠟⠋⣡⡈⠻⣇⢹⣿⣿⢠⣿⣿⣿
⣿⣿⣿⣿⠘⣿⣿⣿⣿⣯⣽⣉⣿⣟⣛⠷⠙⢿⣷⣌⠀⢿⡇⣼⣿⣿⣿
⣿⣿⣿⡿⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣤⡙⢿⢗⣀⣁⠈⢻⣿⣿
⣿⡿⢋⣴⣿⣎⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⡉⣯⣿⣷⠆⠙⢿
⣏⠀⠈⠧⠡⠉⠙⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠃⠉⢉⣁⣀⣀⣾


i⠄⠄⠄⠄⠄⠄⠄⢀⣠⣴⣾⣿⣿⣿⣿⣿⣿⣿⣷⣶⣤⡀⠄⠄⠄⠄⠄⠄⠄
i⠄⠄⠄⠄⠄⣠⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣄⠄⠄⠄⠄⠄
i⠄⠄⠄⠄⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣆⠄⠄⠄⠄
i⠄⠄⠄⠘⠘⣿⣿⣿⣿⡿⢿⣿⣿⣿⡿⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⡆⠄⠄⠄
i⠄⣠⣴⡄⠄⢱⣿⣿⣿⠇⣼⠟⣹⡅⠃⠄⢻⣿⣏⣿⢂⠻⡏⠹⣿⣷⣀⠄⠄
i⠊⣸⣿⢱⡄⣼⣿⣿⣿⣀⣧⣦⣿⣷⣶⣾⣾⣿⣿⣿⣿⣦⣧⡀⣿⣿⣿⡓⠄
i⠄⠻⣧⠄⠄⢻⣿⣿⣏⢛⣉⠉⠉⢉⣻⣿⣿⣿⣿⡿⠛⠉⢉⠓⣹⣿⣿⡇⠄
i⠄⠄⢨⣤⣄⢸⣿⣿⣟⢞⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⡿⢡⣿⣿⡏⠄⠄
i⠄⠄⣿⣿⣷⣿⣿⣿⣻⣦⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⣴⣿⣿⠇⠄⠄
i⠄⢠⣿⣿⣿⡏⢿⣿⡇⠇⠋⠙⠻⠿⣿⣿⣿⣿⣿⠿⠟⠋⡼⠝⣾⡟⠄⠄⠄
i⣠⣿⣿⣿⠇⡇⠘⠙⣷⡈⠄⠄⠄⠄⠄⣈⡉⠉⠄⠄⣀⡀⠄⢠⡿⡃⠄⠄⠄
i⣿⡏⢉⣉⣿⡟⠛⠙⠻⣿⡏⢉⠛⢿⡿⠛⡙⢻⣿⡏⢉⣉⣿⡏⠹⡏⢹⣿⣿
i⣿⡇⢨⣭⣿⠄⢾⡿⠄⣿⡇⠈⠁⣼⣷⣄⡉⠻⣿⡇⢨⣭⣿⡇⢀⠁⢸⣿⣿
i⣿⣧⣼⣿⣿⣧⣤⣤⣼⣿⣧⣼⣤⣼⣧⣤⣥⣼⣿⣧⣬⣭⣿⣧⣼⣦⣼⣿⣿

ладно, хватит
*/