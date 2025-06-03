using AutoMapper;
using DispatchService.Application;
using DispatchService.Application.Contracts.DailySchedule;
using DispatchService.Application.Contracts.Driver;
using DispatchService.Application.Contracts.Vehicle;
using DispatchService.Application.Contracts.VehicleModel;
using DispatchService.Application.Contracts;
using DispatchService.Application.Services;
using DispatchService.Domain.Services;
using DispatchService.Domain.Model;
using DispatchService.Infrastructure.EfCore.Services;
using DispatchService.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

var mapperConfig = new MapperConfiguration(config => config.AddProfile(new AutoMapperProfile()));
IMapper? mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddTransient<IRepository<Driver, int>, DriverEfCoreRepository>();
builder.Services.AddTransient<IRepository<VehicleModel, int>, VehicleModelEfCoreRepository>();
builder.Services.AddTransient<IVehicleRepository, VehicleEfCoreRepository>();
builder.Services.AddTransient<IDailyScheduleRepository, DailyScheduleEfCoreRepository>();

builder.Services.AddScoped<ICrudService<DriverDto, DriverCreateUpdateDto, int>, DriverCrudService>();
builder.Services.AddScoped<ICrudService<VehicleModelDto, VehicleModelCreateUpdateDto, int>, VehicleModelCrudService>();
builder.Services.AddScoped<ICrudService<VehicleDto, VehicleCreateUpdateDto, int>, VehicleCrudService>();
builder.Services.AddScoped<ICrudService<DailyScheduleDto, DailyScheduleCreateUpdateDto, int>, DailyScheduleCrudService>();
builder.Services.AddScoped<IAnalyticsService, DailyScheduleCrudService>();
builder.Services.AddScoped<IVehicleService, VehicleCrudService>();

builder.Services.AddDbContextFactory<DispatchServiceDbContext>(options =>
    options.UseLazyLoadingProxies().UseMySql(builder.Configuration.GetConnectionString("MySql"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySql"))));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
