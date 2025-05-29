using DispatchService.Application.Contracts;
using DispatchService.Application.Contracts.Vehicle;
using DispatchService.Application.Contracts.VehicleModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DispatchService.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class VehicleModelCrudController(ICrudService<VehicleModelDto, VehicleModelCreateUpdateDto, int> crudService)
    : CrudControllerBase<VehicleModelDto, VehicleModelCreateUpdateDto, int>(crudService);