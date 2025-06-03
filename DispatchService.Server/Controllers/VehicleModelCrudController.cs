using DispatchService.Application.Contracts;
using DispatchService.Application.Contracts.Vehicle;
using DispatchService.Application.Contracts.VehicleModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DispatchService.Server.Controllers;
/// <summary>
/// Контроллер для CRUD-операций над моделями транспортных средств
/// </summary>
/// <param name="crudService">CRUD-служба</param>
[Route("api/[controller]")]
[ApiController]
public class VehicleModelCrudController(ICrudService<VehicleModelDto, VehicleModelCreateUpdateDto, int> crudService)
    : CrudControllerBase<VehicleModelDto, VehicleModelCreateUpdateDto, int>(crudService);