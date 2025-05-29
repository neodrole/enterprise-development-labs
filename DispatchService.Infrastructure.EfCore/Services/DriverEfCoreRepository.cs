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
public class DriverEfCoreRepository(DispatchServiceDbContext context) : IRepository<Driver, int>
{
    private readonly DbSet<Driver> _drivers = context.Drivers;

    public async Task<Driver> Add (Driver entity)
    {
        var result = await _drivers.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> Delete (int key)
    {
        var entity = await _drivers.FirstOrDefaultAsync(e => e.Id == key);
        if (entity == null)
            return false;
        _drivers.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<Driver>? Get(int key) =>
        await _drivers.FirstOrDefaultAsync(e => e.Id == key);

    public async Task<IList<Driver>> GetAll() =>
        await _drivers.ToListAsync();

    public async Task<Driver> Update(Driver entity)
    {
        _drivers.Update(entity);
        await context.SaveChangesAsync();
        return (await Get(entity.Id))!;
    }
}
