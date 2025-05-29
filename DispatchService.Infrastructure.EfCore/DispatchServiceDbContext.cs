using DispatchService.Domain.Data;
using DispatchService.Domain.Model;
using Microsoft.EntityFrameworkCore;
namespace DispatchService.Infrastructure.EfCore;

public class DispatchServiceDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<DailySchedule> DailySchedules { get; set; }
    public DbSet<VehicleModel> VehicleModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VehicleModel>(builder =>
        {
            builder.HasKey(vm => vm.Id);
            builder.HasData(DataSeeder.VehicleModels);
        });

        modelBuilder.Entity<Vehicle>(builder =>
        {
            builder.HasKey(v => v.Id);
            builder.Property(v => v.VehicleType)
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.HasOne<VehicleModel>()
                .WithMany()
                .HasForeignKey(v => v.VehicleModelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(DataSeeder.Vehicles);
        });

        modelBuilder.Entity<Driver>(builder =>
        {
            builder.HasKey(d => d.Id);
            builder.HasData(DataSeeder.Drivers);
        });

        modelBuilder.Entity<DailySchedule>(builder =>
        {
            builder.HasKey(ds => ds.Id);
            builder.HasOne(ds => ds.Driver)
                .WithMany()
                .HasForeignKey(ds => ds.DriverId);
            builder.HasOne(ds => ds.Vehicle)
                .WithMany()
                .HasForeignKey(ds => ds.VehicleId);
            builder.HasData(DataSeeder.DailySchedules);
        });

        
    }
}
