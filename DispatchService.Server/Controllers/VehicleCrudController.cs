using DispatchService.Application.Contracts;
using DispatchService.Application.Contracts.Vehicle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DispatchService.Server.Controllers;
/// <summary>
/// Контроллер для CRUD-операций над транспортными средствами
/// </summary>
/// <param name="crudService">CRUD-служба</param>
[Route("api/[controller]")]
[ApiController]
public class VehicleCrudController(ICrudService<VehicleDto, VehicleCreateUpdateDto, int> crudService) 
    : CrudControllerBase<VehicleDto, VehicleCreateUpdateDto, int>(crudService);

