using DispatchService.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatchService.Infrastructure.EfCore;
public class DispatchServiceDbContextFactory : IDesignTimeDbContextFactory<DispatchServiceDbContext>
{
    private const string _connectionString = "Server=localhost;Username=root;Password=socdephehviWjogbu2;Database=dispatchservice;Port=3306;Pooling=true;";
    public DispatchServiceDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DispatchServiceDbContext>();
        optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
        return new DispatchServiceDbContext(optionsBuilder.Options);
    }
}
