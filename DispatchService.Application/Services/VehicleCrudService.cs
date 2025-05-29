using AutoMapper;
using DispatchService.Application.Contracts;
using DispatchService.Application.Contracts.Vehicle;
using DispatchService.Domain.Services;
using DispatchService.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Application.Services;
public class VehicleCrudService(IVehicleRepository repository, IMapper mapper) : ICrudService<VehicleDto, VehicleCreateUpdateDto, int>, IVehicleService
{
    public bool Create(VehicleCreateUpdateDto newDto)
    {
        var newVehicle = mapper.Map<Vehicle>(newDto);
        newVehicle.Id = repository.GetAll().Max(x => x.Id) + 1;
        var result = repository.Add(newVehicle);
        return result;
    }

    public bool Delete (int id) => repository.Delete(id);

    public VehicleDto? GetById(int id)
    {
        var vehicle = repository.Get(id);
        return mapper.Map<VehicleDto>(vehicle);
    }

    public IList<VehicleDto> GetList() =>mapper.Map<List<VehicleDto>>(repository.GetAll());

    public bool Update(int key, VehicleCreateUpdateDto newDto)
    {
        var oldVehicle = repository.Get(key);
        var newVehicle = mapper.Map<Vehicle>(newDto);
        newVehicle.Id = key;
        var result = repository.Update(newVehicle);
        return result;
    }
    public string GetFullInfo(int key) => repository.GetFullInfo(key);
}
