using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DispatchService.Domain.Model;
using DispatchService.Domain.Services;
using DispatchService.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace DispatchService.Infrastructure.EfCore.Services;
public class VehicleModelEfCoreRepository(DispatchServiceDbContext context) : IRepository<VehicleModel, int>
{
    private readonly DbSet<VehicleModel> _vehicleModels = context.VehicleModels;

    public async Task<VehicleModel> Add(VehicleModel entity)
    {
        var result = await _vehicleModels.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> Delete(int key)
    {
        var entity = await _vehicleModels.FirstOrDefaultAsync(e => e.Id == key);
        if (entity == null)
            return false;
        _vehicleModels.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<VehicleModel>? Get(int key) =>
        await _vehicleModels.FirstOrDefaultAsync(e => e.Id == key);

    public async Task<IList<VehicleModel>> GetAll() =>
        await _vehicleModels.ToListAsync();

    public async Task<VehicleModel> Update(VehicleModel entity)
    {
        _vehicleModels.Update(entity);
        await context.SaveChangesAsync();
        return (await Get(entity.Id))!;
    }
}