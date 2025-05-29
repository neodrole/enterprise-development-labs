using AutoMapper;
using DispatchService.Application.Contracts;
using DispatchService.Application.Contracts.DailySchedule;
using DispatchService.Application.Contracts.Driver;
using DispatchService.Application.Contracts.Vehicle;
using DispatchService.Domain.Model;
using DispatchService.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Application.Services;
public class DailyScheduleCrudService(IDailyScheduleRepository repository, IMapper mapper ) : ICrudService<DailyScheduleDto, DailyScheduleCreateUpdateDto, int>, IAnalyticsService
{
    public async Task<DailyScheduleDto> Create(DailyScheduleCreateUpdateDto newDto)
    {
        var newDailySchedule = mapper.Map<DailySchedule>(newDto);
        var res = await repository.Add(newDailySchedule);
        return mapper.Map<DailyScheduleDto>(res);
    }

    public async Task<bool> Delete(int id) => await repository.Delete(id);

    public async Task<DailyScheduleDto?> GetById(int id)
    {
        var dailySchedule = await repository.Get(id);
        return mapper.Map<DailyScheduleDto>(dailySchedule);
    }

    public async Task<IList<DailyScheduleDto>> GetList() => mapper.Map<List<DailyScheduleDto>>(await repository.GetAll());

    public async Task<DailyScheduleDto> Update(int key, DailyScheduleCreateUpdateDto newDto)
    {
        
        var newDailySchedule = mapper.Map<DailySchedule>(newDto);
        await repository.Update(newDailySchedule);
        return mapper.Map<DailyScheduleDto>(newDailySchedule);
    }

    public async Task<IList<DriverDto>> GetDriversByPeriod(DateTime start, DateTime end)
    {
        var drivers = await repository.GetDriversByPeriod(start, end);
        return mapper.Map<List<DriverDto>>(drivers);
    }
    public async Task<Dictionary<string, TimeSpan>> GetTotalTimeByTypeAndModel() => await repository.GetTotalTimeByTypeAndModel();
    public async Task<IList<Tuple<string, int>>> GetTop5DriversByRides() => await repository.GetTop5DriversByRides();
    public async Task<IList<DriverRideInfoDto>> GetDriversRidesInfo()
    {
        var ridesInfo = await repository.GetDriversRidesInfo();
        return mapper.Map<List<DriverRideInfoDto>>(ridesInfo);
    }
    public async Task<IList<VehicleDto>> GetVehiclesWithMaxRides(DateTime start, DateTime end)
    {
        var vehicles = await repository.GetVehiclesWithMaxRides(start, end);
        return mapper.Map<List<VehicleDto>>(vehicles);
    }

}
