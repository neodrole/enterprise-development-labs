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
    public bool Create(DailyScheduleCreateUpdateDto newDto)
    {
        var newDailySchedule = mapper.Map<DailySchedule>(newDto);
        newDailySchedule.Id = repository.GetAll().Max(x => x.Id) + 1;
        var result = repository.Add(newDailySchedule);
        return result;
    }

    public bool Delete(int id) => repository.Delete(id);

    public DailyScheduleDto? GetById(int id)
    {
        var dailySchedule = repository.Get(id);
        return mapper.Map<DailyScheduleDto>(dailySchedule);
    }

    public IList<DailyScheduleDto> GetList() => mapper.Map<List<DailyScheduleDto>>(repository.GetAll());

    public bool Update(int key, DailyScheduleCreateUpdateDto newDto)
    {
        var oldDailySchedule = repository.Get(key);
        var newDailySchedule = mapper.Map<DailySchedule>(newDto);
        newDailySchedule.Id = key;
        // от старого расписания по идее больше ничего не нужно (?)
        //хотя смотрю в образец и будто я делаю что-то не так, ну да ладно, едем дальше 
        var result = repository.Update(newDailySchedule);
        return result;
    }

    public IList<DriverDto> GetDriversByPeriod(DateTime start, DateTime end)
    {
        var drivers = repository.GetDriversByPeriod(start, end);
        return mapper.Map<List<DriverDto>>(drivers);
    }
    public Dictionary<string, TimeSpan> GetTotalTimeByTypeAndModel() => repository.GetTotalTimeByTypeAndModel();
    public IList<Tuple<string, int>> GetTop5DriversByRides() => repository.GetTop5DriversByRides();
    public IList<DriverRideInfoDto> GetDriversRidesInfo()
    {
        var ridesInfo = repository.GetDriversRidesInfo();
        return mapper.Map<List<DriverRideInfoDto>>(ridesInfo);
    }
    public IList<VehicleDto> GetVehiclesWithMaxRides(DateTime start, DateTime end)
    {
        var vehicles = repository.GetVehiclesWithMaxRides(start, end);
        return mapper.Map<List<VehicleDto>>(vehicles);
    }

}
