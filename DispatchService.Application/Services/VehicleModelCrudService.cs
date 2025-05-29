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
    public async Task<VehicleModelDto> Create(VehicleModelCreateUpdateDto newDto)
    {
        var newVehicleModel = mapper.Map<VehicleModel>(newDto);
        newVehicleModel.Id = (await repository.GetAll()).Max(x => x.Id) + 1;
        var result = await repository.Add(newVehicleModel);
        return mapper.Map<VehicleModelDto>(result);
    }

    public async Task<bool> Delete(int id) => await repository.Delete(id);

    public async Task<VehicleModelDto?> GetById(int id)
    {
        var vehicle = await repository.Get(id);
        return mapper.Map<VehicleModelDto>(vehicle);
    }

    public async Task<IList<VehicleModelDto>> GetList() => mapper.Map<List<VehicleModelDto>>(await repository.GetAll());

    public async Task<VehicleModelDto> Update(int key, VehicleModelCreateUpdateDto newDto)
    {
        var newVehicleModel = mapper.Map<VehicleModel>(newDto);
        await repository.Update(newVehicleModel);
        return mapper.Map<VehicleModelDto>(newVehicleModel);
    }
}
