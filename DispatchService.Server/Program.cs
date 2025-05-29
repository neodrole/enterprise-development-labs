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
using DispatchService.Domain.Services.InMemory;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); /* ладно, у меня все равно ничего не написано.
    options =>
{
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{typeof(VehicleDto).Assembly.GetName().Name}.xml"));
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{typeof(VehicleModelDto).Assembly.GetName().Name}.xml"));
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{typeof(DriverDto).Assembly.GetName().Name}.xml"));
}); */

var mapperConfig = new MapperConfiguration(config => config.AddProfile(new AutoMapperProfile()));
IMapper? mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddSingleton<IRepository<Driver, int>, DriverInMemoryRepository>();
builder.Services.AddSingleton<IRepository<VehicleModel, int>, VehicleModelInMemoryRepository>();
builder.Services.AddSingleton<IVehicleRepository, VehicleInMemoryRepository>();
builder.Services.AddSingleton<IDailyScheduleRepository, DailyScheduleInMemoryRepository>();

builder.Services.AddScoped<ICrudService<DriverDto, DriverCreateUpdateDto, int>, DriverCrudService>();
builder.Services.AddScoped<ICrudService<VehicleModelDto, VehicleModelCreateUpdateDto, int>, VehicleModelCrudService>();
builder.Services.AddScoped<ICrudService<VehicleDto, VehicleCreateUpdateDto, int>, VehicleCrudService>();
builder.Services.AddScoped<ICrudService<DailyScheduleDto, DailyScheduleCreateUpdateDto, int>, DailyScheduleCrudService>();
builder.Services.AddScoped<IAnalyticsService, DailyScheduleCrudService>();
builder.Services.AddScoped<IVehicleService, VehicleCrudService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
