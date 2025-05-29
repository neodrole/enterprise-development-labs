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
    public async Task<VehicleDto> Create(VehicleCreateUpdateDto newDto)
    {
        var newVehicle = mapper.Map<Vehicle>(newDto);
        newVehicle.Id = (await repository.GetAll()).Max(x => x.Id) + 1;
        var result = await repository.Add(newVehicle);
        return mapper.Map<VehicleDto>(result);
    }

    public async Task<bool> Delete (int id) => await repository.Delete(id);

    public async Task<VehicleDto?> GetById(int id)
    {
        var vehicle = await repository.Get(id);
        return mapper.Map<VehicleDto>(vehicle);
    }

    public async Task<IList<VehicleDto>> GetList() =>mapper.Map<List<VehicleDto>>(await repository.GetAll());

    public async Task<VehicleDto> Update(int key, VehicleCreateUpdateDto newDto)
    {
        var newVehicle = mapper.Map<Vehicle>(newDto);
        await repository.Update(newVehicle);
        return mapper.Map<VehicleDto>(newVehicle);
    }
    public async Task<string> GetFullInfo(int key) => await repository.GetFullInfo(key);
}
