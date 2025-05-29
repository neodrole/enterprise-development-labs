using AutoMapper;
using DispatchService.Application.Contracts;
using DispatchService.Application.Contracts.Vehicle;
using DispatchService.Application.Contracts.VehicleModel;
using DispatchService.Domain.Model;
using DispatchService.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Application.Services;
public class VehicleModelCrudService(IRepository<VehicleModel, int> repository, IMapper mapper) : ICrudService<VehicleModelDto, VehicleModelCreateUpdateDto, int>
{
    public bool Create(VehicleModelCreateUpdateDto newDto)
    {
        var newVehicleModel = mapper.Map<VehicleModel>(newDto);
        newVehicleModel.Id = repository.GetAll().Max(x => x.Id) + 1;
        var result = repository.Add(newVehicleModel);
        return result;
    }

    public bool Delete(int id) => repository.Delete(id);

    public VehicleModelDto? GetById(int id)
    {
        var vehicleModel = repository.Get(id);
        return mapper.Map<VehicleModelDto>(vehicleModel);
    }

    public IList<VehicleModelDto> GetList() => mapper.Map<List<VehicleModelDto>>(repository.GetAll());

    public bool Update(int key, VehicleModelCreateUpdateDto newDto)
    {
        var oldVehicleModel = repository.Get(key);
        var newVehicleModel = mapper.Map<VehicleModel>(newDto);
        newVehicleModel.Id = key;
        var result = repository.Update(newVehicleModel);
        return result;
    }
}
